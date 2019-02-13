import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Funcionario } from '../Models/funcionario';
import { MessagesService } from './messages.service';
import { Observable } from 'rxjs';

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
  apiUrl = 'https://localhost:44302/api/ControllerFuncionarios';
  funcionarios: Funcionario[] = [];
  funcionarioInput: Funcionario = new Funcionario();
  editMode: boolean = false;
  
  constructor(
    private http: HttpClient,
    public messageService: MessagesService
    ) {  }

  getFuncionarios(): Observable<Funcionario[]> {
    try {
      return this.http.get<Funcionario[]>(this.apiUrl)
    } catch(error){
      alert(error);
    }
  }

  getFuncionario(id: number): Observable<Funcionario> {
    try {
      return this.http.get<Funcionario>(`${this.apiUrl}/${id}`)
    } catch(error){
      alert(error);
    }
  }

  pagFuncionarios(order: number, page: number, size: number): Observable<Funcionario[]> {
    const url = `${order}/${page}/${size}`;
    return this.http.get<Funcionario[]>(`${this.apiUrl}/pag/${url}`) 
  }

  addFuncionario (funcionario: Funcionario): Observable<Funcionario> {
    return this.http.post<Funcionario>(this.apiUrl, funcionario, httpOptions);
  }

  deleteFuncionario (funcionario: Funcionario): Observable<{}> {
    const url = `${this.apiUrl}/${funcionario.cpf}`;
    return this.http.delete(url)  
  }

  updateFuncionario (funcionario: Funcionario): Observable<Funcionario> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'my-new-auth-token');

    return this.http.put<Funcionario>(`${this.apiUrl}`, funcionario, httpOptions)
  }
}
