import { Component, OnInit } from '@angular/core';
import { ProjetoService } from '../../Services/projeto.service';
import { Projeto } from 'src/app/Models/projeto';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-projetos',
  templateUrl: './projetos.component.html',
  styleUrls: ['./projetos.component.scss'],
  providers: [ProjetoService]
})
export class ProjetosComponent implements OnInit {
  errorMessage: string = "";
  projetos: Projeto[];
  editProjeto: Projeto;
  showEdit: boolean = false;
  showNew: boolean = true;

  constructor(private _httpService: ProjetoService) { }

  ngOnInit() {
    this.getProjetos();
  }

  changeShowEdit(){this.showEdit = !this.showEdit;}
  changeShowNew(){this.showNew = !this.showNew;}

  getProjetos(): void {
    this._httpService.getProjetos()
    .subscribe(projetos => this.projetos = projetos);
  }

  searchProjetos(search: string) {
    if (search) {
      this._httpService.searchProjetos(search)
      .subscribe(projeto => this.projetos = projeto);
    }
  }

  addProjeto(status: number, nome: string, detalhe: string, id: number = undefined) {
    if (status && nome && detalhe) { 
      const newProjeto: Projeto = { id, status, nome, detalhe }
      this._httpService.addProjeto(newProjeto)
      .subscribe(projeto => this.projetos.push(projeto));
      this.errorMessage = undefined;
    } else {
      this.errorMessage = "Preencha todos os campos corretamente";
    }
  }

  deleteProjeto(id: number): void {
    this._httpService.deleteProjeto(id).subscribe();
  }

}
