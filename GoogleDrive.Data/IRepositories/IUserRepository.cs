using GoogleDrive.Models.UserModels;

namespace GoogleDrive.Data.IRepositories;

public interface IUserRepository
{
    Task<UserModel> InsertAsync(UserModel user);
    Task<UserModel> UpdateAsync(long id, UserModel user);   
    Task<bool> DeleteAsync(long id);
    Task<UserModel> GetAllAsync();
}
