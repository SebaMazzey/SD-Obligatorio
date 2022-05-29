-- Script de creación de base de datos para cada departamento
CREATE DATABASE IF NOT EXISTS `Departments`;
USE `Departments`;

CREATE TABLE `Circuits` (
  `Number` int NOT NULL,
  PRIMARY KEY (`Number`)
);

CREATE TABLE `Options` (
  `Name` varchar(767) NOT NULL,
  PRIMARY KEY (`Name`)
);

CREATE TABLE `Users` (
  `CI` varchar(64) NOT NULL,
  `Already_Voted` BOOLEAN NOT NULL DEFAULT '0',
  PRIMARY KEY (`CI`)
);

CREATE TABLE `Votes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Circuit_Number` int NOT NULL,
  `Option_Name` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Votes_Circuit_Number` (`Circuit_Number`),
  KEY `IX_Votes_Option_Name` (`Option_Name`),
  CONSTRAINT `FK_Votes_Circuits_Circuit_Number` FOREIGN KEY (`Circuit_Number`) REFERENCES `Circuits` (`Number`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Votes_Options_Option_Name` FOREIGN KEY (`Option_Name`) REFERENCES `Options` (`Name`) ON DELETE RESTRICT
);

CREATE TABLE `Tokens` (
  `Token` varchar(100) NOT NULL,
  `Ci` varchar(64) NOT NULL,
  `Expiration_Date` datetime NOT NULL,
  PRIMARY KEY (`Token`),
  KEY `Tokens_FK` (`Ci`),
  CONSTRAINT `Tokens_FK` FOREIGN KEY (`Ci`) REFERENCES `Users` (`CI`)
);
