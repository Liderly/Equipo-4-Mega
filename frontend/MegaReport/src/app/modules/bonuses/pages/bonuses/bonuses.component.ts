import { Component, OnInit } from '@angular/core';
import { BonusesService } from '../../services/bonuses.service';

@Component({
  selector: 'app-bonuses',
  templateUrl: './bonuses.component.html',
  styleUrls: ['./bonuses.component.css']
})
export class BonusesComponent implements OnInit {
  listTabulator$: Array<any> = [];

  constructor(private bonusesService : BonusesService) {}

  ngOnInit():void {
    this.bonusesService.getTabulator$().
    subscribe(resp => {
      this.listTabulator$ = resp
    })
  }

  updateBonus(Id:number, Puntos_minimos:string, Puntos_maximos:string, Monto:string){
    this.bonusesService.updateBonus$(Id, Puntos_minimos, Puntos_maximos, Monto)
    .subscribe(resp => {
    })
  }
}
