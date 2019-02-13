import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }      from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FuncionariosComponent } from './Components/funcionarios/funcionarios.component';
import { ProjetosComponent } from './Components/projetos/projetos.component';
import { MenuComponent } from './Components/menu/menu.component';
import { MessagesComponent } from './Components/messages/messages.component';
import { ProjetoFormComponent } from './Components/projeto-form/projeto-form.component';
import { ProjetoListComponent } from './Components/projeto-list/projeto-list.component';
import { FuncionarioListComponent } from './Components/funcionario-list/funcionario-list.component';
import { FuncionarioFormComponent } from './Components/funcionario-form/funcionario-form.component';

@NgModule({
  declarations: [
    AppComponent,
    FuncionariosComponent,
    ProjetosComponent,
    MenuComponent,
    MessagesComponent,
    ProjetoFormComponent,
    ProjetoListComponent,
    FuncionarioListComponent,
    FuncionarioFormComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
