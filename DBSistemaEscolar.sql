create database DBSistemaEscolar

use DBSistemaEscolar

CREATE TABLE Cuentas(
idCuenta int not null identity(1,1) primary key,
Correo varchar(50) not null,
Password varchar(30) not null
)
go

CREATE TABLE Alumno (
idAlumno int not null identity(1,1) primary key,
nombreAlumno varchar(30) not null,
apellidoPaternoAlumno varchar(30) not null,
apellidoMaternoAlumno varchar(30) not null,
matricula varchar(30) not null,
curp varchar(max) not null,
fechaIngreso datetime not null,
fechaBaja varchar(max) null,
estatus varchar(25) not null,
gradoEscolar varchar(max) not null,
nivelEducativo varchar(max) not null
);
go

CREATE TABLE Contactos(
idContacto int not null identity(1,1) primary key,
idAlumno int not null,
nombreContacto varchar(30) not null,
apellidoPaternoContacto varchar(30) not null,
apellidoMaternoContacto varchar(30) not null,
telefono varchar(10) not null,
calle varchar(20) not null,
colonia varchar(20) not null,
numeroExterior varchar(15) not null,
numeroInterior varchar(15) null,
codigoPostal varchar (10) not null,
estado varchar(10) not null,
parentesco varchar(30) not null

CONSTRAINT fkidContacto
FOREIGN KEY (idAlumno)
REFERENCES Alumno(idAlumno)
ON DELETE CASCADE
)