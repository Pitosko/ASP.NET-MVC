# 14474 Employees Management

## Setup
1. Garante que o SQL Server Docker está a correr: `docker ps` (container `sqlserver`)
2. `cd 14474_employees_management`
3. `dotnet restore`
4. `dotnet ef migrations add InitialCreate`
5. `dotnet ef database update`
6. `dotnet run`
7. Abre https://localhost:5001

## Notas
- Connection string em `appsettings.json` (sa / Dev@Pass123)
- AdminLTE + DataTables via CDN (sem precisar de copiar ficheiros)
- Abre no Rider: File > Open > pasta do projeto
