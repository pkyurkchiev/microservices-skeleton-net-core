import { Component } from '@angular/core';
import { Subscription } from 'rxjs';

import { SecurityService } from './shared/services/security.service';
import { ConfigurationService } from './shared/services/configuration.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';

  Authenticated: boolean = false;
  subscription: Subscription;

  constructor(private securityService: SecurityService, 
    private configurationService: ConfigurationService) {
    this.Authenticated = this.securityService.IsAuthorized;
  }

  ngOnInit() {
    console.log('app on init');
    this.subscription = this.securityService.authenticationChallenge$.subscribe(res => this.Authenticated = res);

    //Get configuration from server environment variables:
    console.log('configuration');
    this.configurationService.load();
  }
}
