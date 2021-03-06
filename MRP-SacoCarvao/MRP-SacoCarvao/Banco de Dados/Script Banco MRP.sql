DROP DATABASE IF EXISTS MRP;

CREATE DATABASE MRP;
USE MRP;

CREATE TABLE PRODUTO (
 idProduto int primary key,
 nomeProduto varchar(100) not null,
 descrProduto varchar(1000),
 qtdeMinEstoque int,
 qtdeMaxEstoque int,
 qtdeAtualEstoque int,
 altura decimal(5,2),
 comprimento decimal(5,2),
 largura decimal(5,2),
 peso decimal(5,2),
 especificacao varchar(8000),
 idGrupo int not null
);

CREATE TABLE GRUPO (
 idGrupo int primary key,
 nomeGrupo varchar(100) not null
 );
 
ALTER TABLE PRODUTO 
ADD CONSTRAINT FK_PRODUTO_GRUPO
FOREIGN KEY (idGrupo) REFERENCES GRUPO(idGrupo);

CREATE TABLE COMPONENTE (
 idComponente int primary key,
 nomeComponente varchar(100) not null,
 descrComponente varchar(1000),
 qtdeMinEstoque int,
 qtdeMaxEstoque int,
 qtdeAtualEstoque int,
 especificacao varchar(8000)
);

CREATE TABLE ESTRUTURAPRODUTO (
  idProduto int not null,
  idComponente int not null,
  qtdeComponente int not null,
  primary key (idProduto, idComponente)
);

ALTER TABLE ESTRUTURAPRODUTO 
ADD CONSTRAINT FK_ESTRUTURAPRODUTO_PRODUTO
FOREIGN KEY (idProduto) REFERENCES PRODUTO(idProduto);

ALTER TABLE ESTRUTURAPRODUTO 
ADD CONSTRAINT FK_ESTRUTURAPRODUTO_COMPONENTE
FOREIGN KEY (idComponente) REFERENCES COMPONENTE(idComponente);

CREATE TABLE FORNECEDOR (
 idFornecedor int primary key,
 nomeFornecedor varchar(100),
 tipoLogradouro varchar(20),
 logradouro varchar(150),
 numero varchar(30),
 complemento varchar(50),
 cep char(8),
 bairro varchar(50),
 cidade varchar(50),
 uf char(2),
 telefone varchar(20),
 celular varchar(20),
 email varchar(30),
 urlSite varchar(100)
);

CREATE TABLE FORNECEDORCOMPONENTE (
  idFornecedor int not null,
  idComponente int not null,
  qtdeAtualEstoque int not null,
  preco decimal(10,2),
  primary key (idFornecedor, idComponente)
);

ALTER TABLE FORNECEDORCOMPONENTE 
ADD CONSTRAINT FK_FORNECEDORCOMPONENTE_FORNECEDOR
FOREIGN KEY (idFornecedor) REFERENCES FORNECEDOR(idFornecedor);

ALTER TABLE FORNECEDORCOMPONENTE 
ADD CONSTRAINT FK_FORNECEDORCOMPONENTE_COMPONENTE
FOREIGN KEY (idComponente) REFERENCES COMPONENTE(idComponente);

CREATE TABLE MOVIMENTACAOESTOQUEPRODUTO (
  idMovimentacaoProduto int primary key,
  dataMovimentacao date not null,
  tipoDocumento varchar(30) not null,
  nrDocumento varchar(30) not null,
  tipoMovimentacao char(1) not null,
  qtde int not null,
  idProduto int not null
);

ALTER TABLE MOVIMENTACAOESTOQUEPRODUTO 
ADD CONSTRAINT FK_MOVIMENTACAOESTOQUEPRODUTO_PRODUTO
FOREIGN KEY (idProduto) REFERENCES Produto(idProduto);

CREATE TABLE MOVIMENTACAOESTOQUECOMPONENTE (
  idMovimentacaoComponente int primary key,
  dataMovimentacao date not null,
  tipoDocumento varchar(30) not null,
  nrDocumento varchar(30) not null,
  tipoMovimentacao char(1) not null,
  qtde int not null,
  idComponente int not null
);

ALTER TABLE MOVIMENTACAOESTOQUECOMPONENTE 
ADD CONSTRAINT FK_MOVIMENTACAOESTOQUECOMPONENTE_COMPONENTE
FOREIGN KEY (idComponente) REFERENCES COMPONENTE(idComponente);

