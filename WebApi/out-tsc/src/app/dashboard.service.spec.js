"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var dashboard_service_1 = require("./dashboard.service");
describe('DashboardService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [dashboard_service_1.DashboardService]
        });
    });
    it('should be created', testing_1.inject([dashboard_service_1.DashboardService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=dashboard.service.spec.js.map