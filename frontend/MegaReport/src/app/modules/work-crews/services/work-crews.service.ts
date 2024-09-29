import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class workCrewsService {
  private readonly URL = environment.api;

  constructor(private http: HttpClient) { }

  getWorkCrews$(): Observable<any>{
    return this.http.get(`${this.URL}/Cuadrillas`)
  }
}
