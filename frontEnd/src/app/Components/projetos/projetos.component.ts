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
  clickMessage: string = "";
  projetos: Projeto[];
  
  constructor(private _httpService: ProjetoService) { }

  ngOnInit() {
    this.getProjetos();
  }

  getProjetos() {
    this._httpService.getProjetos()
    .subscribe(projetos => this.projetos = projetos);
  }

}
