import { Component, OnInit } from '@angular/core';
import { ProjetoService } from 'src/app/Services/projeto.service';
import { Projeto } from 'src/app/Models/projeto';
import { MessagesService } from 'src/app/Services/messages.service';

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
    public messageService: MessagesService
  ) { }

  ngOnInit() { this.getProjetos() }

  clear() {
    this.searchInput = undefined;
    this.getProjetos();
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
