import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modules
import { SharedModule } from '../../_modules/shared.module';

// Components
import { ReportsComponent } from './reports.component';
import { ReportsAnnualComponent } from './reports-annual/reports-annual.component';

// Services
import { ReportsService } from './reports.service';

@NgModule({
  imports: [BrowserModule, SharedModule],
  declarations: [ReportsComponent, ReportsAnnualComponent],
  providers: [ReportsService]
})
export class ReportsModule { }
