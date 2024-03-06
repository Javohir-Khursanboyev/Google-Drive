using GoogleDrive.Domain.Entities.Users;

namespace GoogleDrive.Service.Interface;

public interface IUserService
{
    Task<UserViewModel> CreateAsync(UserCreationModel user);
    Task<UserViewModel> UpdateAsync(long id,UserUpdatedModel user, bool IsUsesDeleted);
    Task<bool> DeleteAsync(long id);
    Task<UserViewModel> GetByIdAsync(long id);
    Task<IEnumerable<UserViewModel>> GetAllAsync(); 
}
