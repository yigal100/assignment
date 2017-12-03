import { TestBed, inject } from '@angular/core/testing';

import { DeclaringCountryService } from './declaring-country.service';

describe('DeclaringCountryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DeclaringCountryService]
    });
  });

  it('should be created', inject([DeclaringCountryService], (service: DeclaringCountryService) => {
    expect(service).toBeTruthy();
  }));
});
