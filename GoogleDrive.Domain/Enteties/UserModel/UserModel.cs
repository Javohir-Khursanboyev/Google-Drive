﻿using GoogleDrive.Domain.Commons;

namespace GoogleDrive.Domain.Entities.UserModel;

public class UserModel : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}