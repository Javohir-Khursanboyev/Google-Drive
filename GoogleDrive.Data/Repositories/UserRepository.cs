using GoogleDrive.Data.IRepositories;
using GoogleDrive.Domain.Entities.UserModel;

namespace GoogleDrive.Data.Repositories;

public class UserRepository : IUserRepository
{

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetAllAsync()
    {

        throw new NotImplementedException();
    }

    public async Task<UserModel> InsertAsync(UserModel user)
    {

        throw new NotImplementedException();
    }

    public Task<UserModel> UpdateAsync(long id, UserModel user)
    {
        throw new NotImplementedException();
    }
}
