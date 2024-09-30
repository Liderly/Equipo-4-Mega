import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class TechniciansService {
  private readonly URL = environment.api;

  constructor(private http: HttpClient) { }

  getTechnicians$(): Observable<any>{
    return this.http.get(`${this.URL}/Tecnicos`)
  }

  setTechnicians$(Numero_empleado: string, Nombre: string, Apellido_p: string, Apellido_m: string, CuadrillaId:string): Observable<any>{
    const body = {
      Numero_empleado,
      Nombre,
      Apellido_p,
      Apellido_m,
      CuadrillaId,
    }
    window.location.reload();
    return this.http.post(`${this.URL}/Tecnicos`, body)
  }
}
