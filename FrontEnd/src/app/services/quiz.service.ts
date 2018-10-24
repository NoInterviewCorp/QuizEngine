import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Technology } from '../models/Technology';
@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private http: HttpClient) { }

  tech : string;
  sTopic : string;
  // get(url: string) {
  //   return this.http.get(url);
  // }

  // getAll() {
  //   return [
  //     { id: 'data/db.json', name: 'Asp.Net' }
  //   ];
    
  // }

  setName(t:string,s:string) {
    this.tech=t;
    this.sTopic=s;
  }
  getTechName() {
    return this.tech;
  }
  getTopicName() {
    return this.sTopic;
  }

}





