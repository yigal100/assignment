import { TestBed, inject } from '@angular/core/testing';

import { PartnerCountryService } from './partner-country.service';

describe('PartnerCountryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PartnerCountryService]
    });
  });

  it('should be created', inject([PartnerCountryService], (service: PartnerCountryService) => {
    expect(service).toBeTruthy();
  }));
});
