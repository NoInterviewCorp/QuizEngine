FROM microsoft/dotnet:sdk AS build-env
RUN mkdir /app
WORKDIR /app
COPY *.csproj ./
COPY . /app
COPY . ./
EXPOSE 5001
RUN ["dotnet","restore"]
RUN ["dotnet","build"]
CMD ["dotnet","run"]