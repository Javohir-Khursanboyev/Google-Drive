using GoogleDrive.Data.AppDbContexts;
using GoogleDrive.Data.IRepositories;
using GoogleDrive.Domain.Entities.Albums;
using Microsoft.EntityFrameworkCore;

namespace GoogleDrive.Data.Repositories;

public class AlbumRepository : IAlbumRepository
{
    public AppDbContext context;
    public AlbumRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var existAlbum = await context.albums.FirstAsync(u => u.Id == id);
        existAlbum.IsDeleted = true;
        existAlbum.DeletedAt = DateTime.UtcNow;
        context.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<Album>> GetAllAsync()
    {
        var albums = await context.albums.ToListAsync();
        return albums;
    }

    public async Task<Album> InsertAsync(Album album)
    {
        var createdAlbum = await context.albums.AddAsync(album);
        context.SaveChanges();
        return createdAlbum.Entity;
    }

    public async Task<Album> UpdateAsync(long id, Album album)
    {
        var existAlbum = await context.albums.FirstAsync(u => u.Id == id);
        existAlbum.Name = album.Name;
        existAlbum.UpdatedAt = DateTime.UtcNow;
        existAlbum.IsDeleted = false;
        context.SaveChanges();

        return existAlbum;
    }
}
