import { Component } from '@angular/core';
import { workCrewsService } from '../../services/work-crews.service';

@Component({
  selector: 'app-work-crews',
  templateUrl: './work-crews.component.html',
  styleUrls: ['./work-crews.component.css']
})
export class WorkCrewsComponent {
  listWorkCrews$: Array<any> = [];

  constructor(private workCrewsService: workCrewsService){}

  ngOnInit():void{
    this.workCrewsService.getWorkCrews$()
    .subscribe(resp => {
      this.listWorkCrews$ = resp
    })
  }

  ngOnDestroy(): void {

  }
}
