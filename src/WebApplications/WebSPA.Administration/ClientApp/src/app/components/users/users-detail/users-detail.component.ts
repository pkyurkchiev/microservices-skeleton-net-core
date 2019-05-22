import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

// Models
import { IUserDetail } from '../../../_models/user-detail.model';

// Services
import { UsersService } from '../users.service';

@Component({
  selector: 'app-users-detail',
  templateUrl: './users-detail.component.html',
  styleUrls: ['./users-detail.component.scss']
})
export class UsersDetailComponent implements OnInit {
  public user: IUserDetail = <IUserDetail>{};

  constructor(private usersService: UsersService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let id = params['id']; // (+) converts string 'id' to a number
      this.getUser(id);
    });
  }

  getUser(id: string) {
    this.usersService.getUser(id).subscribe(user => {
      this.user = user;
      console.log('user retrieved: ' + user.id);
      console.log(this.user);
    });
  }
}
