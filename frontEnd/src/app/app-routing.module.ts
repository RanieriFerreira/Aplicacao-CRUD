import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjetosComponent } from './Components/projetos/projetos.component';
import { FuncionariosComponent } from './Components/funcionarios/funcionarios.component';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: '/projetos', 
    pathMatch: 'full' 
  },
  { 
    path: 'funcionarios', 
    component: FuncionariosComponent 
  },
  { 
    path: 'projetos', 
    component: ProjetosComponent 
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
