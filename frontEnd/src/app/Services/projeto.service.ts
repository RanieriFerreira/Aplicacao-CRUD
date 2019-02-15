import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';


import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

 
import { Projeto } from '../Models/projeto';
import { MessagesService } from './messages.service';
import { ErrorHandlerService, HandleError } from './error-handler.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ProjetoService {
  private handleError: HandleError;
  apiUrl = 'https://localhost:44302/api/ControllerProjetos';
  projetos: Projeto[] = [];
  projetoInput: Projeto = new Projeto();
  editMode: boolean = false;
  
  constructor(
    private http: HttpClient,
    httpErrorHandler: ErrorHandlerService) {
    this.handleError = httpErrorHandler.createHandleError('ProjetoService');
    }

  getProjetos(): Observable<Projeto[]> {
    return this.http.get<Projeto[]>(this.apiUrl)
    .pipe(
      catchError(this.handleError('getProjetos', undefined))
    );
  }

  getProjeto(id: number): Observable<Projeto> {
    return this.http.get<Projeto>(`${this.apiUrl}/${id}`)
    .pipe(
      catchError(this.handleError('getProjeto', undefined))
    );
  }

  searchProjetos(term: string): Observable<Projeto[]> {
    const options = term ? { params: new HttpParams().set('nome', term) } : {};
    return this.http.get<Projeto[]>(`${this.apiUrl}/search/${term}`)
    .pipe(
      catchError(this.handleError('searchProjetos', undefined))
    );
  }

  addProjeto (projeto: Projeto): Observable<Projeto> {
    return this.http.post<Projeto>(this.apiUrl, projeto, httpOptions)
    .pipe(
      catchError(this.handleError('addProjeto', undefined))
    );
  }

  deleteProjeto (id: number): Observable<{}> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url)
    .pipe(
      catchError(this.handleError('deleteProjeto', -1))
    );  
  }

  updateProjeto (projeto: Projeto): Observable<Projeto> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'my-new-auth-token');

    return this.http.put<Projeto>(`${this.apiUrl}/${projeto.id}`, projeto, httpOptions)
    .pipe(
      catchError(this.handleError('updateProjeto', undefined))
    );  
    
  }
}
