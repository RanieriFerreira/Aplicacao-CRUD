import { Component, OnInit } from '@angular/core';
import { FuncionarioService } from 'src/app/Services/funcionario.service';
import { Funcionario } from 'src/app/Models/funcionario';

@Component({
  selector: 'app-funcionario-list',
  templateUrl: './funcionario-list.component.html',
  styleUrls: ['./funcionario-list.component.scss']
})
export class FuncionarioListComponent implements OnInit {

  constructor(private _httpService: FuncionarioService) { }

  ngOnInit() { this.getFuncionarios() }


  getFuncionarios(): void {
    this._httpService.getFuncionarios()
    .subscribe(funcionarios => this._httpService.funcionarios = funcionarios);
  }

  paginacaoFuncionarios(order: number, page: number, size: number) {
    if (order &&  page && size) {
      this._httpService.pagFuncionarios(order, page, size)
      .subscribe(funcionario => this._httpService.funcionarios = funcionario);
    }
  }

  editFuncionario(funcionario: Funcionario) {
    this._httpService.getFuncionario(funcionario.cpf)
    .subscribe(funcionario => this._httpService.funcionarioInput = funcionario);
    this._httpService.editMode = true;
  }

  deleteFuncionario(funcionario: Funcionario): void {
    this._httpService.funcionarios = this._httpService.funcionarios.filter(funcionarioList => funcionarioList.id !== funcionario.id);
    this._httpService.deleteFuncionario(funcionario).subscribe();
  }
}
