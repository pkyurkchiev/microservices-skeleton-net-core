import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

// Models
import { IQuestionDetails } from '../../../_models/test-details.response.model';

// Services
import { TestService } from '../test.service';

@Component({
  selector: 'app-question-answers',
  templateUrl: './question-answers.component.html',
  styleUrls: ['./question-answers.component.scss']
})
export class QuestionAnswersComponent implements OnInit {
  @Input() question: IQuestionDetails;
  @Output() makrAnswerEmit = new EventEmitter<any>();
  errorReceived: boolean;
  testId: string;

  constructor(private testService: TestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.testId = params['id'];
    });
  }
  
  MarkAnswer(questionId: string, answerId: string) {
    this.errorReceived = false;
    this.testService.putAnswerMark(this.testId, questionId, answerId)
        .pipe(catchError((err) => this.handleError(err)))
        .subscribe(response => {
            this.makrAnswerEmit.emit({ questionId, answerId });
            console.log('Mark answer response');
          });
  }

  markTestFinish() {
    this.errorReceived = false;
    this.testService.putMarkTestFinish(this.testId)
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(response => {
        this.router.navigate(['tests/' + this.testId + '/results']);
      });
  };

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
