"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var economic_variable_service_1 = require("./economic-variable.service");
describe('EconomicVariableService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [economic_variable_service_1.EconomicVariableService]
        });
    });
    it('should be created', testing_1.inject([economic_variable_service_1.EconomicVariableService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=economic-variable.service.spec.js.map