
CREATE TABLE Projetos (
                Id NUMERIC NOT NULL,
                Nome VARCHAR NOT NULL,
                Detalhe VARCHAR,
                Ativo BOOLEAN,
                CONSTRAINT Projetos_pk PRIMARY KEY (Id)
);


CREATE TABLE Funciorarios (
                Cpf NUMERIC NOT NULL,
                Nome VARCHAR NOT NULL,
                CONSTRAINT Funciorarios_pk PRIMARY KEY (Cpf)
);


CREATE TABLE Horas (
                CpfFuncionarioHoras NUMERIC NOT NULL,
                IdProjetoHoras NUMERIC NOT NULL,
                Entrada DATE NOT NULL,
                Saida DATE NOT NULL,
                CONSTRAINT Horas_pk PRIMARY KEY (CpfFuncionarioHoras, IdProjetoHoras)
);


CREATE TABLE Pertence (
                CpfFuncionarioPertence NUMERIC NOT NULL,
                IdProjetoPertence NUMERIC NOT NULL,
                CONSTRAINT Pertence_pk PRIMARY KEY (CpfFuncionarioPertence, IdProjetoPertence)
);


ALTER TABLE Pertence ADD CONSTRAINT Projetos_Pertence_fk
FOREIGN KEY (IdProjetoPertence)
REFERENCES Projetos (Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE Horas ADD CONSTRAINT Projetos_Horas_fk
FOREIGN KEY (IdProjetoHoras)
REFERENCES Projetos (Id)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE Pertence ADD CONSTRAINT Funciorarios_Pertence_fk
FOREIGN KEY (CpfFuncionarioPertence)
REFERENCES Funciorarios (Cpf)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE Horas ADD CONSTRAINT Funciorarios_Horas_fk
FOREIGN KEY (CpfFuncionarioHoras)
REFERENCES Funciorarios (Cpf)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;
