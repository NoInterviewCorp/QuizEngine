import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Technology } from 'src/app/models/Technology';
import { QuizService } from 'src/app/services/quiz.service';
// import { BloomLevel } from 'src/app/models/Bloom';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent implements OnInit {

  @Input() name: string;
  @Input() isLocked: boolean;
  @Input() bloom: BloomLevel;
  @Input() tech: Technology;


  constructor(private router: Router, private quiz_service : QuizService) { }

  ngOnInit() {
  }

  onClick() {
    console.log("I belong to " + this.tech.Name + " and Topic is " + this.name);
    this.quiz_service.setName(this.tech.Name,this.name);
    this.router.navigate(['quiz']);
  }

}
