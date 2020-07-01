import { Injectable } from '@angular/core';

// Services
import { DataService } from '../../_services/data.service';
import { SecurityService } from '../../_services/security.service';
import { ConfigurationService } from '../../_services/configuration.service';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class HomeService {
  private knowledgeBaseUrl: string = '';

  constructor(private service: DataService, private securityService: SecurityService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady)
      this.knowledgeBaseUrl = this.configurationService.serverSettings.knowledgeBaseUrl;
    else
      this.configurationService.settingsLoaded$.subscribe(x => this.knowledgeBaseUrl = this.configurationService.serverSettings.knowledgeBaseUrl);
  }

  putMarkTestFinish(testId: string): Observable<boolean> {
    let url = this.knowledgeBaseUrl + '/api/v1/tests/' + testId + '/finish';

    return this.service.put(url, null).pipe(map((response: any) => {
      return true;
    }));
  };
}
