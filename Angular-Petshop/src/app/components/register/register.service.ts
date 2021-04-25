import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Accommodation } from 'src/app/models/Accommodation';
import { Pet } from 'src/app/models/Pet';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})


export class RegisterService {
  
  baseUrl = `${environment.mainUrl}/api/pet`;
  
  constructor(private http: HttpClient) {
  }
  

  //PETS
  getAllPets(): Observable<Pet[]>{
    return this.http.get<Pet[]>(`${this.baseUrl}`);
  }  
  getPetById(id: number): Observable<Pet>{
    return this.http.get<Pet>(`${this.baseUrl}/${id}`);
  }  
  postPet(pet: Pet){
    return this.http.post(`${this.baseUrl}`, pet);
  }  
  putPet(pet: Pet){
    return this.http.put(`${this.baseUrl}/${pet.id}`, pet);
  }  
  deletePet(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  //ACCOMMODATIONS
  getAllAccommodations(): Observable<Accommodation[]>{
    return this.http.get<Accommodation[]>(`${this.baseUrl}`);
  }  
  getAccommodationsById(id: number): Observable<Accommodation>{
    return this.http.get<Accommodation>(`${this.baseUrl}/${id}`);
  }  
  postAccommodation(accommodation: Accommodation){
    return this.http.post(`${this.baseUrl}`, accommodation);
  } 
  putAccommodation(accommodation: Accommodation){
    return this.http.put(`${this.baseUrl}/${accommodation.id}`, accommodation);
  }  
  deleteAccommodation(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  
}
