export ASPNETCORE_ENVIRONMENT=Development

dotnet ef -s src/AnimeList.API database update -c "AnimeDbContext" -p src/AnimeList.Infrastructure/AnimeList.Infrastructure.csproj --verbose