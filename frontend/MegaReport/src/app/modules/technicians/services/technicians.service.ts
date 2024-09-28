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
}
