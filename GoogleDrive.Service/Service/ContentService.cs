using GoogleDrive.Data.Repositories;
using GoogleDrive.Domain.Entities.Contents;
using GoogleDrive.Service.Extensions;
using GoogleDrive.Service.Interface;

namespace GoogleDrive.Service.Service;

public class ContentService : IContentService
{
    private readonly ContentRepository contentRepository;
    private readonly AlbumService albumService;
    public ContentService(ContentRepository contentRepository, AlbumService albumService)
    {
        this.contentRepository = contentRepository;
        this.albumService = albumService;
    }
    public async Task<ContentViewModel> CreateAsync(ContentCreationModel content)
    {

        var javohir = content.MapTo<Content>();
        var createdContent = await contentRepository.InsertAsync(content.MapTo<Content>());
        return createdContent.MapTo<ContentViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var contents = await contentRepository.GetAllAsync();
        var existContent = contents.FirstOrDefault(c => c.Id == id && !c.IsDeleted)
            ?? throw new Exception($"This content is not found With this id {id}");

        await contentRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<ContentViewModel>> GetAllAsync()
    {
        var contents = await contentRepository.GetAllAsync();
        return contents.Where(c => !c.IsDeleted).MapTo<ContentViewModel>();
    }

    public async Task<ContentViewModel> GetByIdAsync(long id)
    {
        var contents = await contentRepository.GetAllAsync();
        var existContent = contents.FirstOrDefault(c => c.Id == id && !c.IsDeleted)
            ?? throw new Exception($"This content is not found With this id {id}");

        return existContent.MapTo<ContentViewModel>();
    }

    public async Task<ContentViewModel> UpdateAsync(long id, ContentUpdateModel content)
    {
        var contents = await contentRepository.GetAllAsync();
        var existContent = contents.FirstOrDefault(c => c.Id == id && !c.IsDeleted)
            ?? throw new Exception($"This content is not found With this id {id}");

        var updatedContent = await contentRepository.UpdateAsync(id, content.MapTo<Content>());
        return updatedContent.MapTo<ContentViewModel>();
    }
}