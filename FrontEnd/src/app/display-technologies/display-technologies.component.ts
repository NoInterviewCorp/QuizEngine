import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-display-technologies',
  templateUrl: './display-technologies.component.html',
  styleUrls: ['./display-technologies.component.css']
})
export class DisplayTechnologiesComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }
  showTechnologies() {

  }

}
