import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'technicians',
    loadChildren: () => import(`../technicians/technicians.module`).then(m => m.TechniciansModule)
  },
  {
    path: 'orders',
    loadChildren: () => import(`../orders/orders.module`).then(m => m.OrdersModule)
  },
  {
    path: '**',
    redirectTo: '/technicians'
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
