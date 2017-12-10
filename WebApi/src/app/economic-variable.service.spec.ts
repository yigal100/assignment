import { TestBed, inject } from '@angular/core/testing';

import { EconomicVariableService } from './economic-variable.service';

describe('EconomicVariableService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EconomicVariableService]
    });
  });

  it('should be created', inject([EconomicVariableService], (service: EconomicVariableService) => {
    expect(service).toBeTruthy();
  }));
});
