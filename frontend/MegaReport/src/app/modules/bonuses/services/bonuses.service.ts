import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class BonusesService {
  private readonly URL = environment.api;

  constructor(private http: HttpClient) { }

  getTabulator$(): Observable<any>{
    return this.http.get(`${this.URL}/Tabulator`)
  }

  updateBonus$(Id:number, Puntos_minimos:string, Puntos_maximos:string, Monto:string):Observable<any>{
    const body = {
      Id,
      Puntos_minimos,
      Puntos_maximos,
      Monto
    }
    return this.http.put(`${this.URL}/UpdatePuntos`, body)
  }
}
