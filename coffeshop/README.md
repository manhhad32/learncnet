# Create a project:
```sh
dotnet new webapi -n coffeshop
```
# add co-lib
```sh
cd /coffeshop
```
```sh
dotnet add package co-lib --version 1.0.0 --source ../co-lib/bin/Release
```
# Add reference src lib
```sh
dotnet add reference ../co-lib/co-lib.csproj
```
# Build and publish:
```sh
dotnet publish -c Release -o ./publish
```
