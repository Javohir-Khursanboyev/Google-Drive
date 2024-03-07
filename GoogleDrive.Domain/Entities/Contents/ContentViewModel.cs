namespace GoogleDrive.Domain.Entities.Contents;

public class ContentViewModel
{
    public long Id { get; set; }
    public string Description { get; set; }
    public byte[] ImageDates { get; set; }

    public long UserId { get; set; }
    public long AlbumId { get; set; }
}
