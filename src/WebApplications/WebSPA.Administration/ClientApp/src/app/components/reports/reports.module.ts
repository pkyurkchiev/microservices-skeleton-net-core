import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modules
import { SharedModule } from '../../_modules/shared.module';

// Components
import { ReportsComponent } from './reports.component';

// Services
import { ReportsService } from './reports.service';

@NgModule({
  imports: [BrowserModule, SharedModule],
  declarations: [ReportsComponent],
  providers: [ReportsService]
})
export class ReportsModule { }
