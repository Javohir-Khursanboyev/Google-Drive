using GoogleDrive.Domain.Commons;

namespace GoogleDrive.Domain.Entities.ContentModel;

public class ContentModel : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public long AlbumId { get; set; }
}
