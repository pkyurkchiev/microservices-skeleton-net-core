import { Component, OnInit, OnChanges, Output, Input, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';

// Models
import { IIdentity } from '../../_models/identity.model';

// Services
import { SecurityService } from '../../_services/security.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  authenticated: boolean = false;
  private subscription: Subscription;
  private userName: string = '';

  constructor(private service: SecurityService) {

  }

  ngOnInit() {
    //this.subscription = this.service.authenticationChallenge$.subscribe(res => {
    //  this.authenticated = res;
    //  this.userName = this.service.UserData.email;
    //});

    //if (window.location.hash) {
    //  this.service.AuthorizedCallback();
    //}

    //console.log('identity component, checking authorized' + this.service.IsAuthorized);
    //this.authenticated = this.service.IsAuthorized;

    //if (this.authenticated) {
    //  if (this.service.UserData)
    //    this.userName = this.service.UserData.email;
    //}
  }

  //logoutClicked(event: any) {
  //  event.preventDefault();
  //  console.log('Logout clicked');
  //  this.logout();
  //}

  //login() {
  //  this.service.Authorize();
  //}

  //logout() {
  //  //this.signalrService.stop();
  //  this.service.Logoff();
  //}
}
