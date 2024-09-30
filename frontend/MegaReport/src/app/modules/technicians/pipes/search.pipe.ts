import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(technicians: Array<any>, search: string = ''): Array<any> {
   
    if(search.length === 0)
      return technicians.slice(0,10);
    const filteredTechnicians = technicians.filter(tech => tech.Numero_empleado.includes(search));

    return filteredTechnicians;
  }

}
