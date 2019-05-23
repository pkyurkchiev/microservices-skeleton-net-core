import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

// Models

// Services
import { ConfigurationService } from '../../_services/configuration.service';
import { ReportsService } from './reports.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {
  errorReceived: boolean;

  constructor(private reportsService: ReportsService, private configurationService: ConfigurationService) { }

  ngOnInit() {
    //if (this.configurationService.isReady) {
    //  this.getUsers();
    //} else {
    //  this.configurationService.settingsLoaded$.subscribe(x => {
    //    this.getUsers();
    //  });
    //}
  }

  //getUsers() {
  //  this.errorReceived = false;
  //  this.usersService.getUsers()
  //    .pipe(catchError((err) => this.handleError(err)))
  //    .subscribe(users => {
  //      this.users = users;
  //      this.oldUsers = this.users;
  //      console.log('users retrieved: ' + users.length);
  //    });
  //}

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
