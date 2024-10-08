import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private readonly URL = environment.api

  constructor(private http: HttpClient) { }

  getOrders$(id:number): Observable<any>{
    return this.http.get(`${this.URL}/Ordenes?id=${id}`)
  }

  getTotalAmount$(id:number): Observable<any>{
    return this.http.get(`${this.URL}/MontoxTecnico?TecnicoId=${id}`)
  }
}
