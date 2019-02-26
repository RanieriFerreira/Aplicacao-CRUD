import { Component, OnInit } from '@angular/core';
import { FuncionarioService } from 'src/app/Services/funcionario.service';
import { Funcionario } from 'src/app/Models/funcionario';
import { MessagesService } from 'src/app/Services/messages.service';
import { stringify } from 'querystring';

@Component({
  selector: 'app-funcionario-list',
  templateUrl: './funcionario-list.component.html',
  styleUrls: ['./funcionario-list.component.scss']
})
export class FuncionarioListComponent implements OnInit {
  ordem = undefined;
  paginaNumero = undefined;
  paginaQuantidade = undefined;

  constructor(
    private _httpService: FuncionarioService,
    public messageService: MessagesService
  ) { }

  ngOnInit() { this.getFuncionarios(); }

  clear() {
    this.paginaNumero = undefined;
    this.paginaQuantidade = undefined;
    this.getFuncionarios();
  }

  getFuncionarios(): void {
    this._httpService.getFuncionarios()
    .subscribe(funcionarios => {
      funcionarios.forEach(funcionario => {
        if (funcionario.status == '0'){
          funcionario.status = 'Inativo';
        } else if (funcionario.status == '1'){
          funcionario.status = 'Ativo';
        } else if (funcionario.status == '2'){
          funcionario.status = 'Férias';
        } else if (funcionario.status == '3'){
          funcionario.status = 'Desligado';          
        }
      });
      this._httpService.funcionarios = funcionarios
    });
  }

  paginacaoFuncionarios(order: number, page: number, size: number) {
    if (order &&  page && size) {
      this._httpService.pagFuncionarios(order, page, size)
      .subscribe(funcionario => this._httpService.funcionarios = funcionario);
    } else {
      this.messageService.add("Preencha todos os campos da pesquisa corretamente.", "Error");
    }
  }

  editFuncionario(funcionario: Funcionario) {
    this._httpService.getFuncionario(funcionario)
    .subscribe(funcionario => this._httpService.funcionarioInput = funcionario);
    this._httpService.editMode = true;
  }

  deleteFuncionario(funcionario: Funcionario): void {
    this._httpService.deleted = Object.assign({}, funcionario);
    this._httpService.deleted.id = undefined;
    this._httpService.deleteFuncionario(funcionario).subscribe(data => {
      localStorage.setItem('LastDeleted', stringify(funcionario));
      if(data != -1) {
        this._httpService.funcionarios = this._httpService.funcionarios.filter(funcionarioList => funcionarioList.id !== funcionario.id);
        this.messageService.add("Funcionário deletado com sucesso. Caso queira desfazer a ação pressione o botão 'DESFAZER'", "Success");
      } else {
        this.messageService.add("Não foi possível deletar o funcionario.", "Error");
      }
    });
  }
}
