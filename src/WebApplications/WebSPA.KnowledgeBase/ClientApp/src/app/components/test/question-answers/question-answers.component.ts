import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

// Models
import { IQuestion } from '../../../_models/test.response.model';

// Services
import { TestService } from '../test.service';
import { StorageService } from '../../../_services/storage.service';

@Component({
  selector: 'app-question-answers',
  templateUrl: './question-answers.component.html',
  styleUrls: ['./question-answers.component.scss']
})
export class QuestionAnswersComponent implements OnInit {
  @Input() question: IQuestion;
  errorReceived: boolean;

  constructor(private testService: TestService, private storageService: StorageService) { }

  ngOnInit() { }

  
  MarkAnswer(questionId: string, answerId: string) {
    this.errorReceived = false;
    this.testService.putAnswerMark(this.storageService.retrieve("testId"), questionId, answerId)
        .pipe(catchError((err) => this.handleError(err)))
        .subscribe(response => {
          console.log('Mark answer response');
        });
  }

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
