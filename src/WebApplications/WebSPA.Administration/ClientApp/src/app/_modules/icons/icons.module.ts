import { NgModule } from '@angular/core';

import { FeatherModule } from 'angular-feather';
import { Home, Users, BarChart2, Layers, FileText, PlusCircle } from 'angular-feather/icons';

// Select some icons (use an object, not an array)
const icons = {
  Home,
  Users,
  BarChart2,
  Layers,
  FileText,
  PlusCircle
};

@NgModule({
  imports: [
    FeatherModule.pick(icons)
  ],
  exports: [
    FeatherModule
  ]
})
export class IconsModule { }
