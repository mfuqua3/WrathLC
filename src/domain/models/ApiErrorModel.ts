//Based on Standardized API Error Model from .NET 6 Boilerplate
//https://github.com/mfuqua3/DotNet6-Boilerplate/blob/master/Utility/DataContracts/Models/ExceptionModel.cs
export interface ApiErrorModel {
    status: string;
    statusCode: number;
    message: string;
    stackTrace?: string;
}
