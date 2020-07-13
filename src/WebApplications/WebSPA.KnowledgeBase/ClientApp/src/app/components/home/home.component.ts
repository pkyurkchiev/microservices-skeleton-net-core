import { Component, OnInit } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

// Models
import { ITest } from '../../_models/test.response.model';

// Services
import { ConfigurationService } from '../../_services/configuration.service';
import { TestService } from '../test/test.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  tests: Array<ITest>;
  authenticated: boolean = false;
  errorReceived: boolean;

  constructor(private testService: TestService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.getTests();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.getTests();
      });
    }
  }

  ngOnInit() { }

  getTests() {
    this.errorReceived = false;
    this.testService.getTests()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(response => {
        this.tests = response.tests;
        console.log('test retrieved');
      });
  }

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
