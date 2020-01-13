import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

// Models
import { ITestResponse, IQuestion, IAnswer } from '../../_models/test.response.model';

// Services
import { ConfigurationService } from '../../_services/configuration.service';
import { StorageService } from '../../_services/storage.service';
import { TestService } from './test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  private testResponse: ITestResponse;
  questions: Array<string>;
  question: IQuestion;
  errorReceived: boolean;

  constructor(private testService: TestService, private configurationService: ConfigurationService, private storageService: StorageService) { }

  ngOnInit() {
    if (this.configurationService.isReady) {
      this.getTest();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.getTest();
      });
    }
  }

  getTest() {
    this.errorReceived = false;
    this.testService.getTest()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(test => {
        this.testResponse = test;
        this.storageService.store("testId", test.testDetails.id);
        this.questions = test.testDetails.questionViewModels.map(x => x.questionId);
        this.question = test.testDetails.questionViewModels[0];
        console.log('test retrieved');
      });
  }

  toggle($event) {
    this.question = this.testResponse.testDetails.questionViewModels.filter(function (item) {
      return item.questionId === $event.questionId;
    })[0];
  }

  makrAnswerEmit($event) {
    this.testResponse.testDetails.questionViewModels.forEach(function (question: IQuestion) {
      if (question.questionId === $event.questionId) {
        question.answerViewModels.forEach(function (answer: IAnswer) {
          if (answer.answerId === $event.answerId)
            answer.markAnswer = true;
          else
            answer.markAnswer = false;
        });
        return;
      }
    });
  }

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
