using GoogleDrive.Data.AppDbContexts;
using GoogleDrive.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using GoogleDrive.Domain.Entities.UserModel;

namespace GoogleDrive.Data.Repositories;

public class UserRepository : IUserRepository
{
    public AppDbContext context;
    public UserRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await context.users.FirstAsync(u => u.Id == id && !u.IsDeleted);  
        if(existUser != null)
            existUser.IsDeleted = true;
        context.SaveChanges();
        return true;
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        var users = await context.users.ToListAsync();
        return users;
    }

    public async Task<UserModel> InsertAsync(UserModel user)
    {
        var createdUser = await context.users.AddAsync(user); 
        context.SaveChanges();
        return createdUser.Entity;
    }

    public async Task<UserModel> UpdateAsync(long id, UserModel user)
    {
        var existUser = await context.users.FirstAsync(u => u.Id == id);
        existUser.FirstName = user.FirstName;
        existUser.LastName = user.LastName;
        existUser.Email = user.Email;
        existUser.UserName = user.UserName;
        existUser.Password = user.Password;
        existUser.Privacy = user.Privacy;
        existUser.UpdatedAt = DateTime.UtcNow;
        existUser.IsDeleted = false;
        context.SaveChanges();

        return existUser;
    }
}
