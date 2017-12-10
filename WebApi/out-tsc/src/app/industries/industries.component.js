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
var IndustriesComponent = /** @class */ (function () {
    function IndustriesComponent(industryService) {
        this.industryService = industryService;
    }
    IndustriesComponent.prototype.getIndustries = function () {
        var _this = this;
        this.industryService.getIndustries().subscribe(function (industries) { return _this.industries = industries; });
    };
    IndustriesComponent.prototype.ngOnInit = function () {
        this.getIndustries();
    };
    IndustriesComponent = __decorate([
        core_1.Component({
            selector: 'app-industries',
            templateUrl: './industries.component.html',
            styleUrls: ['./industries.component.css']
        }),
        __metadata("design:paramtypes", [industry_service_1.IndustryService])
    ], IndustriesComponent);
    return IndustriesComponent;
}());
exports.IndustriesComponent = IndustriesComponent;
//# sourceMappingURL=industries.component.js.map