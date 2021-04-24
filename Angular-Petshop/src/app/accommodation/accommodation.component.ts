import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Accommodation } from '../models/Accommodation'
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccommodationService } from './accommodation.service';

@Component({
  selector: 'app-accommodation',
  templateUrl: './accommodation.component.html',
  styleUrls: ['./accommodation.component.css']
})
export class AccommodationComponent implements OnInit {

  public title = 'Acomodações';
  public accommodationSelected: Accommodation = new Accommodation;
  public accommodationForm!: FormGroup;
  public modalRef!: BsModalRef;
  public mode = 'post';

  public accommodations: Accommodation[] = [];

  constructor(private fb: FormBuilder,
                      private modalService: BsModalService,
                      private accommodationService: AccommodationService) {
      this.criateForm();
   }

  ngOnInit() {
    this.loadAccomodations();
  }

  criateForm(){
    this.accommodationForm = this.fb.group({
      id: 0,
      nome:['', Validators.required],
      status:[0, Validators.required]
    });
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  loadAccomodations(){
    this.accommodationService.getAll().subscribe(
      (accommodations: Accommodation[]) => {
        this.accommodations = accommodations;
      },
      (error: any) => {
        console.error(error);
      }
    )
  }

  saveAccomodation(accommodation: Accommodation){
    if(accommodation.id === 0) {
      this.accommodationService.post(accommodation).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.loadAccomodations();
        },
        (error: any) => {
          console.error(error);
        }
      )
    } else{
      this.accommodationService.put(accommodation).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.loadAccomodations();
        },
        (error: any) => {
          console.error(error);
        }
      )
    }
    
  }

  accommodationSubmit(){
    this.saveAccomodation(this.accommodationForm.value);
  }

  accommodationSelect(accommodation: Accommodation){
    this.accommodationSelected = accommodation;
    this.accommodationForm.patchValue(accommodation);
  }

  accommodationNew(){
    this.accommodationSelected = new Accommodation;
    this.accommodationForm.patchValue(this.accommodationSelected);
  }

  voltar(){
    this.accommodationSelected = new Accommodation;
  }

}
