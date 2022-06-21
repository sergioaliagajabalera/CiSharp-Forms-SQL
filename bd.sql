create database ALIAGA_SERGIO_M09UF4_PRACTICA;
use ALIAGA_SERGIO_M09UF4_PRACTICA;

CREATE USER 'adminm09uf4'@'localhost' IDENTIFIED BY 'adminm09uf4';
GRANT ALL PRIVILEGES ON ALIAGA_SERGIO_M09UF4_PRACTICA . * TO 'adminm09uf4'@'localhost';
ALTER USER 'adminm09uf4'@'localhost' IDENTIFIED WITH mysql_native_password BY 'adminm09uf4';
FLUSH PRIVILEGES;

create table Usuaris(
	username varchar(100) PRIMARY KEY,
    contrasenya varchar(100)  #pasword= password
);

insert into Usuaris(username,contrasenya) values("Sergio","1234");

create table Vehicles(
	matricula varchar(100) PRIMARY KEY,
    propietari varchar(100),
    marca varchar(100),
    model varchar(100),
    caballs int,
    motor varchar(100),
    t_neumatics varchar(100),
    binfoITV boolean,
    foreign key (propietari) REFERENCES Usuaris(username) on delete cascade
);

insert into Vehicles(matricula,propietari,marca,model,caballs,motor,t_neumatics,binfoITV)
values("2F2434G","Sergio","Seat","Leon",220,"gasolina","perfil baix",true);

insert into Vehicles(matricula,propietari,marca,model,caballs,motor,t_neumatics,binfoITV)
values("GJ3405","Sergio","YAMAHA","TMAX",220,"bencina","perfil baix",false);

delete from Vehicles where matricula="";

select * from  Cotxes C, Vehicles V where (C.matricula=V.matricula) and V.propietari="Sergio";
select * from Vehicles;
create table Cotxes(
	matricula varchar(100) PRIMARY KEY,
    t_sostre varchar(100),
    t_porta varchar(100),
    foreign key (matricula) REFERENCES Vehicles(matricula) on delete cascade
);

insert into Cotxes(matricula,t_sostre,t_porta)
values("2F2434G","tancat","mariposa");
 
create table Motos(
	matricula varchar(100) PRIMARY KEY,
    t_cupula varchar(100),
    bmaleta boolean,
    foreign key (matricula) REFERENCES Vehicles(matricula) on delete cascade
);

select * from  Motos M, Vehicles V where (M.matricula=V.matricula) and V.propietari="Sergio";
select * from motos;
insert into Motos(matricula,t_cupula,bmaleta)
values("GJ3405","regulable",true);

create table MissatgesITV(
	matricula varchar(100),
	missatge varchar(350),
    foreign key (matricula) REFERENCES Vehicles(matricula) on delete cascade
);

select * from MissatgesITV;
insert into MissatgesITV(matricula,missatge)
values("GJ3405","revisio");
insert into MissatgesITV(matricula,missatge)
values("2F2434G","revisio");
insert into MissatgesITV(matricula,missatge)
values("2F2434G","Data limit revisio en 3 dies");
