# Wrath Loot Council
## Guild Management
WrathLC is an open-source and free-to-use tool, designed to give guilds increased power 
and transparency in managing their guild administration between raid events.

It was designed for Buzz, a horde guild on Grobbulus. Design decisions reflect the guild's use case.

WrathLC supports an OAUTH2-secured REST API. Please reach out to the development team if you would like to build your 
own client integration.

### To Contribute to this Repository
Install the Dependencies

- .NET 6.0 SDK ([Installers](https://dotnet.microsoft.com/en-us/download/dotnet/6.0))
- Node 16.10.X ([Installers](https://nodejs.org/en/download/))
- PostgreSQL ([Installers](https://www.postgresql.org/download/))
- Docker ([Installers](https://docs.docker.com/engine/install/))

This repository contains three distinct applications/systems:

- An Identity Provider/Authorization Server: **WrathLC.Idp**
- A Web API: **WrathLC.Api**
- An Angular SPA Web Application: **wrath-lc-app**

The **Infra** directory contains terraform files for the AWS infrastructure and are not relevant for continued development.

#### SSL Certs

The identity provider requires an SSL certificate to run, and all applications must be run using HTTPS.

##### For Windows:
Run the following commands in your windows terminal:
```
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p <password>
dotnet dev-certs https --trust
```
replace `<password>` with a your desired password

##### For macOS or Linux
Run the following commands in your terminal:
```
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p <password>
dotnet dev-certs https --trust
```
replace `<password>` with a your desired password

#### API Configuration
To configure the API project, duplicate the `appsettings.json` file locally and create a new file 
named `appsettings.development.json`. In this file, update the `DefaultConnection` field with your 
desired PostGres connection string.
Example:
```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=wrath-lc;User Id=postgres;Password=password"
  }
```

#### IDP Configuration
To configure the Identity Provider, you will first need to set up an OAUTH2 client application within Discord.

https://discord.com/developers/applications

After you have setup an application, duplicate the `appsettings.json` to create an `appsettings.development.json`.
Include the following:
```json
"Authentication": {
    "Discord": {
      "ClientId": "YOUR DISCORD APP CLIENT ID",
      "ClientSecret": "YOUR DISCORD APP CLIENT SECRET"
    }
  },
  "Clients": [
    {
      "ClientId": "wrath-lc-app",
      "ClientSecret": "901564A5-E7FE-42CB-B10D-61EF6A8F3654",
      "FirstParty": true,
      "DisplayName": "Wrath LC",
      "RedirectUris": [
        "https://localhost:4200/signin-oidc"
      ]
    }
  ],
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=wrath-lc;User Id=postgres;Password=password"
  }
```
Update the `DefaultConnection` as needed to connect to your local Postgres instance. The `Clients` section may be changed, 
however the Angular app configuration will need to mirror the IDP configuration.

#### Angular SPA Configuration
Duplicate the `environment.ts` to create an `environment.development.ts` file.
```ts
export const environment = {
  production: false,
  oidcAuthority: "https://localhost:7182",
  oidcClientId: "wrath-lc-app",
  oidcClientSecret: "901564A5-E7FE-42CB-B10D-61EF6A8F3654"
};
```
Here the OIDC fields must correspond with the configuration of the `IDP` project.

#### Run the Backend Stack with Docker
It is recommended to run the entire backend within Docker, as they are containerized during deployment.
A `docker-compose.yml` is provided at the root of the repository. To run, ensure the following:

- Ensure the `ASPNETCORE_Kestrel__Certificates__Default__Password:` fields for the IDP and API match your `dotnet dev-cert` password.
- Ensure your local `appsettings.development.json` in the `IDP` project is configured for a Discord Application
- Ensure your `environment.development.ts` on the frontend uses `https://localhost:8500` as the `oidcAuthority`

### Backend System Architecture
###### Source: [Righting Software](https://www.amazon.com/Righting-Software-Juval-L%C3%B6wy-ebook/dp/B0822XJZ48/ref=sr_1_1?dchild=1&keywords=righting+software&qid=1614284141&sr=8-1) by Juval Lowy

This system is designed using a layered approach. Layers encapsulate application responsibility and promote
- Consistency
- Scalability
- Fault Isolation
- Security
- Separation of Presentation from logic
- Availability
- Throughput
- Responsiveness
- Synchronization

#### Definition of Layers
##### Client
- Represents a unique interface where application services are exposed to a user or another system.

##### Business
- Encapsulates sequences in use cases and workflows.
    - Each manager is a collection of related use cases
- Engines encapsulate business rules
- Managers may use any number of engines
- Engines may be shared between managers

##### Resource Access
- May call into resources stored in external services
- Can be shared across engines and managers

##### Common/Utilities
- Common infrastructure across all layers of the application

#### Rules

Between layers, pass only
- Primitives
- Arrays of Primitives
- Data Contracts
- Arrays of Data Contracts

Data Contracts and Entities should not contain business logic, as this logic would cross layers
and break encapsulation.

1. _Clients_ **do not** call multiple _Managers_ in a single use case.
2. _Clients_ **do not** call _Engines_
3. _Services_ **do not** queue calls to more than one _Manager_ in a single use case.
4. _Engines_ **do not** receive queued calls.
5. _Resource Access_ components **do not** receive queued calls.
6. _Clients_ **do not** publish events.
7. _Engines_ **do not** publish events.
8. __Resource Access__ components **do not** publish events.
9. _Engines_, and _Data Access_ **do not** subscribe to events.
10. _Engines_ **never** call each other.
11. _Resource Access_ components **never** call each other.