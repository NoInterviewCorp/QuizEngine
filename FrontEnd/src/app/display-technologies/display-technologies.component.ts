import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Technology } from '../models/Technology';

@Component({
  selector: 'app-display-technologies',
  templateUrl: './display-technologies.component.html',
  styleUrls: ['./display-technologies.component.css']
})
export class DisplayTechnologiesComponent implements OnInit {

  technology = [ ];
  topics=[];
  technologySelected :Technology;
  showTechButton = true;
  isTechSelected = false;
  //tech : any;
  areAllLocked = true;
  constructor(private http: HttpClient) { }

  ngOnInit() { }

  showTechnologies() {
    this.http.get('http://localhost:3000/Technology').subscribe((res: any) => {
      this.technology = res;
      console.log(this.technology);
      this.showTechButton=false;
      // this.topics = this.technology[0].Topics;
    });

  }

  toggle(){
    this.isTechSelected = false;
  }

  getTech(){

  }

  exploreTopics(technology){
    this.topics = technology.Topics;
    this.technologySelected = technology;
    // technology.Topics.forEach(topic=>this.topics.push(topic));
    // console.log(this.technologySelected);
    this.isTechSelected = true;
  }

}
