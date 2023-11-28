import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Paciente } from '../models/Paciente';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string, private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<Paciente[]> {
    return this.http.get<Paciente[]>(this.baseUrl + "api/Paciente").pipe(
      tap(_ => this.handleErrorService.log('Consulta realizada')),
      catchError(this.handleErrorService.handleError<Paciente[]>('Consulta Paciente', null))
      //error => {console.log("Error al consultar los datos")return of(error as Paciente[])}
    );

  }
  post(cliente: Paciente): Observable<Paciente> {
    return this.http.post<Paciente>(this.baseUrl + "api/Paciente", cliente).pipe(
      tap((_) => this.handleErrorService.log('datos registrados')),
      catchError(this.handleErrorService.handleError<Paciente>('Registrar Paciente', null))
      //(error) => {alert("No se pudo guardar el paciente");console.log("Error al registrar los datos", error);return of(cliente);}
    );
  }
}

