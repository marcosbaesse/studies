FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY . ./

ENTRYPOINT [ "dotnet", "run", "--project", "./console-app/console-app.csproj" ]
