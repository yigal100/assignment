import { Component, OnInit } from '@angular/core';
import { EconomicVariable } from '../economic_variable';
import { EconomicVariableService } from '../economic-variable.service';

@Component({
  selector: 'app-economic-variables',
  templateUrl: './economic-variables.component.html',
  styleUrls: ['./economic-variables.component.css']
})
export class EconomicVariablesComponent implements OnInit {

  economicVariables: EconomicVariable[];

  constructor(private economicVariablesService: EconomicVariableService) { }

  ngOnInit() {
    this.economicVariablesService.getEconomicVariables().subscribe(variables => this.economicVariables = variables);
  }

}
