-- Script de creación de base de datos para el servidor central
CREATE DATABASE IF NOT EXISTS `Central`;
USE `Central`;

CREATE TABLE `Election` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Start_Date` datetime NOT NULL,
  `End_Date` datetime NOT NULL,
  PRIMARY KEY (`Id`)
);

CREATE TABLE `Departments` (
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Name`)
);

CREATE TABLE `Options` (
  `Name` varchar(100) NOT NULL,
  `TotalVotes` int(11) NOT NULL DEFAULT '0',
  `Election_Id` int(11) NOT NULL,
  PRIMARY KEY (`Name`, `Election_Id`),
  KEY `IX_Options_Election_Id` (`Election_Id`),
  CONSTRAINT `FK_Options_Election_Election_Id` FOREIGN KEY (`Election_Id`) REFERENCES `Election` (`Id`)
);

CREATE TABLE `DepartmentalVotes` (
  `Option_Name` varchar(100) NOT NULL,
  `Department_Name` varchar(100) NOT NULL,
  `VotesCount` int(11) NOT NULL,
  PRIMARY KEY (`Department_Name`,`Option_Name`),
  KEY `IX_DepartamentalVotes_Option_Name` (`Option_Name`),
  CONSTRAINT `FK_DepartamentalVotes_Departments_Department_Name` FOREIGN KEY (`Department_Name`) REFERENCES `Departments` (`Name`),
  CONSTRAINT `FK_DepartamentalVotes_Options_Option_Name` FOREIGN KEY (`Option_Name`) REFERENCES `Options` (`Name`)
);


INSERT INTO Central.Election
(Id, Name, Start_Date, End_Date)
VALUES(1, 'Referendum LUC', '2022-05-31 00:07:00', '2022-05-31 00:19:00');

-- Opciones de Voto
INSERT INTO Central.`Options` (Name, Election_Id) VALUES ('Voto Si', 1), ('Voto No', 1), ('Voto Anulado', 1), ('Voto en Blanco', 1); 

INSERT INTO Central.Departments VALUES ('Artigas')
, ('Canelones')
, ('Cerro Largo')
, ('Colonia')
, ('Durazno')
, ('Flores')
, ('Lavalleja')
, ('Florida')
, ('Maldonado')
, ('Montevideo')
, ('Paysandu')
, ('Rio Negro')
, ('Rivera')
, ('Rocha')
, ('Salto')
, ('San Jose')
, ('Soriano')
, ('Tacuarembo')
, ('Treinta y Tres')
