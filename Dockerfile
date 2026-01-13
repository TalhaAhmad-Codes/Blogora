# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copy backend source
COPY backend/ ./backend/

# Move into project folder (IMPORTANT)
WORKDIR /src/backend/Blogoria

RUN dotnet restore
RUN dotnet publish -c Release -o /app

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Blogoria.dll"]
