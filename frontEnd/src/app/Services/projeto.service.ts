import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';


import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

 
import { Projeto } from '../Models/projeto';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json; text/html; charset=utf-8',
    'Access-Control-Allow-Origin': '*'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ProjetoService {
  apiUrl = 'https://localhost:44302/api/ControllerProjetos';
  
  constructor(
    private http: HttpClient
    ) {  }

  getProjetos(): Observable<Projeto[]> {
    try {
      return this.http.get<Projeto[]>(this.apiUrl)
    } catch(error){
      alert(error);
    }
  }

  /* GET heroes whose name contains search term */
  searchProjetos(term: string): Observable<Projeto[]> {
    term = term.trim();

    // Add safe, URL encoded search parameter if there is a search term
    const options = term ?
     { params: new HttpParams().set('nome', term) } : {};

    return this.http.get<Projeto[]>(this.apiUrl+'/search', options) 
  }

  //////// Save methods //////////

  /** POST: add a new hero to the database */
  addProjeto (projeto: Projeto): Observable<Projeto> {
    return this.http.post<Projeto>(this.apiUrl, projeto, httpOptions) 
  }

  /** DELETE: delete the hero from the server */
  deleteProjeto (id: number): Observable<{}> {
    const url = `${this.apiUrl}/${id}`; // DELETE api/heroes/42
    return this.http.delete(url, httpOptions)  
  }

  /** PUT: update the hero on the server. Returns the updated hero upon success. */
  updateHero (projeto: Projeto): Observable<Projeto> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'my-new-auth-token');

    return this.http.put<Projeto>(this.apiUrl, projeto, httpOptions)
  }
}
