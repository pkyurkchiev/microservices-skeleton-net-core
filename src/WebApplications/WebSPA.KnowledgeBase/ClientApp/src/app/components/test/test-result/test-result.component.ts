import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

// Models
import { ITestResult } from '../../../_models/test-result.response.model';

// Services
import { ConfigurationService } from '../../../_services/configuration.service';
import { StorageService } from '../../../_services/storage.service';
import { TestService } from '../test.service';

@Component({
  selector: 'app-test-result',
  templateUrl: './test-result.component.html',
  styleUrls: ['./test-result.component.scss']
})
export class TestResultComponent implements OnInit {
  test: ITestResult;
  errorReceived: boolean;

  constructor(private testService: TestService, private configurationService: ConfigurationService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let testId = params['id'];
      if (this.configurationService.isReady) {
        this.getTestResult(testId);
      } else {
        this.configurationService.settingsLoaded$.subscribe(x => {
          this.getTestResult(testId);
        });
      }
    });
  }

  getTestResult(testId: string) {
    this.errorReceived = false;
    this.testService.getTestResult(testId)
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(test => {
        this.test = test.testDetailResults;
      });
  }

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
