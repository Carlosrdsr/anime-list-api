export ASPNETCORE_ENVIRONMENT=Development

dotnet ef -s src/AnimeList.API migrations remove -c "AnimeDbContext" -p src/AnimeList.Infrastructure/AnimeList.Infrastructure.csproj 