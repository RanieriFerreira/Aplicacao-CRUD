import { Component, OnInit } from '@angular/core';
import { ListRelacoesService } from 'src/app/Services/list-relacoes.service';
import { FuncionarioService } from 'src/app/Services/funcionario.service';
import { Funcionario } from 'src/app/Models/funcionario';
import { ProjetoFuncionario } from 'src/app/Models/projetoFuncionario';
import { Relacao } from 'src/app/Models/relacao';

@Component({
  selector: 'app-list-relacoes',
  templateUrl: './list-relacoes.component.html',
  styleUrls: ['./list-relacoes.component.scss']
})
export class ListRelacoesComponent implements OnInit {
  
  funcionarios: Funcionario[] = [];

  constructor(
    private _httpServiceRelacao: ListRelacoesService,
    private _httpService: FuncionarioService
  )   {  }

  ngOnInit() {
    
  }

  cancel() {
    this._httpServiceRelacao.listMode = false;
  }

  delete(idFuncionario: number, idProjeto: number) {
    this._httpServiceRelacao.delete(idFuncionario, idProjeto).subscribe(() => {
      this.listFuncionarios(this._httpServiceRelacao.projetoId);
    });
  }

  add(idFuncionario: number, idProjeto: number): void {
    const relacao = new Relacao(idProjeto,idFuncionario);
    this._httpServiceRelacao.add(relacao)
    .subscribe(() => {
      this.listFuncionarios(this._httpServiceRelacao.projetoId);
    });
  }

  getFuncionarios(): void {
    this._httpService.getFuncionarios()
    .subscribe(funcionarios => this._httpService.funcionarios = funcionarios);
  }

  async listFuncionarios(id: number) {
    this._httpServiceRelacao.funcionarios = await this.promiseDelay(10).then(() => this._httpService.funcionarios.slice());
    if (!this._httpServiceRelacao.listMode) {
      this._httpServiceRelacao.listMode = true;
    }
    this._httpServiceRelacao.projetoId = id;
    await this.promiseDelay(20).then(() => this._httpServiceRelacao.listFuncionarios(id)
    .subscribe(projetoFuncionarios => {
      this._httpServiceRelacao.projetoFuncionarios = projetoFuncionarios;
    }))
    await this.promiseDelay(30).then(() => this._httpServiceRelacao.projetoFuncionarios.forEach( e => {
      this._httpServiceRelacao.funcionarios = this._httpServiceRelacao.funcionarios.filter(f => e.funcionario.id !== f.id);
    }));
  }

  promiseDelay(ms) {
    return new Promise(resolve => {
      setTimeout(() => resolve('done'), ms);
    });
  }
}
