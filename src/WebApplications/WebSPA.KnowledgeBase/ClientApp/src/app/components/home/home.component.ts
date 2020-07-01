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

  constructor(private securityService: SecurityService) {

  }

  ngOnInit() { }
    
}
