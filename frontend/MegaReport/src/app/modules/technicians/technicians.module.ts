import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TechniciansRoutingModule } from './technicians-routing.module';
import { TechniciansPageComponent } from './pages/technicians-page/technicians-page.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    TechniciansPageComponent
  ],
  imports: [
    CommonModule,
    TechniciansRoutingModule,
    RouterModule
  ]
})
export class TechniciansModule { }
