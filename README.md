dotnet ef migrations add <MIGRATION_NAME> -s ./FinanceControl.API/FinanceControl.API.csproj -p ./FinanceControl.Infrastructure/FinanceControl.Infrastructure.csproj

dotnet ef database update -s ./FinanceControl.API/FinanceControl.API.csproj -p ./FinanceControl.Infrastructure/FinanceControl.Infrastructure.csproj


sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SQLSERVER_express2024@" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name SQLSERVER_EXPRESS --hostname SQLSERVER_EXPRESS -d mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

sudo docker exec -it "SQLSERVER_EXPRESS" /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "SQLSERVER_express2024@"