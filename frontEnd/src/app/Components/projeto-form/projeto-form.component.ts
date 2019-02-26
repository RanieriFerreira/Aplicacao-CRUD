import { Component, OnInit } from '@angular/core';

import { ProjetoService } from 'src/app/Services/projeto.service';
import { MessagesService } from 'src/app/Services/messages.service';
import { Projeto } from 'src/app/Models/projeto';

@Component({
  selector: 'app-projeto-form',
  templateUrl: './projeto-form.component.html',
  styleUrls: ['./projeto-form.component.scss']
})
export class ProjetoFormComponent implements OnInit {
  projeto: Projeto = new Projeto();

  constructor(
    private _httpService: ProjetoService,
    public messageService: MessagesService
    ) { 
    this._httpService.projetoInput.status = '0';
    }

  ngOnInit() {  }

  clean() {
    this._httpService.editMode = false;
    this._httpService.projetoInput = new Projeto();
    this._httpService.projetoInput.status = '0';
  }

  addProjeto(projeto: Projeto) {
    this.validate(projeto);
  }

  editProjeto(projeto: Projeto) {
    this.validate(projeto);
  }

  validate(projeto: Projeto) {
    if (projeto.id && projeto.status && projeto.nome && projeto.detalhe) { 
      this._httpService.updateProjeto(projeto)
      .subscribe(projeto => {
        if (projeto.status == '0'){
          projeto.status = 'Inativo';
        } else if (projeto.status == '1'){
          projeto.status = 'Ativo';
        } else if (projeto.status == '2'){
          projeto.status = 'Em espera';
        } else if (projeto.status == '3'){
          projeto.status = 'Finalizado';          
        }
        if (projeto.id) { 
          const ix = projeto ? this._httpService.projetos.findIndex(p => p.id === projeto.id) : -1;
          if (ix > -1) { this._httpService.projetos[ix] = projeto;};
          this.messageService.add("Projeto editado com sucesso", "Success");
          this.clean();
        } else {
          this.messageService.add("Não foi possível editar o projeto", "Error");
        }
      });
    } else if (projeto.status && projeto.nome && projeto.detalhe) { 
      this._httpService.addProjeto(projeto)
      .subscribe(projeto => {
        if (projeto.status == '0'){
          projeto.status = 'Inativo';
        } else if (projeto.status == '1'){
          projeto.status = 'Ativo';
        } else if (projeto.status == '2'){
          projeto.status = 'Em espera';
        } else if (projeto.status == '3'){
          projeto.status = 'Finalizado';          
        }
        if (projeto.id) { 
          this._httpService.projetos.push(projeto);
          this.messageService.add("Projeto adicionado com sucesso", "Success");
          this.clean();
        } else {
          this.messageService.add("Não foi possível adicionar o projeto", "Error");
        }
      });
    } else {
      this.messageService.add("Preencha todos os campos corretamente", "Error");
    }
  }
}
