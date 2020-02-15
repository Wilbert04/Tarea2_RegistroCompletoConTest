create database RegistroTestDB
USE RegistroTestDB
GO
CREATE TABLE personaT
(
	PersonaId int primary key identity(1,1),  
	Nombres varchar(30),  
	Cedula varchar(13),
	Telefono varchar(13),
	FechaNacimiento date,   
	Balance float(12)
);
Go

CREATE TABLE inscripcionesT
(
	IncripcionId int primary key identity(1,1), 
	Fecha date, 
	EstudianteId int, 
	Comentarios varchar(max), 
	Monto float(7),
	Deposito float(7), 
	Balance float(7)
)
