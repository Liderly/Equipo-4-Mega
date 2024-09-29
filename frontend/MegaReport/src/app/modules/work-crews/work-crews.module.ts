import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkCrewsRoutingModule } from './work-crews-routing.module';
import { WorkCrewsComponent } from './pages/work-crews/work-crews.component';


@NgModule({
  declarations: [
    WorkCrewsComponent
  ],
  imports: [
    CommonModule,
    WorkCrewsRoutingModule
  ]
})
export class WorkCrewsModule { }
