echo "Compilando Servidor Central..."
dotnet publish ./API-Servidor-Central/Central-API.sln -c Release
echo "Servidor Central compilado con exito"
echo "Compilando Servidor Departamental..."
dotnet publish ./API-Servidor-Departamento/Departments-API.sln -c Release
echo "Servidor Departamental compilado con exito"
echo "Iniciando Sistema..."
docker-compose build --no-cache 
docker-compose up --remove-orphans
