import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
//import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { YearlyValueDto } from './value_dtos';

@Injectable()
export class DashboardService {

  private baseUrl = environment.apiEndpoint + '/api/query';

  constructor(private http: HttpClient) { }

  getYearlyValues(
    economicVariableId: string,
    industryId: string,
    declaringCountryId: string,
    partnerCountryId: string): Observable<YearlyValueDto[]> {
    const url = `${this.baseUrl}/years?economicVariableId=${economicVariableId}&industryId=${industryId}&declaringCountryId=${declaringCountryId}&partnerCountryId=${partnerCountryId}`;
    return this.http.get<YearlyValueDto[]>(url);//.pipe(
      //tap(_ => (`fetched query for url=${url}`)),
      //catchError(this.handleError<Hero>(`getHero id=${id}`))
    //);
  }

}
