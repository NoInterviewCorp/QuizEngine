FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
RUN dotnet ef migrations add data

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
WORKDIR /app/out
RUN dotnet ef database update

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "asp-back.dll"]