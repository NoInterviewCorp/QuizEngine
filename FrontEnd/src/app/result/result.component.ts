import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  public radarChartLabels:string[] = ['Components and Templates', 'Services', 'Routing', 'Observables', 'Testing'];

  public radarChartData:any = [
    {data: [1,3,2,4,5,3]},
    {data: [4,3,4,2,1,6]}
  ];
  public radarChartType:string = 'radar';
  public options = {
    scale:{
      ticks:{
        min:0,
        max:6,
        stepSize:1
      }
    }
  };
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }
}
