<<<<<<< HEAD:GoogleDrive.Domain/Enteties/UserModels/UserUpdateModel.cs
﻿using GoogleDrive.Domain.Enums;

namespace GoogleDrive.Domain.Entities.UserModels;
=======
﻿namespace GoogleDrive.Domain.DTOs.UserModels;
>>>>>>> main:GoogleDrive.Domain/DTOs/UserModels/UserUpdateModel.cs
public class UserUpdateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Privacy Privacy { get; set; }
}
