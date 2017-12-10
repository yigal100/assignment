import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../environments/environment';
import { Industry } from './industry';

@Injectable()
export class IndustryService {

  private baseUrl = environment.apiEndpoint + '/api/industries';

  constructor(private http: HttpClient) { }

  getIndustries(): Observable<Industry[]> {
    return this.http.get<Industry[]>(this.baseUrl);
  }

}
