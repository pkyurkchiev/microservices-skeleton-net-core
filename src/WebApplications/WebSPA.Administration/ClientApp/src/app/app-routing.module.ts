import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Services
import { AuthGuardService } from './_services/auth-guard.service';

// Components
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { UsersComponent } from './components/users/users.component';
import { UsersDetailComponent } from './components/users/users-detail/users-detail.component';
import { UsersNewComponent } from './components/users/users-new/users-new.component';

import { ReportsComponent } from './components/reports/reports.component';
import { ReportsAnnualComponent } from './components/reports/reports-annual/reports-annual.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'users', component: UsersComponent, canActivate: [AuthGuardService] },
  { path: 'users/:id', component: UsersDetailComponent, canActivate: [AuthGuardService] },
  { path: 'user', component: UsersNewComponent, canActivate: [AuthGuardService] },
  { path: 'reports', component: ReportsComponent, canActivate: [AuthGuardService] },
  { path: 'reports-annual', component: ReportsAnnualComponent, canActivate: [AuthGuardService] },
  { path: 'page-not-found', component: PageNotFoundComponent },
  { path: '**', redirectTo: 'page-not-found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
