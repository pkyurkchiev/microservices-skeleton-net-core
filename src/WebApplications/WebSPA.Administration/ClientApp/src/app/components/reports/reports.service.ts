import { Injectable } from '@angular/core';

// Models

// Services
import { DataService } from '../../_services/data.service';
import { SecurityService } from '../../_services/security.service';
import { ConfigurationService } from '../../_services/configuration.service';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ReportsService {
  private identityUrl: string = '';

  constructor(private service: DataService, private securityService: SecurityService, private configurationService: ConfigurationService) {
    //if (this.configurationService.isReady)
    //  this.identityUrl = this.configurationService.serverSettings.identityUrl;
    //else
    //  this.configurationService.settingsLoaded$.subscribe(x => this.identityUrl = this.configurationService.serverSettings.identityUrl);

  }

  //getUsers(): Observable<IUser[]> {
  //  let url = this.identityUrl + '/api/v1/users';

  //  return this.service.get(url).pipe(map((response: any) => {
  //    return response;
  //  }));
  //}
}
