# heroku-netcore2.2-mysql
NET CORE Web API 2.2 with MySQL pushed to Heroku

#DEMO
https://web-api-netcore-22-mysql-free.herokuapp.com/api/BancoNacion/GetQuotes

#External Service
https://bna.com.ar/Mobile/CotizadorMobile

#DATABASE FREE CLOUD
https://www.freesqldatabase.com

#CLOUD API
https://heroku.com

#Tutorials
- https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe
- https://medium.com/faun/deploy-dotnet-core-api-docker-container-with-mysql-on-heroku-ed387eab4222
- https://softchris.github.io/pages/dotnet-dockerize.html

#Requirements
- NET CORE 2.2
- MYSQL 5
- DOCKER

#Dockerfiles
In project WebAPI

#Create Database
- You can use Update-Database from Package Manage Console or
- "dotnet tool install --global dotnet-ef" and "dotnet ef database update" or
- use .sql in the repo

#Comprobar que anda Heroku CLI
heroku --version
heroku login
heroku container:login

#Crear docker image y correrlo local
docker build -t banco-nacion-webapi-mysql .
docker run -d -p 8080:80 --name abc banco-nacion-webapi-mysql

#Crear docker image para montarlo
docker build --pull -t banco-nacion-webapi-mysql .
#Asociar el docker image anterior con la app creada en heroku
docker tag banco-nacion-webapi-mysql registry.heroku.com/web-api-netcore-22-mysql-free/web
#Enviar docker image a la app
docker push registry.heroku.com/web-api-netcore-22-mysql-free/web
#Iniciar app con la imagen enviada
heroku container:release web -a web-api-netcore-22-mysql-free
