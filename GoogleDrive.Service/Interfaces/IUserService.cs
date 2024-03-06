using GoogleDrive.Domain.DTOs.UserModels;
using GoogleDrive.Domain.Entities.UserModel;
using GoogleDrive.Domain.Entities.UserModels;

namespace GoogleDrive.Service.Interfaces;

public interface IUserService
{
    public Task<UserViewModel> CreateAsync(UserCreationModel user);
    public Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user);
    public Task<bool> DeleteAsync(long id);
    public Task<UserModel> GetAsync(long id);
    public Task<List<UserViewModel>> GetAllAsync();
    public Task<UserViewModel> ViewAsync(long id);
    public Task<UserModel> GetToLoginAsync(string Email, string password);
}
