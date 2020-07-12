import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

// Models
import { ITestDetailsResponse, IQuestionDetails, IAnswerDetails } from '../../_models/test-details.response.model';

// Services
import { ConfigurationService } from '../../_services/configuration.service';
import { TestService } from './test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  private testResponse: ITestDetailsResponse;
  questions: Array<string>;
  question: IQuestionDetails;
  errorReceived: boolean;

  constructor(private testService: TestService, private configurationService: ConfigurationService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let testId = params['id'];
      if (this.configurationService.isReady) {
        this.getTest(testId);
      } else {
        this.configurationService.settingsLoaded$.subscribe(x => {
          this.getTest(testId);
        });
      }
    });
  }

  getTest(id: string) {
    this.errorReceived = false;
    this.testService.getTest(id)
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(test => {
        this.testResponse = test;
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
    this.testResponse.testDetails.questionViewModels.forEach(function (question: IQuestionDetails) {
      if (question.questionId === $event.questionId) {
        question.answerViewModels.forEach(function (answer: IAnswerDetails) {
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
