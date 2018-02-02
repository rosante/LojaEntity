/*Não é necessário, o Entity Framework cria sozinho toda a base/tabelas*/

create database Loja
use Loja
create table Produto (
    idproduto int identity not null primary key,
    nome varchar(50) not null,
    descricao text not null,
    preco int not null,
    quantidade int not NULL,
    dataCadastro datetime default GetDate()
)
create table Cliente (
    idcliente int identity not null primary key,
    nome varchar(50) not null,
    email varchar(50) not null,
    idade int not null,
    dataCadastro datetime default GetDate()
)

create table Pedido (
    idpedido int identity not null primary key,
    idcliente int not null foreign key references Cliente,
    idproduto int not null foreign key references Produto,
    quantidade int not null,
    dataCadastro datetime default GetDate()
)

select * from Produto
select * from Cliente
select * from Pedido