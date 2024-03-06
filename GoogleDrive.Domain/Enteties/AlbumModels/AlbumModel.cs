using GoogleDrive.Domain.Commons;

namespace GoogleDrive.Domain.Entities.AlbumModels;

public class AlbumModel : Auditable
{
    public string Name { get; set; }
    public long UserId { get; set; }
}
