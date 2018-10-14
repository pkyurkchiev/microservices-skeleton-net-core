import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule, JsonpModule } from '@angular/http';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

// Services
import { ConfigurationService } from './services/configuration.service';
import { StorageService } from './services/storage.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        //NgbModule.forRoot(),
        // No need to export as these modules don't expose any components/directive etc'
        HttpModule,
        JsonpModule
    ],
    declarations: [
        //Pager,
        //Header,
        //Identity,
        //PageNotFoundComponent,
        //UppercasePipe
    ],
    exports: [
        // Modules
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        //NgbModule,
        // Providers, Components, directive, pipes
        //Pager,
        //Header,
        //Identity,
        //PageNotFoundComponent,
        //UppercasePipe
    ]
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [
                // Providers
                //DataService,
                //BasketWrapperService,
                //SecurityService,
                ConfigurationService,
                StorageService
                //SignalrService
            ]
        };
    }
}