import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {
  mainMenu: Array<any> = []

  ngOnInit(): void {
    this.mainMenu = [
      {
        name: 'Técnicos',
        icon: 'bi bi-person-fill-gear',
        router: ['/technicians']
      },
      {
        name: 'Cuadrillas',
        icon: 'bi bi-people-fill',
        router: ['']
      },
      {
        name: 'Ajustes',
        icon: 'bi bi-gear-fill',
        router: ['']
      },
      {
        name: 'Salir',
        icon: 'bi bi-box-arrow-in-left',
        router: ['']
      }
    ]
  }

}
