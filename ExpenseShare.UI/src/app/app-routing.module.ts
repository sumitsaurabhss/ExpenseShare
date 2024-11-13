import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { UserDetailsComponent } from './components/members/user-details/user-details.component';
import { GroupDetailsComponent } from './components/members/group-details/group-details.component';
import { CreateGroupComponent } from './components/members/create-group/create-group.component';
import { ExpenseDetailsComponent } from './components/members/expense-details/expense-details.component';
import { CreateExpenseComponent } from './components/members/create-expense/create-expense.component';
import { authGuard } from './guards/auth.guard';
import { adminGuard } from './guards/admin.guard';
import { HomeComponent } from './components/admin/home/home.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'user-details', component: UserDetailsComponent, canActivate: [authGuard] },
  { path: 'group-details/:id', component: GroupDetailsComponent, canActivate: [authGuard] },
  { path: 'create-group', component: CreateGroupComponent, canActivate: [authGuard] },
  { path: 'expense-details/:id', component: ExpenseDetailsComponent, canActivate: [authGuard] },
  { path: 'create-expense/:groupId', component: CreateExpenseComponent, canActivate: [authGuard] },
  { path: 'admin', component: HomeComponent, canActivate: [authGuard, adminGuard] },
  { path: '**', redirectTo: '', pathMatch: 'full' } // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
