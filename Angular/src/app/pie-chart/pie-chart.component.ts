import { Component, OnInit, Input } from '@angular/core';
import { Industry } from '../industry';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {
  @Input() industry: Industry;

  constructor() { }

  ngOnInit() {
  }

}
