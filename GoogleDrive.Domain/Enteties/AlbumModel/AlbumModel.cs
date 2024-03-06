using GoogleDrive.Domain.Commons;

namespace GoogleDrive.Domain.Entities.AlbumModel;

public class AlbumModel : Auditable
{
    public string Name { get; set; }
    public long UserId { get; set; }
}
