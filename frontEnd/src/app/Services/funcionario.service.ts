import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Funcionario } from '../Models/funcionario';
import { MessagesService } from './messages.service';
import { ErrorHandlerService, HandleError } from '../Services/error-handler.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class FuncionarioService {
  private handleError: HandleError;
  apiUrl = 'https://localhost:44302/api/ControllerFuncionarios';
  funcionarios: Funcionario[] = [];
  funcionarioInput: Funcionario = new Funcionario();
  editMode: boolean = false;
  
  constructor(
    private http: HttpClient,
    httpErrorHandler: ErrorHandlerService) {
    this.handleError = httpErrorHandler.createHandleError('FuncionarioService');
  }

  getFuncionarios(): Observable<Funcionario[]> {
    return this.http.get<Funcionario[]>(this.apiUrl)
    .pipe(
      catchError(this.handleError('getFuncionarios', undefined))
    );
  }

  getFuncionario(funcionario?: Funcionario, id?: number): Observable<Funcionario> {
    const idUrl = funcionario? funcionario.cpf : id; 
    return this.http.get<Funcionario>(`${this.apiUrl}/${idUrl}`)
    .pipe(
      catchError(this.handleError('getFuncionario', undefined))
    );
  }

  pagFuncionarios(order: number, page: number, size: number): Observable<Funcionario[]> {
    const url = `${order}/${page}/${size}`;
    return this.http.get<Funcionario[]>(`${this.apiUrl}/pag/${url}`)
    .pipe(
      catchError(this.handleError('pagFuncionarios', undefined))
    ); 
  }

  addFuncionario (funcionario: Funcionario): Observable<Funcionario> {
    const id = this.http.post<Funcionario>(this.apiUrl, funcionario, httpOptions)
      .pipe(
        catchError(this.handleError('addFuncionario', undefined))
      );
    if (typeof id === 'number')
      return this.http.get<Funcionario>(`${this.apiUrl}/${id}`).pipe(catchError(this.handleError('getFuncionarios', funcionario)));
    else 
      return id;
  }

  deleteFuncionario (funcionario: Funcionario): Observable<{}> {
    const url = `${this.apiUrl}/${funcionario.cpf}`;
    return this.http.delete(url).pipe(
      catchError(this.handleError('deleteFuncionario', -1))
    );
  }

  updateFuncionario (funcionario: Funcionario): Observable<Funcionario> {
    httpOptions.headers = httpOptions.headers.set('Authorization', 'my-new-auth-token');

    return this.http.put<Funcionario>(`${this.apiUrl}`, funcionario, httpOptions)
    .pipe(
      catchError(this.handleError('updateFuncionario', undefined))
    );
  }
}
