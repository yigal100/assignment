import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../environments/environment';
import { PartnerCountry } from './partner_country';

@Injectable()
export class PartnerCountryService {

  private baseUrl = environment.apiEndpoint + '/api/partner_countries';

  constructor(private http: HttpClient) { }

  getPartnerCountries(): Observable<PartnerCountry[]> {
    return this.http.get<PartnerCountry[]>(this.baseUrl);
  }

}
