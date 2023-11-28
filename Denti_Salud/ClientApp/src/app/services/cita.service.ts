import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Cita } from '../models/cita';

@Injectable({
  providedIn: 'root'
})
export class CitaService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string,private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Cita[]> {
    return this.http.get<Cita[]>(this.baseUrl + "api/Cita").pipe(
      tap(_ => this.handleErrorService.log('Consulta realizada')),
      catchError(this.handleErrorService.handleError<Cita[]>('Consulta Cita', null))
    );

  }
  post(cita: Cita): Observable<Cita> {
    return this.http.post<Cita>(this.baseUrl + "api/Cita", cita).pipe(
      tap((_) => this.handleErrorService.log('datos registrados')),
      catchError(this.handleErrorService.handleError<Cita>('Registrar Cita', null))
    );
  }
}
