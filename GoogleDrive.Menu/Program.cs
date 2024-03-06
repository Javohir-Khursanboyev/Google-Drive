using GoogleDrive.Data.AppDbContexts;
using GoogleDrive.Data.Repositories;
using GoogleDrive.Domain.Entities.Users;
using GoogleDrive.Domain.Enums;
using GoogleDrive.Service.Service;


AppDbContext context = new AppDbContext();
UserRepository userRepository = new UserRepository(context);

UserCreationModel model = new UserCreationModel()
{
    FirstName = "Javohir",
    LastName = "Xursanboyev",
    Email = "Javohir@gmail.com",
    Password = "password123",
    UserName = "Javohir_26",
    Privacy = Privacy.Public
};

UserService userService = new UserService(userRepository);
await userService.CreateAsync(model);