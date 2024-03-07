using GoogleDrive.Domain.Entities.Users;

namespace GoogleDrive.Data.IRepositories;

public interface IUserRepository
{
    Task<User> InsertAsync(User user);
    Task<User> UpdateAsync(long id, User user);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<User>> GetAllAsync();
}
