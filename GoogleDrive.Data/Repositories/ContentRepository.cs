using GoogleDrive.Data.AppDbContexts;
using GoogleDrive.Data.IRepositories;
using GoogleDrive.Domain.Entities.Contents;
using Microsoft.EntityFrameworkCore;

namespace GoogleDrive.Data.Repositories;

public class ContentRepository : IContentRepository
{
    public AppDbContext context;
    public ContentRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var existContent = await context.contents.FirstAsync(u => u.Id == id);
        existContent.IsDeleted = true;
        existContent.DeletedAt = DateTime.UtcNow;
        context.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<Content>> GetAllAsync()
    {
        var contents = await context.contents.ToListAsync();
        return contents;
    }

    public async Task<Content> InsertAsync(Content content)
    {
        var createdContent = await context.contents.AddAsync(content);
        context.SaveChanges();
        return createdContent.Entity;
    }

    public async Task<Content> UpdateAsync(long id, Content content)
    {
        var existContent = await context.contents.FirstAsync(u => u.Id == id);
        existContent.Description = content.Description;
        existContent.UserId = content.UserId;
        existContent.ImageDates = content.ImageDates;
        existContent.UpdatedAt = DateTime.UtcNow;
        existContent.IsDeleted = false;
        context.SaveChanges();

        return existContent;
    }
}
