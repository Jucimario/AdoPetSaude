# AdoPetSaude

# Docker
Para uso do banco é feito atravez de Docker usando o MYSQL v:8.0.32, caso queira só usar o comando abaix:
docker run --name sample-mysql -p 3308:3306 -e MYSQL_ROOT_PASSWORD=enterpassword -d mysql:8.0.32