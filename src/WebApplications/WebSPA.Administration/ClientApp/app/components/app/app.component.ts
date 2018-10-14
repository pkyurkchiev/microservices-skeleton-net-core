import { Component, OnInit } from '@angular/core';

//import { ConfigurationService } from '../../shared/services/configuration.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
   // constructor(private configurationService: ConfigurationService) { }

    ngOnInit() {
        console.log('app on init');

        //Get configuration from server environment variables:
        console.log('configuration');
        //this.configurationService.load();
    }
}
