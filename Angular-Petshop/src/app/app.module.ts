import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PetsComponent } from './components/pets/pets.component';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';
import { HomeComponent } from './components/home/home.component';
import { NavComponent } from './components/nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from  '@angular/material/sidenav';
import { MatButtonModule } from  '@angular/material/button';
import {MatListModule} from  '@angular/material/list';
import {MatIconModule } from  '@angular/material/icon';
import {MatToolbarModule } from  '@angular/material/toolbar';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { MatTableModule } from '@angular/material/table' 
import { TitleComponent } from './components/title/title.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AlunosComponent } from './components/alunos/alunos.component';
import { ProfessoresComponent } from './components/professores/professores.component';
import { TituloComponent } from './titulo/titulo.component';

@NgModule({
  declarations: [		
    AppComponent,
      PetsComponent,
      AccommodationsComponent,
      HomeComponent,
      NavComponent,
      TitleComponent,
      AlunosComponent,
      ProfessoresComponent,
      TituloComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    BsDropdownModule.forRoot(),
    MatTableModule,
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
