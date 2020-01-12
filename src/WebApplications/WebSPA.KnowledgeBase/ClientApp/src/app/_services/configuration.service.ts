import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Subject } from 'rxjs';

import { IConfiguration } from '../_models/configuration.model';
import { StorageService } from './storage.service';

@Injectable()
export class ConfigurationService {
  serverSettings: IConfiguration;
  // observable that is fired when settings are loaded from server
  private settingsLoadedSource = new Subject();
  settingsLoaded$ = this.settingsLoadedSource.asObservable();
  isReady: boolean = false;

  constructor(private http: HttpClient, private storageService: StorageService) { }

  load() {
    const baseURI = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
    let url = `${baseURI}api/Configurations/Main`;
    this.http.get(url).subscribe((response) => {
      console.log('server settings loaded');
      this.serverSettings = response as IConfiguration;
      console.log(this.serverSettings);
      this.storageService.store('identityUrl', this.serverSettings.identityUrl);
      this.storageService.store('knowledgeBaseUrl', this.serverSettings.knowledgeBaseUrl);
      this.isReady = true;
      this.settingsLoadedSource.next();
    });
  }
}
