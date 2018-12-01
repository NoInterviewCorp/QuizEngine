FROM microsoft/dotnet:sdk AS build-env
RUN mkdir /app
WORKDIR /app
COPY *.csproj ./
COPY . /app
# Copy csproj and restore as distinct layers
COPY . ./
EXPOSE 5001
# RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer
RUN ["dotnet","restore"]
RUN ["dotnet","build"]
RUN ["dotnet","run"]
# RUN dotnet ef -v
# RUN dotnet ef migrations add data
# RUN chmod +x ./docker_entrypoint.sh
# CMD /bin/bash ./docker_entrypoint.sh  

