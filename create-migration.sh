export ASPNETCORE_ENVIRONMENT=Development

dotnet ef -s src/AnimeList.API migrations add AddTableAnime -c "AnimeDbContext" -p src/AnimeList.Infrastructure/AnimeList.Infrastructure.csproj
