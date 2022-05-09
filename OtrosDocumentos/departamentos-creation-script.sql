-- Script de creación de base de datos para cada departamento
CREATE DATABASE IF NOT EXISTS `Departamentos`;
USE `Departamentos`;

CREATE TABLE IF NOT EXISTS `Circuitos` (
  `Numero` int NOT NULL,
  PRIMARY KEY (`Numero`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `DispositivosHabilitados` (
  `Codigo` varchar(767) NOT NULL,
  `Numero_Circuito` int NOT NULL,
  PRIMARY KEY (`Codigo`),
  KEY `IX_DispositivosHabilitados_Numero_Circuito` (`Numero_Circuito`),
  CONSTRAINT `FK_DispositivosHabilitados_Circuitos_Numero_Circuito` FOREIGN KEY (`Numero_Circuito`) REFERENCES `Circuitos` (`Numero`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `Opciones` (
  `Nombre` varchar(767) NOT NULL,
  PRIMARY KEY (`Nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `Personas` (
  `CI` varchar(12) NOT NULL,
  `VotoRealizado` tinyint(1) NOT NULL,
  PRIMARY KEY (`CI`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `Votos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Fecha` datetime NOT NULL,
  `Numero_Circuito` int NOT NULL,
  `Nombre_Opcion` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Votos_Nombre_Opcion` (`Nombre_Opcion`),
  KEY `IX_Votos_Numero_Circuito` (`Numero_Circuito`),
  CONSTRAINT `FK_Votos_Circuitos_Numero_Circuito` FOREIGN KEY (`Numero_Circuito`) REFERENCES `Circuitos` (`Numero`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Votos_Opciones_Nombre_Opcion` FOREIGN KEY (`Nombre_Opcion`) REFERENCES `Opciones` (`Nombre`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

