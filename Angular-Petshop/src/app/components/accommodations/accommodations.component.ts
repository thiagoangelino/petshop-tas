import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Accommodation } from 'src/app/models/Accommodation';
import { AccommodationsService } from './accommodations.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-accommodations',
  templateUrl: './accommodations.component.html',
  styleUrls: ['./accommodations.component.css']
})
export class AccommodationsComponent implements OnInit {

  public title = 'Alojamentos'
  public accommodationSelected: Accommodation;
  public accommodationForm: FormGroup;
  public modalRef: BsModalRef;
  public mode: string; 

  public accommodations: Accommodation[];

 
  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private accommodationService: AccommodationsService) {

    this.createForm();
  }

  ngOnInit() {
    this.loadAccommodations();
  }

  loadAccommodations(){
    this.accommodationService.getAll().subscribe(
    (accommodations: Accommodation[]) => {
      this.accommodations = accommodations;
    },
    (error: any) => {console.error(error);}
    )
  }

  createForm(){
    this.accommodationForm = this.fb.group({
      id: 0,
      nome: ['', Validators.required],
      status: [3, Validators.required],
      petId: [0, Validators.required]      
    });
  }

  saveAccommodation(accommodation: Accommodation){
    (accommodation.id === 0) ? this.mode = 'post' : this.mode = 'put';

    this.accommodationService[this.mode](accommodation).subscribe(
      (retorno: Accommodation) => {
        console.log(retorno);
        this.loadAccommodations();
      },
      (error: any) => {console.log(error)}
    )
  }

  submitAccommodation(){
    this.saveAccommodation(this.accommodationForm.value);
    this.goBack();
  }

  selectAccommodation(accommodation: Accommodation){
    this.accommodationSelected = accommodation;
    this.accommodationForm.patchValue(accommodation);    
  }

  newAccommodation(){
    this.accommodationSelected = new Accommodation;
    this.accommodationForm.patchValue(this.accommodationSelected);
  }

  goBack(){
    this.accommodationSelected = null;
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

}
