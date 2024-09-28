import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TechniciansPageComponent } from './pages/technicians-page/technicians-page.component';

const routes: Routes = [
  {
    path:'',
    component: TechniciansPageComponent 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TechniciansRoutingModule { }
