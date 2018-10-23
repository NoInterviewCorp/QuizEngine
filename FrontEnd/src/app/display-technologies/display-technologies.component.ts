import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-display-technologies',
  templateUrl: './display-technologies.component.html',
  styleUrls: ['./display-technologies.component.css']
})
export class DisplayTechnologiesComponent implements OnInit {

  technology = [ ];
  //tech : any;

  constructor(private http: HttpClient) { }

  ngOnInit() { }

  showTechnologies() {
    this.http.get('http://localhost:3000/Technology').subscribe((res: any) => {
      this.technology = res;
    });

  }

}
