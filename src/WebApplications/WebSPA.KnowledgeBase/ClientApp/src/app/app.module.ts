import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SharedModule } from './_modules/shared.module';
import { TestModule } from './components/test/test.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    // Only module that app module loads
    SharedModule.forRoot(),
    TestModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
