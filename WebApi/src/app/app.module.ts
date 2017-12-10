import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { GoogleChartDirective } from './google-chart.directive';
import { IndustriesComponent } from './industries/industries.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EconomicVariablesComponent } from './economic-variables/economic-variables.component';

import { IndustryService } from './industry.service';
import { EconomicVariableService } from './economic-variable.service';
import { DeclaringCountryService } from './declaring-country.service';
import { PartnerCountryService } from './partner-country.service';
import { DashboardService } from './dashboard.service';

@NgModule({
  declarations: [
    AppComponent,
    IndustriesComponent,
    DashboardComponent,
    EconomicVariablesComponent,
    GoogleChartDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [IndustryService, EconomicVariableService, DeclaringCountryService, PartnerCountryService, DashboardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
