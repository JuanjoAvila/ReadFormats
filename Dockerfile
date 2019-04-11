FROM microsoft/dotnet:sdk AS build-env
#WORKDIR C:/ReadFormats/

# copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore

# copy and build everything else
#COPY . ./
#RUN dotnet publish -c Release -o out
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
# FROM microsoft/dotnet:aspnetcore-runtime
#WORKDIR C:/ReadFormats/
#COPY --from=build-env /app/out .
COPY ./install.ps1 c:/
CMD Set-ExecutionPolicy Bypass

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
WORKDIR C:/
RUN ./install.ps1

RUN git clone https://github.com/JuanjoAvila/ReadFormats.git

WORKDIR C:/ReadFormats/
RUN nuget restore ./ReadFormats.sln

RUN ./Build.ps1
ENTRYPOINT C:\ReadFormats\Presentation.Console\publish\Presentation.Console.exe

# ENTRYPOINT powershell -command c:\OnInit.ps1

# CMD ping www.github.com