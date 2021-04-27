import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Accommodation } from 'src/app/models/Accommodation';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})


export class AccommodationsService {
  
  baseUrl = `${environment.mainUrl}/api/accommodation`;
  
  constructor(private http: HttpClient) {
  }
  
  getAll(): Observable<Accommodation[]>{
    return this.http.get<Accommodation[]>(`${this.baseUrl}`);
  }
  
  getById(id: number): Observable<Accommodation>{
    return this.http.get<Accommodation>(`${this.baseUrl}/${id}`);
  }

  getByStatus(state: number): Observable<Accommodation[]>{
    return this.http.get<Accommodation[]>(`${this.baseUrl}/state/${state}`);
  }
  
  post(accommodation: Accommodation){
    return this.http.post(`${this.baseUrl}`, accommodation);
  }
  
  put(accommodation: Accommodation){
    return this.http.put(`${this.baseUrl}/${accommodation.id}`, accommodation);
  }
  
  delete(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
  
}
