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
  counter:number = 300;
  i:number=0;
  questionCounter = 0;
  selectedOption: string;
  shouldDisplayQuestions = false;
  currentQuestion : any;
  showNextButton = false;
  showQuesButton = true;
  quesCount = 0;
  totalQues = 0;
  callResult = false;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    
  }

  showQuestions()
  {
    console.log('called showQuestions');
    this.http.get('http://localhost:3000/questions').subscribe((res: any) => {
    this.questions = res;
    this.showNextButton = true;
    this.showQuesButton = false; 
    this.currentQuestion = this.questions[this.questionCounter];
    this.shouldDisplayQuestions = true;
    this.gameClock();
    this.totalQues=this.questions.length;
   //console.log(this.questions[0].options);
    console.log(this.totalQues);
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
  this.quesCount++;
  if(this.quesCount==this.totalQues){
    this.showNextButton=false;
    this.callResult = true;
  }
}

prevQuestion(){
  this.questionCounter--;
  this.currentQuestion = this.questions[this.questionCounter];
}

resetTimer(){
  this.i++;
  //this.score+=this.counter*2;
  this.counter=300;
}
}
