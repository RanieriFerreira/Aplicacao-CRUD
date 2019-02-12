import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FuncionariosComponent } from './Components/funcionarios/funcionarios.component';
import { ProjetosComponent } from './Components/projetos/projetos.component';
import { MenuComponent } from './Components/menu/menu.component';
import { ProjetoEditComponent } from './Components/projeto-edit/projeto-edit.component';
import { ProjetoNovoComponent } from './Components/projeto-novo/projeto-novo.component';

@NgModule({
  declarations: [
    AppComponent,
    FuncionariosComponent,
    ProjetosComponent,
    MenuComponent,
    ProjetoEditComponent,
    ProjetoNovoComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
