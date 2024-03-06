using GoogleDrive.Data.IRepositories;
using GoogleDrive.Models.UserModels;
using GoogleDrive.UI.AppDbContexts;
using Microsoft.EntityFrameworkCore;

namespace GoogleDrive.Data.Repositories;

public class UserRepository : IUserRepository
{
    public readonly AppDbContext appDb;
    private readonly DbSet<UserModel>users;
    public UserRepository(AppDbContext appDb)
    {
        this.appDb = appDb;
    }
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
