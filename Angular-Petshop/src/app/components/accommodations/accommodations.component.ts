import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
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

  
  public accommodationSelected: Accommodation;
  public accommodationForm: FormGroup;
  public modalRef: BsModalRef;
  public mode: string;
  public modeGetAcm: string;

  @Input() stateAcm = 3; // 0 - free | 1 - busy | 2 - waiting | bigger than 2 - indeterminate

  @Input() petIdSelected: number;

  @Input() title = 'Alojamentos'

  @Output() newItemEvent = new EventEmitter<string>();
  
  acoommodationSelected(value: string) {
    this.newItemEvent.emit(value);
  } 

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
    if(this.stateAcm < 3){
      this.accommodationService.getByStatus(this.stateAcm).subscribe(
        (accommodations: Accommodation[]) => {
          this.accommodations = accommodations;
        },
        (error: any) => {console.error(error);}
        )

    }
    else{
      this.accommodationService.getAll().subscribe(
        (accommodations: Accommodation[]) => {
          this.accommodations = accommodations;
        },
        (error: any) => {console.error(error);}
        )
    }
    
  }

  createForm(){
    this.accommodationForm = this.fb.group({
      id: 0,
      acommodationName: [''],
      accommodationState: [3, Validators.required],
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
    // this.accommodationForm.get("nomeAccommodation").setValue(this.accommodationSelected, { emitEvent: false });
    this.accommodationForm.get("petId").setValue(this.petIdSelected, { emitEvent: false });
    this.saveAccommodation(this.accommodationForm.value);
    // this.goBack();
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
