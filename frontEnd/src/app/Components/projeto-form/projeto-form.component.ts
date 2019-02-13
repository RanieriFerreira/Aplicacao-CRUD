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
    ) { }

  ngOnInit() {  }

  printProjeto() {
    console.log(this._httpService.projetoInput);
  }

  clean() {
    this._httpService.editMode = false;
    this._httpService.projetoInput = new Projeto();
  }

  addProjeto(projeto: Projeto) {
    if (projeto.status && projeto.nome && projeto.detalhe) { 
      //TODO - Corrigir push do novo projeto ou remover id da listagem
      this._httpService.addProjeto(projeto)
      .subscribe(projeto => this._httpService.projetos.push(projeto));
      this.clean();
      this.messageService.add("Projeto adicionado com sucesso");
    } else {
      this.messageService.add("Preencha todos os campos corretamente");
    }
  }

  editProjeto(projeto: Projeto) {
    if (projeto.id && projeto.status && projeto.nome && projeto.detalhe) { 
      this._httpService.updateProjeto(projeto)
      .subscribe(projeto => {
        const ix = projeto ? this._httpService.projetos.findIndex(p => p.id === projeto.id) : -1;
          if (ix > -1) { this._httpService.projetos[ix] = projeto; }});
      this.clean();
      this.messageService.add("Projeto editado com sucesso");
    } else {
      this.messageService.add("Preencha todos os campos corretamente");
    }
  }
}
