import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modules
import { SharedModule } from '../../_modules/shared.module';
import { IconsModule } from '../../_modules/icons/icons.module';

// Components
import { UsersComponent } from './users.component';
import { UsersNewComponent } from './users-new/users-new.component';
import { UsersDetailComponent } from './users-detail/users-detail.component';

// Services
import { UsersService } from './users.service';

@NgModule({
  imports: [BrowserModule, SharedModule, IconsModule],
  declarations: [UsersComponent, UsersNewComponent, UsersDetailComponent],
  providers: [UsersService]
})
export class UsersModule { }
