import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';
import { AlunosComponent } from './components/alunos/alunos.component';
import { HomeComponent } from './components/home/home.component';
import { PetsComponent } from './components/pets/pets.component';
import { ProfessoresComponent } from './components/professores/professores.component';

const routes: Routes = [
  {path:'', redirectTo:'professor', pathMatch:'full'},
  {path:'home', component: HomeComponent},
  {path:'accommodations', component: AccommodationsComponent},
  {path:'aluno', component: AlunosComponent},
  {path:'professor', component: ProfessoresComponent},
  {path:'pets', component: PetsComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
