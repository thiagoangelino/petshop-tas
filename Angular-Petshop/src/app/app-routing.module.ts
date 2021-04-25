import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccommodationComponent } from './accommodation/accommodation.component';

const routes: Routes = [
  {path:'', redirectTo:'accommodation', pathMatch:'full'},
  {path:'accommodation', component: AccommodationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
