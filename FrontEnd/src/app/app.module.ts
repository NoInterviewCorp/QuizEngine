import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponentComponent } from './home-component/home-component.component';
import { HeaderComponentComponent } from './home-component/header-component/header-component.component';
import { QuizComponentComponent } from './home-component/quiz-component/quiz-component.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CountdownModule } from 'ngx-countdown';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatRadioModule} from '@angular/material/radio';
import {MatButtonModule} from '@angular/material/button';
import { ResultComponent } from './result/result.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatDividerModule} from '@angular/material/divider';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { DisplayTechnologiesComponent } from './display-technologies/display-technologies.component';
import {MatCardModule} from '@angular/material/card';
import { CardComponent } from './display-technologies/card/card.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponentComponent,
    HeaderComponentComponent,
    QuizComponentComponent,
    ResultComponent,
    DisplayTechnologiesComponent,
    CardComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatToolbarModule,
    MatGridListModule,
    MatDividerModule,
    BrowserAnimationsModule,
    MatRadioModule,
    MatButtonModule,
    CountdownModule,
    MatProgressBarModule,
    MatDividerModule,
    ChartsModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
