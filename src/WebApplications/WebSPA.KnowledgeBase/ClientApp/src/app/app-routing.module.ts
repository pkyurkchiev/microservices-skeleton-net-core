import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Services
import { AuthGuardService } from './_services/auth-guard.service';

// Components
import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { TestComponent } from './components/test/test.component';
//import { QuestionAnswersComponent } from './components/test/question-answers/question-answers.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'test', component: TestComponent, canActivate: [AuthGuardService] },
  //{ path: 'question/:id', component: QuestionAnswersComponent, canActivate: [AuthGuardService] },
  { path: 'page-not-found', component: PageNotFoundComponent },
  { path: '**', redirectTo: 'page-not-found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
