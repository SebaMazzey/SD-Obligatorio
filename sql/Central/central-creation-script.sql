-- Script de creación de base de datos para cada departamento
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
  `TotalVotes` int NOT NULL,
  `Election_Id` int NOT NULL,
  PRIMARY KEY (`Name`),
  KEY `IX_Options_Election_Id` (`Election_Id`),
  CONSTRAINT `FK_Options_Election_Election_Id` FOREIGN KEY (`Election_Id`) REFERENCES `Election` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `DepartamentalVotes` (
  `Option_Name` varchar(100) NOT NULL,
  `Department_Name` varchar(100) NOT NULL,
  `VotesCount` int NOT NULL,
  PRIMARY KEY (`Department_Name`,`Option_Name`),
  KEY `IX_DepartamentalVotes_Option_Name` (`Option_Name`),
  CONSTRAINT `FK_DepartamentalVotes_Departments_Department_Name` FOREIGN KEY (`Department_Name`) REFERENCES `Departments` (`Name`) ON DELETE RESTRICT,
  CONSTRAINT `FK_DepartamentalVotes_Options_Option_Name` FOREIGN KEY (`Option_Name`) REFERENCES `Options` (`Name`) ON DELETE RESTRICT
);
