# heroku-netcore2.2-mysql
NET CORE 2.2 Web API with Basic Authentication with MySQL pushed to Heroku using Docker

# DEMO
https://web-api-netcore-22-mysql-free.herokuapp.com/api/BancoNacion/GetQuotes

# External Service
https://bna.com.ar/Mobile/CotizadorMobile

# DATABASE FREE CLOUD
https://www.freesqldatabase.com

# CLOUD API
https://heroku.com

# Tutorials
- https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe
- https://medium.com/faun/deploy-dotnet-core-api-docker-container-with-mysql-on-heroku-ed387eab4222
- https://softchris.github.io/pages/dotnet-dockerize.html

# Requirements
- NET CORE 2.2
- MYSQL 5
- DOCKER

# Dockerfiles
In project WebAPI

# Create Database
- You can use Update-Database from Package Manage Console or
- "dotnet tool install --global dotnet-ef" and "dotnet ef database update" or
- use .sql in the repo

# USO DE LA API
- Use POSTMAN with Basic Authentication 
- username: bna
- password: 123456

# Subir Aplicacion a Heroku

## 0) Crear cuenta en Heroku (y Docker por supuesto)
- Crear una aplicacion nueva de nombre similar a web-api-netcore-22-mysql-free en Heroku

## 1) Comprobar y Loguear en Heroku
- heroku --version
- heroku login
- heroku container:login

## 2) Crear docker image y correrlo local (Puede que haya que modificar parte del dockerfile la parte final, ver archivos y comentarios)
- dotnet build
- dotnet run
- docker build -t banco-nacion-webapi-mysql .
- docker run -d -p 8080:80 --name abc banco-nacion-webapi-mysql

## 3) Crear docker image para montarlo
- docker build --pull -t banco-nacion-webapi-mysql . (banco-nacion-webapi-mysql es el nombre nuestro proyecto imagen docker)

## 4) Asociar el docker image anterior con la app creada en heroku
- docker tag banco-nacion-webapi-mysql registry.heroku.com/web-api-netcore-22-mysql-free/web (web-api-netcore-22-mysql-free es la aplicacion que tenemos que tener creada de antemano en Heroku

## 5) Enviar docker image a la app
- docker push registry.heroku.com/web-api-netcore-22-mysql-free/web

## 6) Iniciar app con la imagen enviada
- heroku container:release web -a web-api-netcore-22-mysql-free

## 7) Comprobar si funciona
- https://web-api-netcore-22-mysql-free.herokuapp.com/api/BancoNacion/GetQuotes
- Ver logs en dashboard Heroku
- heroku logs --tail -a web-api-netcore-22-mysql-free
