"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var declaring_country_service_1 = require("./declaring-country.service");
describe('DeclaringCountryService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [declaring_country_service_1.DeclaringCountryService]
        });
    });
    it('should be created', testing_1.inject([declaring_country_service_1.DeclaringCountryService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=declaring-country.service.spec.js.map