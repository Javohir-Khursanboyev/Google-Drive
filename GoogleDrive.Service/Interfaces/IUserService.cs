using GoogleDrive.Domain.DTOs.UserModels;
using GoogleDrive.Domain.Entities.UserModel;
using GoogleDrive.Domain.Entities.UserModels;

namespace GoogleDrive.Service.Interfaces;

public interface IUserService
{
    public ValueTask<UserViewModel> CreateAsync(UserCreationModel user);
    public ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel user);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<UserModel> GetAsync(long id);
    public ValueTask<List<UserViewModel>> GetAllAsync();
    public ValueTask<UserViewModel> ViewAsync(long id);
    public ValueTask<UserModel> GetToLoginAsync(string Email, string password);
}
