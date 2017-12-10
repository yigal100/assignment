"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var industry_service_1 = require("../industry.service");
var declaring_country_service_1 = require("../declaring-country.service");
var partner_country_service_1 = require("../partner-country.service");
var dashboard_service_1 = require("../dashboard.service");
var DashboardComponent = /** @class */ (function () {
    function DashboardComponent(dashboardService, industryService, declaringCountryService, partnerCountryservice) {
        this.dashboardService = dashboardService;
        this.industryService = industryService;
        this.declaringCountryService = declaringCountryService;
        this.partnerCountryservice = partnerCountryservice;
        this.industries = [];
        this.declaringCountries = [];
        this.partnerCountries = [];
        this.personsEmployedChartOptions = {
            title: 'Persons employed by year',
            width: 600,
            height: 500
        };
        this.productionValueChartOptions = {
            title: 'Production value by year',
            width: 600,
            height: 500
        };
    }
    DashboardComponent.prototype.refresh = function () {
        if (this.selectedDeclaringCountry && this.selectedIndustry && this.selectedPartnerCountry) {
            this.getYearlyValues(this.selectedIndustry.id, this.selectedDeclaringCountry.id, this.selectedPartnerCountry.id);
        }
    };
    DashboardComponent.prototype.Initialize = function () {
        var _this = this;
        this.industryService.getIndustries().subscribe(function (industries) {
            _this.industries = industries;
            _this.selectedIndustry = _this.industries.find(function (x) { return x.id == "C9994"; });
            _this.refresh();
        });
        this.declaringCountryService.getDeclaringCountries().subscribe(function (countries) {
            _this.declaringCountries = countries;
            _this.selectedDeclaringCountry = _this.declaringCountries[0];
            _this.refresh();
        });
        this.partnerCountryservice.getPartnerCountries().subscribe(function (countries) {
            _this.partnerCountries = countries;
            _this.selectedPartnerCountry = _this.partnerCountries.find(function (x) { return x.id == "WORLD"; });
            _this.refresh();
        });
    };
    DashboardComponent.prototype.getYearlyValues = function (industryId, declaringCountryId, partnerCountryId) {
        var _this = this;
        console.log("Industry: " + industryId + ", Declaring country: " + declaringCountryId + ", Partner country: " + partnerCountryId);
        this.dashboardService.getYearlyValues("EMP", industryId, declaringCountryId, partnerCountryId).subscribe(function (results) {
            _this.personsEmployedData = _this.createYearlyChartData(results);
        });
        this.dashboardService.getYearlyValues("GOP", industryId, declaringCountryId, partnerCountryId).subscribe(function (results) {
            _this.productionValueData = _this.createYearlyChartData(results);
        });
    };
    DashboardComponent.prototype.createYearlyChartData = function (values) {
        var data = values.map(function (value) { return ["" + value.year, value.value.value]; });
        var yearTitle = "Years";
        var valueTitle = "Value";
        var table = [[yearTitle, valueTitle]];
        return table.concat(data);
    };
    DashboardComponent.prototype.ngOnInit = function () {
        this.Initialize();
    };
    DashboardComponent = __decorate([
        core_1.Component({
            selector: 'app-dashboard',
            templateUrl: './dashboard.component.html',
            styleUrls: ['./dashboard.component.css']
        }),
        __metadata("design:paramtypes", [dashboard_service_1.DashboardService,
            industry_service_1.IndustryService,
            declaring_country_service_1.DeclaringCountryService,
            partner_country_service_1.PartnerCountryService])
    ], DashboardComponent);
    return DashboardComponent;
}());
exports.DashboardComponent = DashboardComponent;
//# sourceMappingURL=dashboard.component.js.map