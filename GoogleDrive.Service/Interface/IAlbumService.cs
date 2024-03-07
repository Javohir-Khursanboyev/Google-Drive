using GoogleDrive.Domain.Entities.Albums;

namespace GoogleDrive.Service.Interface;

public interface IAlbumService
{
    Task<AlbumViewModel> CreateAsync (AlbumCreationModel album);
    Task<AlbumViewModel> UpdateAsync (long id, AlbumUpdatedModel album, bool isUsesDeleted);
    Task<bool> DeleteAsync (long id);
    Task<AlbumViewModel> GetByIdAsync (long id);
    Task<IEnumerable<AlbumViewModel>> GetAllAsync ();
}
