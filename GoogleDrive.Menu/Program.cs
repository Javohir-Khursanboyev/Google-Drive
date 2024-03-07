

using GoogleDrive.Data.AppDbContexts;
using GoogleDrive.Data.Repositories;
using GoogleDrive.Domain.Entities.Contents;
using GoogleDrive.Service.Service;

//AppDbContext appDbContext = new AppDbContext();
//ContentRepository contentRepository = new ContentRepository(appDbContext);
//AlbumRepository  albumRepository = new AlbumRepository(appDbContext);
//UserRepository userRepository = new UserRepository(appDbContext);
//byte[] imageData;

//using (var stream = new FileStream(@"C:\Users\user\Pictures\Screenshots\Screenshot 2024-03-05 130640.png", FileMode.Open))
//using (var memoryStream = new MemoryStream())
//{
//    stream.CopyTo(memoryStream);
//    imageData = memoryStream.ToArray();
//}

//ContentCreationModel contentCreationModel = new ContentCreationModel()
//{
//    Description = "description",
//    UserId = 1,
//    AlbumId = 1,
//    ImageDates = imageData
////};
//UserService userService = new UserService(userRepository);
//AlbumService albumService = new AlbumService(albumRepository,userService);
//ContentService contentService = new ContentService(contentRepository,albumService);
//var model = await contentService.GetByIdAsync(1);

//MemoryStream stream = new MemoryStream();
//stream.Write(model.ImageDates);
//FileStream fileStream = new FileStream("C:\\Users\\user\\Desktop\\Javohir_bot\\javohirsa.png", FileMode.OpenOrCreate, FileAccess.Write);
//fileStream.Write(model.ImageDates, 0, model.ImageDates.Length);
internal class Program { 
    static async Task Main(string[] args) 
    {
        
    }
}
