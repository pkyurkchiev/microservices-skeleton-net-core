import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

// Models
import { IUser } from '../../_models/user.model';

// Services
import { ConfigurationService } from '../../_services/configuration.service';
import { UsersService } from './users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  private oldUsers: IUser[];
  //private interval = null;
  errorReceived: boolean;

  users: IUser[];

  constructor(private usersService: UsersService, private configurationService: ConfigurationService) { }

  ngOnInit() {
    if (this.configurationService.isReady) {
      this.getUsers();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.getUsers();
      });
    }
  }

  getUsers() {
    this.errorReceived = false;
    this.usersService.getUsers()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(users => {
        this.users = users;
        this.oldUsers = this.users;
        console.log('users retrieved: ' + users.length);
      });
  }

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
