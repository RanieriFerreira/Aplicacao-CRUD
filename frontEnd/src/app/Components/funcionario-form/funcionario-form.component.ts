import { Component, OnInit } from '@angular/core';
import { Funcionario } from 'src/app/Models/funcionario';
import { FuncionarioService } from 'src/app/Services/funcionario.service';
import { MessagesService } from 'src/app/Services/messages.service';

@Component({
  selector: 'app-funcionario-form',
  templateUrl: './funcionario-form.component.html',
  styleUrls: ['./funcionario-form.component.scss']
})
export class FuncionarioFormComponent implements OnInit {

  funcionario: Funcionario = new Funcionario();

  constructor(
    private _httpService: FuncionarioService,
    public messageService: MessagesService
    ) { }

  ngOnInit() {  }

  printFuncionario() {
    console.log(this._httpService.funcionarioInput);
  }

  clean() {
    this._httpService.editMode = false;
    this._httpService.funcionarioInput = new Funcionario();
  }

  addFuncionario(funcionario: Funcionario) {
    if (funcionario.status && funcionario.nome && funcionario.cpf) { 
      //TODO - Corrigir push do novo funcionario ou remover id da listagem
      this._httpService.addFuncionario(funcionario)
      .subscribe(funcionario => this._httpService.funcionarios.push(funcionario));
      this.clean();
      this.messageService.add("Funcionario adicionado com sucesso");
    } else {
      this.messageService.add("Preencha todos os campos corretamente");
    }
  }

  editFuncionario(funcionario: Funcionario) {
    if (funcionario.id && funcionario.status && funcionario.nome && funcionario.cpf) { 
      this._httpService.updateFuncionario(funcionario)
      .subscribe(funcionario => {
        const ix = funcionario ? this._httpService.funcionarios.findIndex(p => p.id === funcionario.id) : -1;
          if (ix > -1) { this._httpService.funcionarios[ix] = funcionario; }});
      this.clean();
      this.messageService.add("Funcionario editado com sucesso");
    } else {
      this.messageService.add("Preencha todos os campos corretamente");
    }
  }
}
