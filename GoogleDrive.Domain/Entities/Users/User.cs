using GoogleDrive.Domain.Commons;

namespace GoogleDrive.Domain.Entities.Users;

public class User:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ChatId { get; set; }
}
