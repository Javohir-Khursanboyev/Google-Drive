//using GoogleDrive.Data.Repositories;
//using GoogleDrive.Domain.Entities.Albums;
//using GoogleDrive.Service.Extensions;
//using GoogleDrive.Service.Interface;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace GoogleDrive.Service.Service;

//public class AlbumService : IAlbumService
//{
//    private readonly AlbumRepository albumRepository;
//    private readonly UserService userService;
//    public AlbumService(AlbumRepository albumRepository, UserService userService)
//    {
//        this.albumRepository = albumRepository;
//        this.userService = userService;
//    }
//    public async Task<AlbumViewModel> CreateAsync(AlbumCreationModel album)
//    {
//        var existUser = await userService.GetByIdAsync(album.UserId);

//        var albums = await albumRepository.GetAllAsync();
//        var existAlbum = albums.FirstOrDefault(a => a.Name.ToLower() == album.Name.ToLower());
//        if(existAlbum is not null)
//        {
//            if(existAlbum.IsDeleted) 
//                return await UpdateAsync(existAlbum.Id, album.MapTo<AlbumUpdatedModel>(), true);
//            throw new Exception($"This album is already exist With this name {album.Name}");
//        }

//        var createdAlbum = await albumRepository.InsertAsync(album.MapTo<Album>());
//        return createdAlbum.MapTo<AlbumViewModel>();    
//    }

//    public async Task<bool> DeleteAsync(long id)
//    {
//        var albums = await albumRepository.GetAllAsync();
//        var existAlbum = albums.FirstOrDefault(a => a.Id == id && !a.IsDeleted)
//            ?? throw new Exception($"This album is not found With this id {id}");

//        await albumRepository.DeleteAsync(id);
//        return true;
//    }

//    public async Task<IEnumerable<AlbumViewModel>> GetAllAsync()
//    {
//        var albums = await albumRepository.GetAllAsync();
//        return albums.Where(a => !a.IsDeleted).MapTo<AlbumViewModel> ();
//    }

//    public async Task<AlbumViewModel> GetByIdAsync(long id)
//    {
//        var albums = await albumRepository.GetAllAsync();
//        var existAlbum = albums.FirstOrDefault(a => a.Id == id && !a.IsDeleted)
//            ?? throw new Exception($"This album is not found With this id {id}");

//        return existAlbum.MapTo<AlbumViewModel>();
//    }

//    public async Task<AlbumViewModel> UpdateAsync(long id,AlbumUpdatedModel album , bool isUsesDeleted = false)
//    {
//        var existUser = await userService.GetByIdAsync(album.UserId);

//        var albums = await albumRepository.GetAllAsync();
//        var existAlbum = new Album();
//        if (isUsesDeleted)
//            existAlbum = albums.First(a => a.Id == id);
//        else
//            existAlbum = albums.FirstOrDefault(a => a.Id == id && !a.IsDeleted)
//                ?? throw new Exception($"This album is not found With this id {id}");

//        var updatedAlbum = await albumRepository.UpdateAsync(id,album.MapTo<Album>());
//        return updatedAlbum.MapTo<AlbumViewModel>();
//    }
//}
