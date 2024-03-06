using GoogleDrive.Domain.DTOs.UserModels;
using GoogleDrive.Domain.Entities.UserModel;
using GoogleDrive.Domain.Entities.UserModels;
using GoogleDrive.Service.Extensions;
using GoogleDrive.Service.Helpers;
using GoogleDrive.Service.Interfaces;

namespace GoogleDrive.Service.Services;

public class UserService : IUserService
{
    private List<UserModel> users = new List<UserModel>();

    UserReader reader = new UserReader();
    UserWriter writer = new UserWriter();

    public async Task<bool> DeleteAsync(long id)
    {
        users = reader.Read();

        var existingUser = users.FirstOrDefault(x => x.Id == id && !x.IsDeleted)
            ?? throw new Exception("User is not found");

        existingUser.IsDeleted = true;
        existingUser.DeletedAt = DateTime.UtcNow;

        writer.Write(users);

        return true;
    }
    public async Task<UserModel> GetAsync(long id)
    {
        users = reader.Read();

        var existingUser = users.FirstOrDefault(x => x.Id == id && !x.IsDeleted)
            ?? throw new Exception("User is not found");

        return existingUser;
    }
    public async Task<UserViewModel> ViewAsync(long id)
    {
        users = reader.Read();

        var existingUser = users.FirstOrDefault(x => x.Id == id && !x.IsDeleted)
            ?? throw new Exception("User is not found");

        return existingUser.MapTo<UserViewModel>();
    }
    public async Task<List<UserViewModel>> GetAllAsync()
    {
        users = reader.Read();

        var usersExist = users.Where(p => !p.IsDeleted).ToList();
        return usersExist.MapTo<UserViewModel>().ToList();
    }
    public async Task<UserViewModel> CreateAsync(UserCreationModel user)
    {
        users = reader.Read();

        // IsDeleted ???
        if (users.Any(p => !p.IsDeleted && p.Email == user.Email))
        {
            throw new Exception("User with the same phone number or email already exists. ");
        }

        var createdUser = users.Create(MapperExtension.MapTo<UserModel>(user));

        writer.Write(users);

        return createdUser.MapTo<UserViewModel>();
    }
    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel userUpdate)
    {
        users = reader.Read();

        var existingUser = users.FirstOrDefault(x => x.Id == id && !x.IsDeleted)
            ?? throw new Exception("User is not found");

        existingUser.Id = id;
        existingUser.Email = userUpdate.Email;
        existingUser.LastName = userUpdate.LastName;
        existingUser.FirstName = userUpdate.FirstName;

        writer.Write(users);

        return existingUser.MapTo<UserViewModel>();
    }
    public async Task<UserModel> GetToLoginAsync(string Email, string password)
    {
        users = reader.Read();

        var existCustomer = users.FirstOrDefault(customer => customer.Email == Email && PasswordHashing.VerifyPassword(customer.Password, password) && !customer.IsDeleted)
            ?? throw new Exception($"Customer is not exists with Email ({Email}) or incorrect password");
        return existCustomer;
    }
}

