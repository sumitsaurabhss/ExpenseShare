import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { AppComponent } from './app.component';
import { TokenInterceptor } from './interceptors/token.interceptor';

import { NavbarComponent } from './layouts/navbar/navbar.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { LoginComponent } from './components/auth/login/login.component';
import { UserDetailsComponent } from './components/members/user-details/user-details.component';
import { ExpenseDetailsComponent } from './components/members/expense-details/expense-details.component';
import { GroupDetailsComponent } from './components/members/group-details/group-details.component';
import { CreateGroupComponent } from './components/members/create-group/create-group.component';
import { CreateExpenseComponent } from './components/members/create-expense/create-expense.component';
import { HomeComponent } from './components/admin/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    LoginComponent,
    UserDetailsComponent,
    ExpenseDetailsComponent,
    GroupDetailsComponent,
    CreateGroupComponent,
    CreateExpenseComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
