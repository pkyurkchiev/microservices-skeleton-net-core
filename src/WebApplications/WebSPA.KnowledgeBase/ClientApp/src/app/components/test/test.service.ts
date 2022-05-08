import { Injectable } from '@angular/core';

// Models
import { ITestResponse } from '../../_models/test.response.model';
import { ITestDetailsResponse } from '../../_models/test-details.response.model';
import { ITestResultResponse } from '../../_models/test-result.response.model';

// Services
import { DataService } from '../../_services/data.service';
import { SecurityService } from '../../_services/security.service';
import { ConfigurationService } from '../../_services/configuration.service';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Guid } from '../../_models/guid';

@Injectable()
export class TestService {
  private knowledgeBaseUrl: string = '';

  constructor(private service: DataService, private securityService: SecurityService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady)
      this.knowledgeBaseUrl = this.configurationService.serverSettings.knowledgeBaseUrl;
    else
      this.configurationService.settingsLoaded$.subscribe(x => this.knowledgeBaseUrl = this.configurationService.serverSettings.knowledgeBaseUrl);
  }

  getTests(): Observable<ITestResponse>  {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/';

    return this.service.get(url).pipe(map((response: any) => {
      return response;
    }));
  }

  getTest(id: string): Observable<ITestDetailsResponse> {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/' + id;

    return this.service.get(url).pipe(map((response: any) => {
      return response;
    }));
  }

  putAnswerMark(testId: string, questionId: string, answerId): Observable<boolean> {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/' + testId + '/questions/' + questionId + '/answers/' + answerId + '/mark';

    return this.service.put(url, null).pipe(map((response: any) => {
      return true;
    }));
  }

  getTestResult(id: string): Observable<ITestResultResponse> {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/' + id + '/results';
    return this.service.get(url).pipe(map((response: any) => {
      return response;
    }));
  }

  putMarkTestFinish(testId: string): Observable<boolean> {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/' + testId + '/finish';

    return this.service.put(url, null).pipe(map((response: any) => {
      return true;
    }));
  };
}
