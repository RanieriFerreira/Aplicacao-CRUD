import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';


import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

 
import { Projeto } from '../Models/projeto';
import { MessagesService } from './messages.service';

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
  apiUrl = 'https://localhost:44302/api/ControllerProjetos';
  projetos: Projeto[] = [];
  projetoInput: Projeto = new Projeto();
  editMode: boolean = false;
  
  constructor(
    private http: HttpClient,
    public messageService: MessagesService
    ) {  }

  getProjetos(): Observable<Projeto[]> {
    try {
      return this.http.get<Projeto[]>(this.apiUrl)
    } catch(error){
      alert(error);
    }
  }

  getProjeto(id: number): Observable<Projeto> {
    try {
      return this.http.get<Projeto>(`${this.apiUrl}/${id}`)
    } catch(error){
      alert(error);
    }
  }

  searchProjetos(term: string): Observable<Projeto[]> {
    const options = term ? { params: new HttpParams().set('nome', term) } : {};
    return this.http.get<Projeto[]>(`${this.apiUrl}/search/${term}`) 
  }

  addProjeto (projeto: Projeto): Observable<Projeto> {
    return this.http.post<Projeto>(this.apiUrl, projeto, httpOptions);
  }

  deleteProjeto (id: number): Observable<{}> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url)  
  }

  updateProjeto (projeto: Projeto): Observable<Projeto> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'my-new-auth-token');

    return this.http.put<Projeto>(`${this.apiUrl}/${projeto.id}`, projeto, httpOptions)
  }
}
