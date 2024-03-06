using GoogleDrive.Domain.Entities.Albums;
using GoogleDrive.Domain.Entities.Users;

namespace GoogleDrive.Data.IRepositories;

public interface IAlbumRepository
{
    Task<Album> InsertAsync(Album album);
    Task<Album> UpdateAsync(long id, Album album);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<Album>> GetAllAsync();
}
