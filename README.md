# TCIT - CHALLENGE - .NET

Este repositorio contiene el challenge .NET de TCIT
--------------------------------------------------------------------------------------------------------------------------------------------
POSTGRESQL

Se requiere postgresql para su utilización, se debe un usuario llamado "usr_challenge" con clave "deveor.cl", debe estar de manera local (localhost).
Script para realizar la tabla necesaria para el funcionamiento de la api y web:


CREATE TABLE persona(
    id SERIAL primary key,
    nombre varchar(30) not null,
    descripcion varchar(100) not null
);
--------------------------------------------------------------------------------------------------------------------------------------------
WEB

Lamentablemente no soy programador Angular/Redux, siento mucho si les hice perder el tiempo, estoy aprendiendo angular pero no es mi fuerte, de todas maneras les dejo un frontend hecho en ASP.NET con .NET 8 el cual se comunica con la API y cumple todas las funciones requeridas por el challenge.
--------------------------------------------------------------------------------------------------------------------------------------------
API

La api realizada en .NET 8, contiene un swagger para probar los endpoint desde la misma ejecución.
