-- Script de creación de base de datos para cada departamento
CREATE DATABASE IF NOT EXISTS `Departamentos`;
USE `Departamentos`;

CREATE TABLE `Circuits` (
  `Number` int NOT NULL,
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `EnabledDevices` (
  `Code` varchar(767) NOT NULL,
  `Circuit_Number` int NOT NULL,
  PRIMARY KEY (`Code`),
  KEY `IX_EnabledDevices_Circuit_Number` (`Circuit_Number`),
  CONSTRAINT `FK_EnabledDevices_Circuits_Circuit_Number` FOREIGN KEY (`Circuit_Number`) REFERENCES `Circuits` (`Number`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Options` (
  `Name` varchar(767) NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Users` (
  `CI` varchar(64) NOT NULL,
  `AlreadyVoted` BOOLEAN NOT NULL,
  PRIMARY KEY (`CI`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Votes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Circuit_Number` int NOT NULL,
  `Option_Name` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Votes_Circuit_Number` (`Circuit_Number`),
  KEY `IX_Votes_Option_Name` (`Option_Name`),
  CONSTRAINT `FK_Votes_Circuits_Circuit_Number` FOREIGN KEY (`Circuit_Number`) REFERENCES `Circuits` (`Number`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Votes_Options_Option_Name` FOREIGN KEY (`Option_Name`) REFERENCES `Options` (`Name`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

