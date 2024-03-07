using GoogleDrive.Domain.Commons;
using GoogleDrive.Domain.Enums;

namespace GoogleDrive.Domain.Entities.Users;

public class User:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public Privacy Privacy { get; set; }
}
