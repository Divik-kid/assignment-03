using Microsoft.Data.Sqlite;

namespace Assignment3.Entities.Tests;

using Assignment3;
using Assignment3.Core;

public sealed class TagRepositoryTests : IDisposable
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
        var optionsBuilder = new DbContextOptionsBuilder<KanbanContext>();
        _context = new KanbanContext(optionsBuilder.Options);
        _repository = new TagRepository(_context);
        _context.Database.BeginTransaction();
    }

/*
    [Fact]
    public void Trying_to_delete_a_tag_in_use_without_the_force_should_return_Conflict()
    {
        // Given
        var tag = new TagCreateDTO("My tag");
        var res = _repository.Create(tag);

        _context.Tags.Find(res.TagId)!.Tasks.Add(new Task());
        _context.SaveChanges();
        
        // When
        var response = _repository.Delete(res.TagId);
    
        // Then
        response.Should().Be(Response.Conflict);
    }
*/
    [Fact]
    public void Tags_which_are_assigned_to_a_task_may_only_be_deleted_using_the_force()
    {
        // Given
        var response = _repository.Delete(1, true);
    
        // When
    
        // Then
        response.Should().Be(Response.Deleted);

        // When
        var deletedElement = _repository.Read(1);
        deletedElement.Should().Be(null);
    }

    [Fact]
    public void Trying_to_create_a_tag_which_exists_already_should_return_Conflict()
    {
        // Given
        var duplicateTag = new TagCreateDTO("Homework");
    
        // When
        var duplicateResponse = _repository.Create(duplicateTag);
    
        // Then
        duplicateResponse.Response.Should().Be(Response.Conflict);
    }

    [Fact]
    public void Creating_A_Nonexisting_Tag_Should_Return_Created()
    {
        // Given
        var newTag = new TagCreateDTO("This tag has definitely not been created before!");

        // When
        var response = _repository.Create(newTag);
    
        // Then
        response.Response.Should().Be(Response.Created);
    }

    [Fact]
    public void Trying_to_update_a_non_existing_entity_should_return_NotFound()
    {
        // Given
        var newTag = new TagUpdateDTO(1212, "This tag does not exist!");

        // When
        var response = _repository.Update(newTag);
    
        // Then
        response.Should().Be(Response.NotFound);
    }

    [Fact]
    public void Update_an_existing_tag_should_return_Updated()
    {
        // Given
        var newTag = new TagUpdateDTO(1, "This is my new name");

        // When
        var response = _repository.Update(newTag);
    
        // Then
        response.Should().Be(Response.Updated);

        // When
        var updatedTag = _repository.Read(1);

        // Then
        updatedTag.Name.Should().Be("This is my new name");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}