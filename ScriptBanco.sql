use RelogioDePonto
GO
DROP TABLE Pertence;
DROP TABLE Horas;
DROP TABLE Funcionarios;
DROP TABLE Projetos;

CREATE TABLE Projetos (
                Id INT NOT NULL,
                Nome VARCHAR NOT NULL,
                Detalhe VARCHAR,
                Ativo INT,
                CONSTRAINT Projetos_pk PRIMARY KEY (Id)
);


CREATE TABLE Funciorarios (
                Cpf INT NOT NULL,
                Nome VARCHAR NOT NULL,
                CONSTRAINT Funciorarios_pk PRIMARY KEY (Cpf)
);


CREATE TABLE Horas (
                CpfFuncionarioHoras INT NOT NULL,
                IdProjetoHoras INT NOT NULL,
                Entrada DATE NOT NULL,
                Saida DATE NOT NULL,
                CONSTRAINT Horas_pk PRIMARY KEY (CpfFuncionarioHoras, IdProjetoHoras)
);


CREATE TABLE Pertence (
                CpfFuncionarioPertence INT NOT NULL,
                IdProjetoPertence INT NOT NULL,
                CONSTRAINT Pertence_pk PRIMARY KEY (CpfFuncionarioPertence, IdProjetoPertence)
);


ALTER TABLE Pertence ADD CONSTRAINT Projetos_Pertence_fk
FOREIGN KEY (IdProjetoPertence)
REFERENCES Projetos (Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Horas ADD CONSTRAINT Projetos_Horas_fk
FOREIGN KEY (IdProjetoHoras)
REFERENCES Projetos (Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Pertence ADD CONSTRAINT Funciorarios_Pertence_fk
FOREIGN KEY (CpfFuncionarioPertence)
REFERENCES Funciorarios (Cpf)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Horas ADD CONSTRAINT Funciorarios_Horas_fk
FOREIGN KEY (CpfFuncionarioHoras)
REFERENCES Funciorarios (Cpf)
ON DELETE NO ACTION
ON UPDATE NO ACTION;