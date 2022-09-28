using Microsoft.Data.Sqlite;
namespace Assignment3.Entities.Tests;

using Assignment3;
using Assignment3.Core;

public sealed class TagRepositoryTests
{
    private readonly KanbanContext _context;
    private readonly TagRepository _repository;

    public TagRepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<KanbanContext>();
        builder.UseSqlite(connection);
        var context = new KanbanContext(builder.Options);
        context.Database.EnsureCreated();

        
        context.SaveChanges();

        //_context = context;
        //_repository = new TagRepository(_context);
    }

    [Fact]
    public void Create_given_City_returns_Created_with_City()
    {
        var (response, created) = _repository.Create(new CityCreateDto("Central City"));

        response.Should().Be(Created);

        created.Should().Be(new CityDto(3, "Central City"));
    }

        public void Dispose()
    {
        _context.Dispose();
    }
}