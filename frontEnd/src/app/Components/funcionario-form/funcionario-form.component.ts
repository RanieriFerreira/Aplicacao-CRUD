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

  ngOnInit() { }

  clean() {
    this._httpService.editMode = false;
    this._httpService.funcionarioInput = new Funcionario();
  }

  addFuncionario(funcionario: Funcionario) {
    this.validation(funcionario);
  }

  editFuncionario(funcionario: Funcionario) {
    this.validation(funcionario);
  }

  validation(funcionario: Funcionario) {
    if (funcionario.id && funcionario.status && funcionario.nome && funcionario.cpf) { 
      this._httpService.updateFuncionario(funcionario)
      .subscribe(funcionario => {
        if (funcionario.id) { 
          const ix = funcionario ? this._httpService.funcionarios.findIndex(p => p.id === funcionario.id) : -1;
          if (ix > -1) { this._httpService.funcionarios[ix] = funcionario;};
          this.messageService.add("Funcionario modificado com sucesso", "Success");
          this.clean();
        } else {
          this.messageService.add("Não foi possível modificar o funcionario", "Error");
        }
      });
    } else if (funcionario.status && funcionario.nome && funcionario.cpf) { 
      this._httpService.addFuncionario(funcionario)
      .subscribe(funcionario => {
          if (funcionario.id) { 
            this._httpService.funcionarios.push(funcionario);
            this.messageService.add("Funcionario adicionado com sucesso", "Success");
            this.clean();
          } else {
            this.messageService.add("Não foi possível adicionar o funcionario", "Error");
          }
      });
    } else {
      this.messageService.add("Preencha todos os campos corretamente", "Error");
    }
  }
}
