FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer
RUN dotnet restore
RUN dotnet build
RUN dotnet ef -v
RUN dotnet ef migrations add data
RUN dotnet ef database update
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
WORKDIR /app/out
# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "asp-back.dll"]   