import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BonusesComponent } from './pages/bonuses/bonuses.component';

const routes: Routes = [
  {
    path: '',
    component: BonusesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BonusesRoutingModule { }
