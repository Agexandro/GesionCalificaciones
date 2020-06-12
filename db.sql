create database materias;
use materias;

CREATE TABLE usuario (
_idu INT PRIMARY KEY AUTO_INCREMENT,
usuario VARCHAR (100) NOT NULL,
contrasena TEXT NOT NULL);
/**
@table: usuario
@description: guarda los usuarios
*/

CREATE TABLE materia (
_idm INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
_idu INT NOT NULL,
materia VARCHAR (100) NOT NULL,
FOREIGN KEY(_idu)REFERENCES usuario(_idu) ON DELETE CASCADE ON UPDATE CASCADE);
/**
@table: materia
@description: guarda materias
*/

CREATE TABLE calificacion (
_idc int PRIMARY key AUTO_INCREMENT,
_idm INT not null,
unidad TINYINT NOT NULL,
calificacion TINYINT NOT NULL,
FOREIGN KEY(_idm)REFERENCES materia(_idm) ON DELETE CASCADE ON UPDATE CASCADE);
/**
@table: calificación
@description: guarda las calificaciones
*/

