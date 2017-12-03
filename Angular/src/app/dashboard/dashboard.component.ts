import { Component, OnInit } from '@angular/core';
import { Industry } from '../industry';
import { DeclaringCountry } from '../declaring_country';
import { PartnerCountry } from '../partner_country';
import { YearlyValueDto } from '../value_dtos';
import { IndustryService } from '../industry.service';
import { DeclaringCountryService } from '../declaring-country.service';
import { PartnerCountryService } from '../partner-country.service';
import { DashboardService } from '../dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  selectedIndustry: Industry;
  selectedDeclaringCountry: DeclaringCountry;
  selectedPartnerCountry: PartnerCountry;

  industries: Industry[] = [];
  declaringCountries: DeclaringCountry[] = [];
  partnerCountries: PartnerCountry[] = [];

  public personsEmployedData;
  public personsEmployedChartOptions = {
    title: 'Persons employed by year',
    width: 600,
    height: 500
  };

  public productionValueData;
  public productionValueChartOptions = {
    title: 'Production value by year',
    width: 600,
    height: 500
  };

  public refresh() {
    if (this.selectedDeclaringCountry && this.selectedIndustry && this.selectedPartnerCountry) {
      this.getYearlyValues(this.selectedIndustry.id, this.selectedDeclaringCountry.id, this.selectedPartnerCountry.id);
    }
  }

  Initialize(): void {
    this.industryService.getIndustries().subscribe(industries => {
      this.industries = industries;
      this.selectedIndustry = this.industries.find(x => x.id == "C9994");
      this.refresh();
    });
    this.declaringCountryService.getDeclaringCountries().subscribe(countries => {
      this.declaringCountries = countries;
      this.selectedDeclaringCountry = this.declaringCountries[0];
      this.refresh();
    });
    this.partnerCountryservice.getPartnerCountries().subscribe(countries => {
      this.partnerCountries = countries;
      this.selectedPartnerCountry = this.partnerCountries.find(x => x.id == "WORLD");
      this.refresh();
    });
  }

  getYearlyValues(industryId: string, declaringCountryId: string, partnerCountryId: string) {
    console.log(`Industry: ${industryId}, Declaring country: ${declaringCountryId}, Partner country: ${partnerCountryId}`);
    this.dashboardService.getYearlyValues("EMP", industryId, declaringCountryId, partnerCountryId).subscribe(results => {
      this.personsEmployedData = this.createYearlyChartData(results);
    });
    this.dashboardService.getYearlyValues("GOP", industryId, declaringCountryId, partnerCountryId).subscribe(results => {
      this.productionValueData = this.createYearlyChartData(results);
    });
  }

  createYearlyChartData(values: YearlyValueDto[]): any {
    let data = values.map(value => ["" + value.year, value.value.value]);
    let yearTitle: any = "Years";
    let valueTitle: any = "Value";
    let table = [[yearTitle, valueTitle]];
    return table.concat(data);
  }

  constructor(
    public dashboardService: DashboardService,
    private industryService: IndustryService,
    private declaringCountryService: DeclaringCountryService,
    private partnerCountryservice: PartnerCountryService
  ) { }

  ngOnInit() {
    this.Initialize();
  }
}
