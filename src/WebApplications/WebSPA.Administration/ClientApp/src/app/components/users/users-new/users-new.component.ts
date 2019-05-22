import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

// Models
import { IUserNew } from '../../../_models/user-new.model';

// Services
import { UsersService } from '../users.service';

@Component({
  selector: 'app-users-new',
  templateUrl: './users-new.component.html',
  styleUrls: ['./users-new.component.scss']
})
export class UsersNewComponent implements OnInit {
  newUserForm: FormGroup;
  isUserProcessing: boolean;
  errorReceived: boolean;
  userNew: IUserNew;

  constructor(private usersService: UsersService, fb: FormBuilder, private router: Router) {
    this.userNew = {
      firstName: 'ss',
      lastName: 'ss',
      userName: 'ss',
      email: 'ss',
      roleNames: [''],
      password: 'ss'
    };

    this.newUserForm = fb.group({
      'firstName': [this.userNew.firstName, Validators.required],
      'lastName': [this.userNew.lastName, Validators.required],
      'userName': [this.userNew.userName, Validators.required],
      'email': [this.userNew.email, Validators.required],
      'password': [this.userNew.password, Validators.required]
    });
  }

  ngOnInit() { }

  submitForm(value: any) {
    this.userNew.firstName = this.newUserForm.controls['firstName'].value;
    this.userNew.lastName = this.newUserForm.controls['lastName'].value;
    this.userNew.userName = this.newUserForm.controls['userName'].value;
    this.userNew.email = this.newUserForm.controls['email'].value
    this.userNew.password = this.newUserForm.controls['password'].value;

    this.usersService.postUser(this.userNew)
      .pipe(catchError((errMessage) => {
        this.errorReceived = true;
        this.isUserProcessing = false;
        return Observable.throw(errMessage);
      }))
      .subscribe(res => {
        this.router.navigate(['users']);
      });
    this.errorReceived = false;
    this.isUserProcessing = true;
  }
}