-- DADOS
INSERT INTO GRUPO VALUES (1,'Notebook'), (2,'Desktop'), (3,'Tablet'), (4,'Celular');

INSERT INTO PRODUTO VALUES (1, 'Notebook A3', 'Notebook A3 A315-33-C58D Intel Celeron N3060 15,6" 4GB HD 500 GB Linux', 10, 200, 50, null, null, null, null, null, 1);  
INSERT INTO PRODUTO VALUES (2, 'Notebook S145', 'Notebook S145 81WT0006BR Intel Celeron N4020 15,6" 4GB SSD 128 GB Windows', 10, 200, 50, null, null, null, null, null, 1);  
INSERT INTO PRODUTO VALUES (3, 'Notebook P', 'Notebook P Motion Plus Q464B Intel Atom 14" 4GB eMMC', 10, 200, 50, null, null, null, null, null, 1);  
INSERT INTO PRODUTO VALUES (4, 'Notebook S', 'Notebook S Book E20 NP550XCJ-KO2BR Intel Celeron 5205U 15,6" 4GB HD 500 GB', 10, 200, 50, null, null, null, null, null, 1);  

INSERT INTO COMPONENTE VALUES 
 (1, 'Intel Celeron N3060','Intel Celeron N3060', 100, 1000, 200, NULL)
,(2, 'Intel Celeron N4020','Intel Celeron N4020', 100, 1000, 200, NULL)
,(3, 'Intel Core i5 1035G1','Intel Core i5 1035G1', 100, 1000, 200, NULL)
,(4, 'Intel Core i3 10110U','Intel Core i3 10110U', 100, 1000, 200, NULL)
,(5, 'Intel Core i5 9300H','Intel Core i5 9300H', 100, 1000, 200, NULL)
,(6, 'HD 500 GB','HD 500 GB', 100, 1000, 200, NULL)
,(7, 'HD 1 TB','HD 1 TB', 100, 1000, 200, NULL)
,(8, 'SSD 500 GB','SSD 500 GB', 100, 1000, 200, NULL)
,(9, 'Mem??ria RAM 4 GB','Mem??ria RAM 4 GB', 100, 1000, 200, NULL)
,(10, 'Mem??ria RAM 8 GB','Mem??ria RAM 8 GB', 100, 1000, 200, NULL)
,(11, 'Tela Notebook 15.6"','Tela Notebook 15.6"', 100, 1000, 200, NULL)
,(12, 'Tela Notebook 14"','Tela Notebook 14"', 100, 1000, 200, NULL)
,(13, 'Windows 10','Windows 10', 100, 1000, 200, NULL)
,(14, 'Linux Ubuntu 20.04.2.0 LTS','Linux Ubuntu 20.04.2.0 LTS', 100, 1000, 200, NULL)
,(15, 'Linux Mint 20.1 Ulyssa','Linux Mint 20.1 Ulyssa', 100, 1000, 200, NULL)
,(16, 'Mem??ria RAM 16 GB','Mem??ria RAM 16 GB', 100, 1000, 200, NULL);

INSERT INTO ESTRUTURAPRODUTO VALUES 
   (1,  1, 1) ,(1,  6, 1) ,(1,  9, 1) ,(1, 11, 1) ,(1, 14, 1)
  ,(2,  2, 1) ,(2,  6, 1) ,(2,  9, 1) ,(2, 11, 1) ,(2, 15, 1)
  ,(3,  2, 1) ,(3,  6, 1) ,(3,  9, 1) ,(3, 12, 1) ,(3, 13, 1)
  ,(4,  2, 1) ,(4,  7, 1) ,(4,  9, 1) ,(4, 11, 1) ,(4, 13, 1);
  
CREATE VIEW vProdutos as
SELECT 
 p.idProduto,
 p.nomeProduto,
 c.idComponente,
 c.nomeComponente,
 g.idGrupo,
 g.nomeGrupo
From Produto p
Inner Join EstruturaProduto pe On (p.idProduto = pe.IdProduto)
Inner Join Componente c On (c.idComponente = pe.idComponente) 
Inner Join Grupo g On (g.idGrupo = p.idGrupo)
Order by p.IdProduto;

USE mrp;
DROP USER IF EXISTS 'mrp'@'localhost';
CREATE USER 'mrp'@'localhost' IDENTIFIED BY 'mrp';
GRANT ALL ON *.* TO 'mrp'@'localhost';
FLUSH PRIVILEGES;
