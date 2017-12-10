import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../environments/environment';
import { DeclaringCountry } from './declaring_country';

@Injectable()
export class DeclaringCountryService {

  private baseUrl = environment.apiEndpoint + '/api/declaring_countries';

  constructor(private http: HttpClient) { }

  getDeclaringCountries(): Observable<DeclaringCountry[]> {
    return this.http.get<DeclaringCountry[]>(this.baseUrl);
  }

}
