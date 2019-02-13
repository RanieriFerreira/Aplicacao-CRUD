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
  constructor(private _httpService: ProjetoService) { }

  ngOnInit() { }

}
