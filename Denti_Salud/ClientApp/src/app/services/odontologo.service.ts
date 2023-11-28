import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Odontologo } from '../models/odontologo';

@Injectable({
  providedIn: 'root'
})
export class OdontologoService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string,private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Odontologo[]> {
    return this.http.get<Odontologo[]>(this.baseUrl + "api/Odontologo").pipe(
      tap(_ => this.handleErrorService.log('Consulta realizada')),
      catchError(this.handleErrorService.handleError<Odontologo[]>('Consulta Odontologo', null))
    );

  }
  post(odontologo: Odontologo): Observable<Odontologo> {
    return this.http.post<Odontologo>(this.baseUrl + "api/Odontologo", odontologo).pipe(
      tap((_) => this.handleErrorService.log('datos registrados')),
      catchError(this.handleErrorService.handleError<Odontologo>('Registrar Odontologo', null))
    );
  }
}
