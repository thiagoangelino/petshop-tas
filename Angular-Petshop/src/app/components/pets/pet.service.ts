import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pet } from 'src/app/models/Pet';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})


export class PetService {

    baseUrl = `${environment.mainUrl}/api/pet`;

constructor(private http: HttpClient) {
 }

getAll(): Observable<Pet[]>{
    return this.http.get<Pet[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Pet>{
    return this.http.get<Pet>(`${this.baseUrl}/${id}`);
  }

  post(pet: Pet){
    return this.http.post(`${this.baseUrl}`, pet);
  }

  put(pet: Pet){
    return this.http.put(`${this.baseUrl}/${pet.id}`, pet);
  }

  delete(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
