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

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  showQuestions()
  {
    console.log('called showQuestions');
    this.http.get('http://localhost:3000/questions').subscribe((res: any) => {
    this.questions = res;
    console.log(this.questions);
    });
  }
  

}
