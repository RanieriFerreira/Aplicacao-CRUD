import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { ProjetoFuncionario } from '../Models/projetoFuncionario';
import { HandleError, ErrorHandlerService } from './error-handler.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Projeto } from '../Models/projeto';
import { Funcionario } from '../Models/funcionario';
import { Relacao } from '../Models/relacao';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ListRelacoesService {
  private handleError: HandleError;
  apiUrl = 'https://localhost:44302/api/ControllerFuncionarioProjeto';
  projetoFuncionarios: ProjetoFuncionario[] = [];
  projetoFuncionarioInput: ProjetoFuncionario = new ProjetoFuncionario();
  listMode: boolean = false;
  projetoId: number = undefined;
  funcionarios: Funcionario[] = [];
  
  constructor(
    private http: HttpClient,
    httpErrorHandler: ErrorHandlerService) {
    this.handleError = httpErrorHandler.createHandleError('ProjetoService');
    }

  listFuncionarios(id: number): Observable<ProjetoFuncionario[]> {
    return this.http.get<ProjetoFuncionario[]>(`${this.apiUrl}/projeto/${id}`)
    .pipe(
      catchError(this.handleError('listFuncionarios', undefined))
    );
  }

  add(relacao: Relacao): Observable<ProjetoFuncionario> {
    return this.http.post<ProjetoFuncionario>(`${this.apiUrl}`, relacao, httpOptions)
    .pipe(
      catchError(this.handleError('addFuncionarios', undefined))
    );
  }

  delete(idFuncionario: number, idProjeto: number): Observable<ProjetoFuncionario[]> {
    return this.http.delete(`${this.apiUrl}/${idFuncionario}/${idProjeto}`)
    .pipe(
      catchError(this.handleError('deleteFuncionarios', undefined))
    );
  }
}
