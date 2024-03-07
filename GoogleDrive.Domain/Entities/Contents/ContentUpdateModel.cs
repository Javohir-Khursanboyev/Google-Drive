using GoogleDrive.Domain.Entities.Albums;
using GoogleDrive.Domain.Entities.Users;

namespace GoogleDrive.Domain.Entities.Contents;

public class ContentUpdateModel
{
    public string Description { get; set; }
    public byte[] ImageDates { get; set; }

    public long UserId { get; set; }
    public long AlbumId { get; set; }
}
