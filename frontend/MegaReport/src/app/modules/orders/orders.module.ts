import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersPageComponent } from './pages/orders-page/orders-page.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    OrdersPageComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    RouterModule
  ]
})
export class OrdersModule { }
