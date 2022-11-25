create database trabalhoapi;
use trabalhoapi;
create table endereco(
	rua varchar(200) not null,
    bairro varchar(100) not null, 
    cidade varchar(100) not null,
    estado varchar(100) not null,
    cep varchar(10) not null
);

select * from endereco;