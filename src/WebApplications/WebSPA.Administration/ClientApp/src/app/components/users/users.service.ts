import { Injectable } from '@angular/core';
//import { Response } from '@angular/http';

// Models
import { IUser } from '../../_models/user.model';
import { IUserDetail } from '../../_models/user-detail.model';

// Services
import { DataService } from '../../_services/data.service';
import { SecurityService } from '../../_services/security.service';
import { ConfigurationService } from '../../_services/configuration.service';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class UsersService {
  private identityUrl: string = '';
  user: IUser;

  constructor(private service: DataService, private securityService: SecurityService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady)
      this.identityUrl = this.configurationService.serverSettings.identityUrl;
    else
      this.configurationService.settingsLoaded$.subscribe(x => this.identityUrl = this.configurationService.serverSettings.identityUrl);

  }

  getUsers(): Observable<IUser[]> {
    let url = this.identityUrl + '/api/v1/users';

    return this.service.get(url).pipe(map((response: any) => {
      return response;
    }));
  }

  getUser(id: string): Observable<IUserDetail> {
    let url = this.identityUrl + '/api/v1/users/' + id;

    return this.service.get(url).pipe(map((response: any) => {
      return response;
    }));
  }

  postUser(user): Observable<boolean> {
    let url = this.identityUrl + '/api/v1/users';
    this.user = user;
    return this.service.post(url, user).pipe(map((response: any) => {
      return true;
    }));
  }
}
