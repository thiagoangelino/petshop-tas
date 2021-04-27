import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Pet } from 'src/app/models/Pet';
import { PetService } from './pet.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.css']
})
export class PetsComponent implements OnInit {

  public title = 'Pets'
  public petSelected: Pet;
  public petForm: FormGroup;
  public modalRef: BsModalRef;
  public mode: string;

  public pets: Pet[];

  items = ['item1', 'item2', 'item3', 'item4'];

  accommodationSelected(accommodation: number) {
    this.petSelected.accommodationId = accommodation;
    console.log(this.petSelected);
  }
  
 
  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private petService: PetService) {

    this.createForm();
    
  }

  ngOnInit() {
    this.loadPets();
  }

  loadPets(){
    this.petService.getAll().subscribe(
    (pets: Pet[]) => {
      this.pets = pets;
    },
    (error: any) => {console.error(error);}
    )
  }

  createForm(){
    this.petForm = this.fb.group({
      petId: 0,
      petName: ['', Validators.required],
      petOwnerName: ['', Validators.required],
      petOwnerAddress: ['', Validators.required],
      petOwnerPhone: ['', Validators.required],
      petCause: [0,Validators.required],
      petHeaulthState: [0],
      accommodationId: [0,Validators.required]
    });
  }

  savePet(pet: Pet){
    (pet.petId === 0) ? this.mode = 'post' : this.mode = 'put';

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
    // this.goBack();
  }
  savePetSelected(){
    console.log(this.petSelected);
    this.savePet(this.petSelected);
    this.goBack();
  }

  selectPet(pet: Pet){
    this.petSelected = pet;
    this.petForm.patchValue(pet);  
  }

  newPet(){
    this.petSelected = new Pet;
    this.petForm.patchValue(this.petSelected);
  }

  goBack(){
    this.petSelected = null;
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

}
