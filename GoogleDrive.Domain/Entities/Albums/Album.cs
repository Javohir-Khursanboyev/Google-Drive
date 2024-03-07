using GoogleDrive.Domain.Commons;
using GoogleDrive.Domain.Entities.Users;

namespace GoogleDrive.Domain.Entities.Albums;

public class Album:Auditable
{
    public string Name { get; set; }

    public long UserId { get; set; }
    public User user { get; set; }
}
