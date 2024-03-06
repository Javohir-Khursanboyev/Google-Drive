namespace GoogleDrive.Domain.Entities.ContentModels;

public class ContentCreationModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public long AlbumId { get; set; }
}
