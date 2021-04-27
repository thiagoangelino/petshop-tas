import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';
import { HomeComponent } from './components/home/home.component';
import { PetsComponent } from './components/pets/pets.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  {path:'', redirectTo:'pets', pathMatch:'full'},
  {path:'home', component: HomeComponent},
  {path:'accommodations', component: AccommodationsComponent},
  {path:'pets', component: PetsComponent},
  {path:'register', component: RegisterComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
