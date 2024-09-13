dotnet ef migrations add <MIGRATION_NAME> -s ./FinanceControl.API/FinanceControl.API.csproj -p ./FinanceControl.Infrastructure/FinanceControl.Infrastructure.csproj

dotnet ef database update -s ./FinanceControl.API/FinanceControl.API.csproj -p ./FinanceControl.Infrastructure/FinanceControl.Infrastructure.csproj
