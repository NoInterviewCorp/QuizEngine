import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Technology } from '../models/Technology';
@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private http: HttpClient) { }

  tech : Technology;
  sTopic : string;
  // get(url: string) {
  //   return this.http.get(url);
  // }

  // getAll() {
  //   return [
  //     { id: 'data/db.json', name: 'Asp.Net' }
  //   ];
    
  // }

  setName(t:Technology,s:string) {
    this.tech=t;
    this.sTopic=s;
  }
  getTechName() {
    return this.tech;
  }
  getTopicName() {
    return this.sTopic;
  }
  getQuestions() {
    let selectedTopic=this.tech.Topics.find(x=>x.Name==this.sTopic);
    console.log(this.tech);
    if(selectedTopic!=null)
    { 
      return selectedTopic.Questions;
    }
    return null;
  }

}





