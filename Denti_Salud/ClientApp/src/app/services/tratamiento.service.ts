import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Tratamiento } from '../models/tratamiento';

@Injectable({
  providedIn: 'root'
})
export class TratamientoService {

  baseUrl: string;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string,private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Tratamiento[]> {
    return this.http.get<Tratamiento[]>(this.baseUrl + "api/Tratamiento").pipe(
      tap(_ => this.handleErrorService.log('Consulta realizada')),
      catchError(this.handleErrorService.handleError<Tratamiento[]>('Consulta Tratamiento', null))
    );

  }
  post(user: Tratamiento): Observable<Tratamiento> {
    return this.http.post<Tratamiento>(this.baseUrl + "api/Tratamiento", user).pipe(
      tap((_) => this.handleErrorService.log('datos registrados')),
      catchError(this.handleErrorService.handleError<Tratamiento>('Registrar Tratamiento', null))
    );
  }
}
