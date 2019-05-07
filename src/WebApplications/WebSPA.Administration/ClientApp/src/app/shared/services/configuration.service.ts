import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IConfiguration } from '../models/configuration.model';
import { StorageService } from './storage.service';

import 'rxjs/add/operator/map';
import { Observable, Observer, Subject } from 'rxjs';


@Injectable()
export class ConfigurationService {
    serverSettings!: IConfiguration;
    // observable that is fired when settings are loaded from server
    private settingsLoadedSource = new Subject();
    settingsLoaded$ = this.settingsLoadedSource.asObservable();
    isReady: boolean = false;

    constructor(private http: HttpClient, private storageService: StorageService) { }

    load() {
        console.log(document.baseURI);
        const baseURI = document.baseURI!.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
      let url = `${baseURI}Home/Configuration`;
          this.http.get(url).subscribe<IConfiguration>((response: Response) => {
            console.log('server settings loaded');
            this.serverSettings = response.json();
            console.log(this.serverSettings);
            this.storageService.store('identityUrl', this.serverSettings.identityUrl);
            this.storageService.store('locationUrl', this.serverSettings.locationUrl);
            this.isReady = true;
            this.settingsLoadedSource.next();
        });
    }
}
