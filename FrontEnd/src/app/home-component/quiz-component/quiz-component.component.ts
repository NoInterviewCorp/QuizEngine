import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { QuizService } from 'src/app/services/quiz.service';

@Component({
  selector: 'app-quiz-component',
  templateUrl: './quiz-component.component.html',
  styleUrls: ['./quiz-component.component.css']
})
export class QuizComponentComponent implements OnInit {

  //res: any = [ ];
  questions = [];
  duration = 20; //timer duration
  counter: number = this.duration;
  i: number = 0;
  questionCounter = 0;
  selectedOption: string;
  shouldDisplayQuestions = false;
  currentQuestion: any;
  showTimer = false;
  showNextButton = false;
  showQuesButton = true;
  showProgressBar = false;
  quesCount = 0;
  totalQues = 0;
  callResult = false;
  value = 0;
  valueInc = 0;

  techName: string; subTopicName: string;

  constructor(private http: HttpClient, private quiz_service: QuizService) { }

  ngOnInit() {

  }

  showQuestions() {
    this.showTimer = true;
    this.showProgressBar = true;
    console.log('called showQuestions');
    this.questions = this.quiz_service.getQuestions();
    this.showNextButton = true;
    this.showQuesButton = false;
    this.questionCounter = 0;
    this.currentQuestion = this.questions[this.questionCounter];
    this.shouldDisplayQuestions = true;
    this.totalQues = this.questions.length;
    this.valueInc = 100 / this.totalQues;

    this.gameClock();
    //console.log(this.questions[0].options);
    console.log("total ques" + this.totalQues);
    // console.log("ques count" + this.quesCount);


  }

  gameClock() {
    const intervalMain = setInterval(() => {
      this.counter--;
      // console.log("counter:"+this.counter);
      if (this.counter <= 0) {
        this.nextQuestion();
      }
      //this.resetTimer();}
      if (this.quesCount == this.totalQues) {
        clearInterval(intervalMain);
      }

    }, 1000);

  }

  nextQuestion() {

    this.resetTimer();
    console.log(this.selectedOption);
    this.selectedOption = "";
    this.questionCounter++;
    this.currentQuestion = this.questions[this.questionCounter];
    this.value = this.value + this.valueInc;
    if (this.quesCount == this.totalQues) {
      this.showNextButton = false;
      this.callResult = true;
      this.showTimer = false;
      this.showProgressBar = false;
    }
  }

  prevQuestion() {

    this.questionCounter--;
    this.currentQuestion = this.questions[this.questionCounter];
  }

  resetTimer() {
    //this.score+=this.counter*2;
    this.quesCount++;
    this.counter = this.duration;
  }
}
