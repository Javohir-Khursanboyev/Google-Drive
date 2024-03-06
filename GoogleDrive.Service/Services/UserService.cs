using GoogleDrive.Domain.DTOs.UserModels;
using GoogleDrive.Domain.Entities.UserModel;
using GoogleDrive.Service.Interfaces;

namespace GoogleDrive.Service.Services;

public class UserService : IUserService
{

    public ValueTask<UserViewModel> CreateAsync(UserCreationModel user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserViewModel> ViewAsync(long id)
    {
        throw new NotImplementedException();
    }
}
