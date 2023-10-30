# Framework
.net core 6.0

# Tests
Some selection of unittests for business logic and repository 
MsTest testing Framework 
Moq mocking Framework 

# General 
Manual mapping and validation
Code-first with EF postgres 

# Usage 
Setup database connectionstring found in the appsettings.json
Run Update-Database from package management console PM>Update-Database
Run web api project (will default to swagger index)
Test api through swagger UI

Add new migrations with EF
eg. Gyldendal.Customer.Data>dotnet ef migrations -v add <MigrationName> -p .\Gyldendal.Customer.Data.csproj -s ..\Gyldendal.Customer.WebApi\Gyldendal.Customer.WebApi.csproj
remove
Gyldendal.Customer.Data>dotnet ef migrations -v remove -p .\Gyldendal.Customer.Data.csproj -s ..\Gyldendal.Customer.WebApi\Gyldendal.Customer.WebApi.csproj





