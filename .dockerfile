FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out
#ENTRYPOINT ["dotnet", "out/Hello.dll"]
#COPY ./install.ps1 c:/
#CMD Set-ExecutionPolicy Bypass

#SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
#WORKDIR C:/
#RUN ./install.ps1


#WORKDIR C:/ReadFormats/
#RUN nuget restore ./ReadFormats.sln

#RUN ./build.ps1

#COPY ./VuelingSchool.DataAccess.Repository/bin/Debug/RepositoryConfiguration.xml .
# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Presentation.Console.dll"]

# ENTRYPOINT powershell -command c:\OnInit.ps1

# CMD ping www.github.com