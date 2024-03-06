<<<<<<< HEAD:GoogleDrive.Domain/Enteties/UserModels/UserViewModel.cs
﻿using GoogleDrive.Domain.Enums;

namespace GoogleDrive.Domain.Entities.UserModels;
=======
﻿namespace GoogleDrive.Domain.DTOs.UserModels;
>>>>>>> main:GoogleDrive.Domain/DTOs/UserModels/UserViewModel.cs

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public Privacy Privacy { get; set; }
}
