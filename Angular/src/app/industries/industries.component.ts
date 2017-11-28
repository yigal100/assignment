import { Component, OnInit } from '@angular/core';
import { Industry } from '../industry';
import { Industries } from '../mock-industries';

@Component({
  selector: 'app-industries',
  templateUrl: './industries.component.html',
  styleUrls: ['./industries.component.css']
})
export class IndustriesComponent implements OnInit {
  industries = Industries;

  selectedIndustry: Industry;

  onSelect(industry: Industry): void {
    this.selectedIndustry = industry;
  }

  constructor() { }

  ngOnInit() {
  }

}
