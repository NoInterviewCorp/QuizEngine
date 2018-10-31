FROM microsoft/dotnet:sdk AS build-env
COPY . /app

WORKDIR /app

# Copy csproj and restore as distinct layers
RUN dotnet restore
RUN dotnet build
EXPOSE 80/tcp
EXPOSE 5000
EXPOSE 5001

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh