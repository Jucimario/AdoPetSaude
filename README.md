# AdoPetSaude

# Docker
Para uso do banco é feito atravez de Docker usando o MYSQL v:8.0.32, caso queira só usar o comando abaix:
docker run --name sample-mysql -p 3308:3306 -e MYSQL_ROOT_PASSWORD=enterpassword -d mysql:8.0.32

* use o bando de dados de sua escolha

#Criando as tabelas

*No Visual Studio abre o Maneger Console
	Tools > Nuget Package Manager > Package Manage Console.
	
use o comando para criar as migrations

add-migrations NomeMigrationDeSuaPreferencia

apos execute o comando:

update-database