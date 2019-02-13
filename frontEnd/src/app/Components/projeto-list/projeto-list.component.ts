import { Component, OnInit } from '@angular/core';
import { ProjetoService } from 'src/app/Services/projeto.service';
import { Projeto } from 'src/app/Models/projeto';

@Component({
  selector: 'app-projeto-list',
  templateUrl: './projeto-list.component.html',
  styleUrls: ['./projeto-list.component.scss']
})
export class ProjetoListComponent implements OnInit {
  
  constructor(private _httpService: ProjetoService) { }

  ngOnInit() { this.getProjetos() }


  getProjetos(): void {
    this._httpService.getProjetos()
    .subscribe(projetos => this._httpService.projetos = projetos);
  }

  searchProjetos(search: string) {
    if (search) {
      this._httpService.searchProjetos(search)
      .subscribe(projeto => this._httpService.projetos = projeto);
    }
  }

  editProjeto(projeto: Projeto) {
    this._httpService.getProjeto(projeto.id)
    .subscribe(projeto => this._httpService.projetoInput = projeto);
    this._httpService.editMode = true;
  }

  deleteProjeto(id: number): void {
    this._httpService.projetos = this._httpService.projetos.filter(projeto => projeto.id !== id);
    this._httpService.deleteProjeto(id).subscribe();
  }
}
