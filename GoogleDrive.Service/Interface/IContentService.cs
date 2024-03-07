using GoogleDrive.Domain.Entities.Contents;

namespace GoogleDrive.Service.Interface;

public interface IContentService
{
    Task<ContentViewModel> CreateAsync(ContentCreationModel content);
    Task<ContentViewModel> UpdateAsync(long id, ContentUpdateModel content);
    Task<bool> DeleteAsync(long id);
    Task<ContentViewModel> GetByIdAsync(long id);
    Task<IEnumerable<ContentViewModel>> GetAllAsync(long ? userId);
}
