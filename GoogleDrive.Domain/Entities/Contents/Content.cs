using GoogleDrive.Domain.Commons;
using GoogleDrive.Domain.Entities.Albums;
using GoogleDrive.Domain.Entities.Users;

namespace GoogleDrive.Domain.Entities.Contents;

public class Content:Auditable
{
    public string Description { get; set; }
    public DateTime SetDate { get; set; } = DateTime.UtcNow;
    public byte[] ImageDates { get; set; }
     
    public long UserId { get; set; }
    public User User { get; set; }
}