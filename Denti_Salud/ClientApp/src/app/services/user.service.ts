import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl: string;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string,private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }
  get(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + "api/Login").pipe(
      tap(_ => this.handleErrorService.log('Consulta realizada')),
      catchError(this.handleErrorService.handleError<User[]>('Consulta Usuario', null))
    );

  }
  post(user: User): Observable<User> {
    return this.http.post<User>(this.baseUrl + "Usuario", user).pipe(
      tap((_) => this.handleErrorService.log('datos registrados')),
      catchError(this.handleErrorService.handleError<User>('Registrar Usuario', null))
    );
  }
}
