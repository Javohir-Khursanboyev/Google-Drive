using GoogleDrive.Data.AppDbContexts;
using GoogleDrive.Data.IRepositories;
using GoogleDrive.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

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
        existUser.IsDeleted = true;
        existUser.DeletedAt = DateTime.UtcNow;
        context.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await context.users.ToListAsync();
        return users;
    }

    public async Task<User> InsertAsync(User user)
    {
        var createdUser = await context.users.AddAsync(user); 
        context.SaveChanges();
        return createdUser.Entity;
    }

    public async Task<User> UpdateAsync(long id, User user)
    {
        var existUser = await context.users.FirstAsync(u => u.Id == id);
        existUser.FirstName = user.FirstName;
        existUser.LastName = user.LastName;
        existUser.UpdatedAt = DateTime.UtcNow;
        existUser.IsDeleted = false;
        context.SaveChanges();

        return existUser;
    }
}
