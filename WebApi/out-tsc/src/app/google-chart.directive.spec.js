"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var google_chart_directive_1 = require("./google-chart.directive");
var core_1 = require("@angular/core");
describe('GoogleChartDirective', function () {
    it('should create an instance', function () {
        var element;
        var elem = new core_1.ElementRef(element);
        var directive = new google_chart_directive_1.GoogleChartDirective(elem);
        expect(directive).toBeTruthy();
    });
});
//# sourceMappingURL=google-chart.directive.spec.js.map