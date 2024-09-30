import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { TechniciansService } from '../../services/technicians.service';

@Component({
  selector: 'app-technicians-page',
  templateUrl: './technicians-page.component.html',
  styleUrls: ['./technicians-page.component.css']
})
export class TechniciansPageComponent implements OnInit, OnDestroy{
  listTechnicians$: Array<any> = [];
  public textSearch: string = '';

  constructor(private techniciansService: TechniciansService){}

  ngOnInit():void{
    this.techniciansService.getTechnicians$()
    .subscribe(resp => {
      this.listTechnicians$ = resp
    })
  }

  ngOnDestroy(): void {

  }

  searchTechnician(search:string){
    this.textSearch = search;
    
  }
}
