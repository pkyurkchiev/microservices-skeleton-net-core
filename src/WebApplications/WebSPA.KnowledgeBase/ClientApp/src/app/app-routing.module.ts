import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Services
import { AuthGuardService } from './_services/auth-guard.service';

// Components
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { TestComponent } from './components/test/test.component';
import { TestResultComponent } from './components/test/test-result/test-result.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'tests/:id', component: TestComponent, canActivate: [AuthGuardService] },
  { path: 'tests/:id/results', component: TestResultComponent, canActivate: [AuthGuardService] },
  { path: 'page-not-found', component: PageNotFoundComponent },
  { path: '**', redirectTo: 'page-not-found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
