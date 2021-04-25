import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccommodationsComponent } from './accommodations/accommodations.component';
import { PetsComponent } from './pets/pets.component';


const routes: Routes = [
  {path: 'accommodations', component: AccommodationsComponent},
  {path: 'pets', component: PetsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
