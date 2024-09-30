import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TechniciansRoutingModule } from './technicians-routing.module';
import { TechniciansPageComponent } from './pages/technicians-page/technicians-page.component';
import { RouterModule } from '@angular/router';
import { SearchPipe } from './pipes/search.pipe';


@NgModule({
  declarations: [
    TechniciansPageComponent,
    SearchPipe
  ],
  imports: [
    CommonModule,
    TechniciansRoutingModule,
    RouterModule
  ]
})
export class TechniciansModule { }
