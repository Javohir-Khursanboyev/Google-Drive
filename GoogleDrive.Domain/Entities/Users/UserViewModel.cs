using GoogleDrive.Domain.Enums;

namespace GoogleDrive.Domain.Entities.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public Privacy Privacy { get; set; }
}
