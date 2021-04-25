import { Component, OnInit } from '@angular/core';
import { Accommodation } from 'src/app/models/Accommodation';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public accommodations: Accommodation[];

  constructor() { }

  ngOnInit() {
  }

}
