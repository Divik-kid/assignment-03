namespace Assignment3.Entities;
using Microsoft.EntityFrameworkCore;
using Assignment3.Core;

public sealed class TagRepository
{
    private readonly KanbanContext _context;

    public TagRepository(KanbanContext context) {
        _context = context;
    }



}
