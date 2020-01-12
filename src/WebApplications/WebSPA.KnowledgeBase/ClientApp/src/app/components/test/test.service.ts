import { Injectable } from '@angular/core';

// Models
import { ITestResponse, ITest } from '../../_models/test.response.model';

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

  getTest(): Observable<ITestResponse> {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/users/' + '1701327001';

    return this.service.get(url).pipe(map((response: any) => {
      return response;
    }));
  }

  //getUser(id: string): Observable<IUserDetail> {
  //  let url = this.identityUrl + '/api/v1/users/' + id;

  //  return this.service.get(url).pipe(map((response: any) => {
  //    return response;
  //  }));
  //}

  putAnswerMark(testId: string, questionId: string, answerId): Observable<boolean> {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/' + testId + '/questions/' + questionId + '/answers/' + answerId + '/mark';

    return this.service.put(url, null).pipe(map((response: any) => {
      return true;
    }));
  }
}
