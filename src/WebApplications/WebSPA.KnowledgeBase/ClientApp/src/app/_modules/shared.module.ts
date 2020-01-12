import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { IconsModule } from './icons/icons.module';

// Services
import { DataService } from '../_services/data.service';
import { ConfigurationService } from '../_services/configuration.service';
import { StorageService } from '../_services/storage.service';
import { SecurityService } from '../_services/security.service';
import { AuthGuardService } from '../_services/auth-guard.service';

// Components
import { HomeComponent } from '../components/home/home.component';
import { PageNotFoundComponent } from '../components/page-not-found/page-not-found.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        //NgbModule.forRoot(),
        // No need to export as these modules don't expose any components/directive etc'
        HttpClientModule,
        IconsModule
    ],
    declarations: [
        //Pager,
        //Header,
      HomeComponent,
      PageNotFoundComponent,
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
      HomeComponent,
      PageNotFoundComponent,
        //UppercasePipe
    ]
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [
                DataService,
                SecurityService,
                ConfigurationService,
                StorageService,
                AuthGuardService
            ]
        };
    }
}
