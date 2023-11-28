import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Recepcionista } from '../models/recepcionista';

@Injectable({
  providedIn: 'root'
})
export class RecepcionistaService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string,private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Recepcionista[]> {
    return this.http.get<Recepcionista[]>(this.baseUrl + "api/Recepcionista").pipe(
      tap(_ => this.handleErrorService.log('Consulta realizada')),
      catchError(this.handleErrorService.handleError<Recepcionista[]>('Consulta Recepcionista', null))
    );

  }
  post(recepcionista: Recepcionista): Observable<Recepcionista> {
    return this.http.post<Recepcionista>(this.baseUrl + "api/Recepcionista", recepcionista).pipe(
      tap((_) => this.handleErrorService.log('datos registrados')),
      catchError(this.handleErrorService.handleError<Recepcionista>('Registrar Recepcionista', null))
    );
  }
}
