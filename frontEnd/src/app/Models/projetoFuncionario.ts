import { Projeto } from './projeto';
import { Funcionario } from './funcionario';

export class ProjetoFuncionario {
    constructor (
        public funcionarioId: number = undefined,
        public projetoId: number = undefined,
        public funcionario: Funcionario = undefined,
        public projeto: Projeto = undefined
    ) {}
}