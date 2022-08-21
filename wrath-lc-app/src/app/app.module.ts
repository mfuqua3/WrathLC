import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {ClientModule} from "./client/client.module";
import {UtilsModule} from "./utils";
import {DataModule} from "./data";
import {CoreModule} from "./core";


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ClientModule,
    UtilsModule,
    DataModule,
    CoreModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
