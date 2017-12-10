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
var http_1 = require("@angular/common/http");
//import { catchError, map, tap } from 'rxjs/operators';
var environment_1 = require("../environments/environment");
var DashboardService = /** @class */ (function () {
    function DashboardService(http) {
        this.http = http;
        this.baseUrl = environment_1.environment.apiEndpoint + '/api/query';
    }
    DashboardService.prototype.getYearlyValues = function (economicVariableId, industryId, declaringCountryId, partnerCountryId) {
        var url = this.baseUrl + "/years?economicVariableId=" + economicVariableId + "&industryId=" + industryId + "&declaringCountryId=" + declaringCountryId + "&partnerCountryId=" + partnerCountryId;
        return this.http.get(url); //.pipe(
        //tap(_ => (`fetched query for url=${url}`)),
        //catchError(this.handleError<Hero>(`getHero id=${id}`))
        //);
    };
    DashboardService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], DashboardService);
    return DashboardService;
}());
exports.DashboardService = DashboardService;
//# sourceMappingURL=dashboard.service.js.map