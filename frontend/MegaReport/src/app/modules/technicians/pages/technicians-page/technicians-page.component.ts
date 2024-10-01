import { Component, OnDestroy, OnInit } from '@angular/core';
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

  addTechnician(nombres:string, apellidoPaterno:string, apellidoMaterno:string, cuadrilla: string, numeroEmpleado:string){
    this.techniciansService.setTechnicians$(numeroEmpleado,nombres,apellidoPaterno,apellidoMaterno,cuadrilla)
    .subscribe(resp => {
    })
  }

  updateTechnician(TecnicoId:number, Numero_Empleado:string, Nombre:string, Apellido_p:string, Apellido_m:string, CuadrillaId:string){
    this.techniciansService.updateTechnicians$(TecnicoId, Numero_Empleado, Nombre, Apellido_p, Apellido_m, CuadrillaId)
    .subscribe(resp => {
    })
  }
}
