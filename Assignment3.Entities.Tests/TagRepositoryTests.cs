using Microsoft.Data.Sqlite;
using Npgsql;
namespace Assignment3.Entities.Tests;

using Assignment3.Entities;
using Assignment3.Core;

public sealed class TagRepositoryTests : IDisposable
{
    private readonly KanbanContext _context;
    private readonly TagRepository _repository;

    
    public TagRepositoryTests()
    {
        var connection = new NpgsqlConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<KanbanContext>();
        builder.UseSqlite(connection);
        var context = new KanbanContext(builder.Options);
        context.Database.EnsureCreated();
        context.Tags.AddRange(new Tag() { Id = 1 , Name = "Danger"}, new Tag() { Id = 2, Name = "Boring" });
        context.Tasks.AddRange(new Task() { Id = 1 , Title = "Homework"}, new Task() { Id = 2, Title = "Cleaning" });
        context.SaveChanges();
        var optionsBuilder = new DbContextOptionsBuilder<KanbanContext>();
        _context = new KanbanContext(optionsBuilder.Options);
        _repository = new TagRepository(_context);
        _context.Database.BeginTransaction();
    }



    public void Dispose()
    {
        _context.Dispose();
    }
}