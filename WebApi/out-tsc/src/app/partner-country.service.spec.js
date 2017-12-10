"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var partner_country_service_1 = require("./partner-country.service");
describe('PartnerCountryService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [partner_country_service_1.PartnerCountryService]
        });
    });
    it('should be created', testing_1.inject([partner_country_service_1.PartnerCountryService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=partner-country.service.spec.js.map