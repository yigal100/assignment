import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../environments/environment';
import { EconomicVariable } from './economic_variable';

@Injectable()
export class EconomicVariableService {

  private baseUrl = environment.apiEndpoint + '/api/economic_variables';

  constructor(private http: HttpClient) { }

  getEconomicVariables(): Observable<EconomicVariable[]> {
    return this.http.get<EconomicVariable[]>(this.baseUrl);
  }
}
