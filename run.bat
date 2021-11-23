@ECHO OFF
mkdir Publish
ECHO Publishing solution
dotnet publish "College System Management\College System Management\College System Management.csproj" --output Publish
start chrome https://localhost:5001/ 
"Publish\College System Management.exe"
PAUSE