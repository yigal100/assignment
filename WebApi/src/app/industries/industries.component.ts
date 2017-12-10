import { Component, OnInit } from '@angular/core';
import { Industry } from '../industry';
import { IndustryService } from '../industry.service';

@Component({
  selector: 'app-industries',
  templateUrl: './industries.component.html',
  styleUrls: ['./industries.component.css']
})
export class IndustriesComponent implements OnInit {
  industries: Industry[];

  getIndustries(): void {
    this.industryService.getIndustries().subscribe(industries => this.industries = industries);
  }
  constructor(private industryService: IndustryService) { }

  ngOnInit() {
    this.getIndustries();
  }

}
