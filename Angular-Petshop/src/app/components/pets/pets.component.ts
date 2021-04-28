import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService, ModalDirective } from 'ngx-bootstrap/modal';
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
  public accommodationIdSelected: number;
  public pets: Pet[];
  
  @Input() petToRemove: number;

  items = ['item1', 'item2', 'item3', 'item4'];

  accommodationSelected(accommodation: number) {
    this.accommodationIdSelected = accommodation;
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
      petId: '',
      petName: ['', Validators.required],
      petOwnerName: ['', Validators.required],
      petOwnerAddress: ['', Validators.required],
      petOwnerPhone: ['', Validators.required],
      petCause: ['',Validators.required],
      petHeaulthState: [0],
      accommodationId: [0,Validators.required]
    });
  }

  savePet(pet: Pet){
    
    (pet.petId === 0) ? this.mode = 'post' : this.mode = 'put';

    pet.accommodationId = this.accommodationIdSelected;


    this.petService[this.mode](pet).subscribe(
      (retorno: Pet) => {
        console.log(retorno);
        this.loadPets();
      },
      (error: any) => {console.log(error)}
    )
    
    this.goBack();
  }

  submitPet(){
    this.savePet(this.petForm.value);
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

  deletePet(id: number){
    this.petService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.loadPets();
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  goBack(){
    this.petSelected = null;
  }

  openModal(template: TemplateRef<any>, pet: Pet){
    this.modalRef = this.modalService.show(template);
  }

  openModalConfirm(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirmDelete(): void {
    this.deletePet(this.petToRemove);
    this.modalRef.hide();
  }
 
  decline(): void {
    this.modalRef.hide();
  }
}
