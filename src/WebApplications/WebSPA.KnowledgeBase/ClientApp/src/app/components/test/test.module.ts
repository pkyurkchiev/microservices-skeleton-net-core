import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modules
import { SharedModule } from '../../_modules/shared.module';
import { IconsModule } from '../../_modules/icons/icons.module';

// Components
import { TestComponent } from './test.component';
import { QuestionsNavMenuComponent } from './questions-nav-menu/questions-nav-menu.component';
import { QuestionAnswersComponent } from './question-answers/question-answers.component';
import { TestResultComponent } from './test-result/test-result.component';

// Services
import { TestService } from './test.service';

@NgModule({
  imports: [BrowserModule, SharedModule, IconsModule],
  declarations: [TestComponent, QuestionsNavMenuComponent, QuestionAnswersComponent, TestResultComponent],
  providers: [TestService]
})
export class TestModule { }
