import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BonusesRoutingModule } from './bonuses-routing.module';
import { BonusesComponent } from './pages/bonuses/bonuses.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    BonusesComponent
  ],
  imports: [
    CommonModule,
    BonusesRoutingModule,
    RouterModule,
    FormsModule
  ]
})
export class BonusesModule { }
