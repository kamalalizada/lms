import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';
import { Login } from './components/login/login';
import { Register } from './components/register/register';

import { AppComponent } from './app.component';
import { UserComponent } from './components/user/user'; 
import { AppRoutingModule } from "./app-routing.module";

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    Login,
    Register
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
