"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var industry_service_1 = require("./industry.service");
describe('IndustryService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [industry_service_1.IndustryService]
        });
    });
    it('should be created', testing_1.inject([industry_service_1.IndustryService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=industry.service.spec.js.map