# Geoloc
ASP.NET Core 2.0 Web API

## Development server
Run `dotnet Geoloc.dll` for a dev server. Navigate to `http://localhost:5000/api/`

## Build
Run `dotnet build` to build the project.

## Prerequisites
Run `dotnet ef database update` to create localDB and apply migrations.

## IIS proxy (remote access)
Run `npm install -g iisexpress-proxy`, then `iisexpress-proxy 5000 to 5000`
