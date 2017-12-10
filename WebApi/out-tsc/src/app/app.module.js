"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/common/http");
var app_routing_module_1 = require("./app-routing.module");
var app_component_1 = require("./app.component");
var google_chart_directive_1 = require("./google-chart.directive");
var industries_component_1 = require("./industries/industries.component");
var dashboard_component_1 = require("./dashboard/dashboard.component");
var economic_variables_component_1 = require("./economic-variables/economic-variables.component");
var industry_service_1 = require("./industry.service");
var economic_variable_service_1 = require("./economic-variable.service");
var declaring_country_service_1 = require("./declaring-country.service");
var partner_country_service_1 = require("./partner-country.service");
var dashboard_service_1 = require("./dashboard.service");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                industries_component_1.IndustriesComponent,
                dashboard_component_1.DashboardComponent,
                economic_variables_component_1.EconomicVariablesComponent,
                google_chart_directive_1.GoogleChartDirective
            ],
            imports: [
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                app_routing_module_1.AppRoutingModule,
                http_1.HttpClientModule,
            ],
            providers: [industry_service_1.IndustryService, economic_variable_service_1.EconomicVariableService, declaring_country_service_1.DeclaringCountryService, partner_country_service_1.PartnerCountryService, dashboard_service_1.DashboardService],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map