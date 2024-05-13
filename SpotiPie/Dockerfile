FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.18
EXPOSE 8080
WORKDIR /app
RUN apk update
RUN apk add icu-libs
COPY ../publish .
ENTRYPOINT ["dotnet", "./SpotiPie.dll"]