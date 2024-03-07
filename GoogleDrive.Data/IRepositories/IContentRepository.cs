using GoogleDrive.Domain.Entities.Contents;

namespace GoogleDrive.Data.IRepositories;

public interface IContentRepository
{
    Task<Content> InsertAsync(Content content);
    Task<Content> UpdateAsync(long id,Content content);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<Content>> GetAllAsync();
}
