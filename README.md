Este é um projeto para prática de desenvolvimento.
Se trata de uma API para controle financeiro.

Tópicos que pretendo exercitar neste projeto:
- Organização e estruturação do projeto seguindo os conceitos de SOLID e arquitetura limpa
- Uso fluente da orientação a objetos para solução dos problemas
- Uso do EntityFramewrok (Já que é uma ferramenta com a qual não estou habituado)
- Uso de controle de autenticação e autorização terceiro (Identity Framework)
- Hospedar a aplicação em um AKS para permitir escalabilidade
- Centralizar dados de cache no redis
- Criar dockerfiles para configurar o ambiente

Aqui seguem alguns comandos que podem facilitar o uso do projeto caso deseje baixar:

A criação das migrations precisa ser executada da seguinte forma devido aos arquivos de configuração de StartUp estarem em um projeto e os arquivos de dataContext estarem em outro projeto.
- dotnet ef migrations add <MIGRATION_NAME> -s ./FinanceControl.API/FinanceControl.API.csproj -p ./FinanceControl.Infrastructure/FinanceControl.Infrastructure.csproj
- dotnet ef database update -s ./FinanceControl.API/FinanceControl.API.csproj -p ./FinanceControl.Infrastructure/FinanceControl.Infrastructure.csproj

A criação do container para rodar SqlServer no docker:
- sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SQLSERVER_express2024@" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name SQLSERVER_EXPRESS --hostname SQLSERVER_EXPRESS -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04
- sudo docker exec -it "SQLSERVER_EXPRESS" /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "SQLSERVER_express2024@"
