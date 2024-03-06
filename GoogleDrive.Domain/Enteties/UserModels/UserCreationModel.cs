﻿namespace GoogleDrive.Domain.Entities.UserModels;

public class UserCreationModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Privacy { get; set; } = false;
}
