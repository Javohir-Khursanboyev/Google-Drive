using GoogleDrive.Domain.Commons;
using GoogleDrive.Domain.Enums;

namespace GoogleDrive.Domain.Entities.UserModel;

public class UserModel : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
<<<<<<< HEAD:GoogleDrive.Domain/Enteties/UserModels/UserModel.cs
    public Privacy Privacy { get; set; }
=======
>>>>>>> main:GoogleDrive.Domain/Enteties/UserModel/UserModel.cs
}
