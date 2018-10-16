import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
 
@Component({
  selector: 'app-quiz-component',
  templateUrl: './quiz-component.component.html',
  styleUrls: ['./quiz-component.component.css']
})
export class QuizComponentComponent implements OnInit {

  res: any = [ ];
  questions = [ ];
  counter:number = 10;
  i:number=0;
  questionCounter = 0;
  selectedOption: string;
  shouldDisplayQuestions = false;
  currentQuestion : any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    
  }

  showQuestions()
  {
    console.log('called showQuestions');
    this.http.get('http://localhost:3000/questions').subscribe((res: any) => {
    this.questions = res;
    this.currentQuestion = this.questions[this.questionCounter];
    this.shouldDisplayQuestions = true;
    this.gameClock();
   // console.log(this.questions[0].options);
    });
  }

  gameClock() {
    const intervalMain = setInterval(() => {
    this.counter--;
    if (this.counter <= 0) {
      this.nextQuestion();
      this.resetTimer();
    }
  }, 1000);
}

nextQuestion(){
  this.resetTimer();
  console.log(this.selectedOption);
  this.selectedOption = "";
  this.questionCounter++;
  this.currentQuestion = this.questions[this.questionCounter];
}

prevQuestion(){
  this.questionCounter--;
  this.currentQuestion = this.questions[this.questionCounter];
}

resetTimer(){
  this.i++;
  //this.score+=this.counter*2;
  this.counter=10;
}
}
