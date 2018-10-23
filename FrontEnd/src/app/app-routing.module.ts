import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResultComponent } from './result/result.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { DisplayTechnologiesComponent } from './display-technologies/display-technologies.component';

const routes: Routes = [
  {path: '', component: DisplayTechnologiesComponent },
  {path: 'result', component: ResultComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
