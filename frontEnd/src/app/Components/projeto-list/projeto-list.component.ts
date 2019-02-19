import { Component, OnInit } from '@angular/core';

import { ProjetoService } from 'src/app/Services/projeto.service';
import { Projeto } from 'src/app/Models/projeto';
import { MessagesService } from 'src/app/Services/messages.service';
import { ListRelacoesService } from 'src/app/Services/list-relacoes.service';
import { FuncionarioService } from 'src/app/Services/funcionario.service';

@Component({
  selector: 'app-projeto-list',
  templateUrl: './projeto-list.component.html',
  styleUrls: ['./projeto-list.component.scss']
})
export class ProjetoListComponent implements OnInit {
  searchInput = undefined;
  securityFlag: boolean = true;

  constructor(
    private _httpService: ProjetoService,
    private _httpServiceRelacao: ListRelacoesService,
    private _httpServiceFuncionario: FuncionarioService,
    public messageService: MessagesService
  ) { }

  ngOnInit() { 
    this.getProjetos();
    this.getFuncionarios();
    this._httpServiceFuncionario.getFuncionarios()}

  clear() {
    this.searchInput = undefined;
    this.getProjetos();
  }

  promiseDelay(ms) {
    return new Promise(resolve => {
      setTimeout(() => resolve('done'), ms);
    });
  }

  getFuncionarios(): void {
    this._httpServiceFuncionario.getFuncionarios()
    .subscribe(funcionarios => this._httpServiceFuncionario.funcionarios = funcionarios);
  }

  async listFuncionarios(id: number) {
    this._httpServiceRelacao.funcionarios = await this.promiseDelay(10).then(() => this._httpServiceFuncionario.funcionarios.slice());
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

  getProjetos(): void {
    this._httpService.getProjetos()
    .subscribe(projetos => this._httpService.projetos = projetos);
  }

  searchProjetos(search: string) {
    if (search) {
      this._httpService.searchProjetos(search)
      .subscribe(projeto => this._httpService.projetos = projeto);
      this.securityFlag = false;
    } else  if (!this.securityFlag) {
      this.getProjetos();
      this.securityFlag = true;
    }
  }

  editProjeto(projeto: Projeto) {
    this._httpService.getProjeto(projeto.id)
    .subscribe(projeto => this._httpService.projetoInput = projeto);
    this._httpService.editMode = true;
  }

  deleteProjeto(projeto: Projeto): void {
    this._httpService.deleteProjeto(projeto.id).subscribe(data => {
      if(data != -1) {
        this._httpService.projetos = this._httpService.projetos.filter(projetosList => projetosList.id !== projeto.id);
        this.messageService.add("Projeto deletado com sucesso.", "Success");
      } else {
        this.messageService.add("Não foi possível deletar o projeto.", "Error");
      }
    });
  }
}
