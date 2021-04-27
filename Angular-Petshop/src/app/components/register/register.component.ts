import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Pet } from 'src/app/models/Pet';
import { AccommodationsComponent } from '../accommodations/accommodations.component';
import { PetService } from '../pets/pet.service';
import { PetsComponent } from '../pets/pets.component';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  public petsComponent: PetsComponent;
  public accommodationsComponent: AccommodationsComponent;
  
  public test: any;
  public petSelected: Pet;
  public petForm: FormGroup;
  public pet: Pet;
  public mode: string;

  public pets: Pet[];
  
  
  constructor(private fb: FormBuilder,
    private petService: RegisterService) {
      
      this.createForm();
      

    }
    
    ngOnInit() {
      this.loadPetById(1);
      this.selectPet(this.pet);
      console.log(this.pet);
      console.log('this.pets');
    }
    
    loadPets(){
      this.petService.getAllPets().subscribe(
        (pets: Pet[]) => {
          this.pets = pets;
        },
        (error: any) => {console.error(error);
          }
        )
      }

      loadPetById(id: number){
        this.petService.getPetById(id).subscribe(
          (pet: Pet) => {
            this.pet = pet;
          },
          (error: any) => {console.error(error);
            console.log('erros');
            }
          )
      }

      selectPet(pet: Pet){
        this.petSelected = pet;
        this.petForm.patchValue(pet);  
      }
      
      createForm(){
        this.petForm = this.fb.group({
          id: 0,
          name: ['', Validators.required],
          ownerName: ['', Validators.required],
          ownerAddress: ['', Validators.required],
          ownerPhone: ['', Validators.required],
          cause: [0,Validators.required],
          hState: [0,Validators.required],
          accomodationPetId: [0, Validators.required]
        });
      }

      savePet(pet: Pet){
        (pet.id === 0) ? this.mode = 'post' : this.mode = 'put';
    
        this.petService[this.mode](pet).subscribe(
          (retorno: Pet) => {
            console.log(retorno);
            this.loadPets();
          },
          (error: any) => {console.log(error)}
        )
      }
      submitPet(){
        this.savePet(this.petForm.value);
      }
    
}