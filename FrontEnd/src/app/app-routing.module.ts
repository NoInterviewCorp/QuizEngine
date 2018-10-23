import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResultComponent } from './result/result.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { DisplayTechnologiesComponent } from './display-technologies/display-technologies.component';
import { QuizComponentComponent } from './home-component/quiz-component/quiz-component.component'; 

const routes: Routes = [
  {path: '', component: DisplayTechnologiesComponent },
  {path: 'result', component: ResultComponent},
  {path:'quiz', component:QuizComponentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
