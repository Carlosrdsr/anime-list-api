export ASPNETCORE_ENVIRONMENT=Development

dotnet ef -s src/AnimeList.API migrations script 20250216043816_AddTableAnime -c "AnimeDbContext" -p src/AnimeList.Infrastructure/AnimeList.Infrastructure.csproj -o script.sql --verbose