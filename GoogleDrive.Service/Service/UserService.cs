using GoogleDrive.Data.Repositories;
using GoogleDrive.Domain.Entities.Users;
using GoogleDrive.Service.Extensions;
using GoogleDrive.Service.Interface;

namespace GoogleDrive.Service.Service;

public class UserService : IUserService
{
    private readonly UserRepository userRepository;
    public UserService(UserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public async Task<UserViewModel> CreateAsync(UserCreationModel user)
    {
        var users = await userRepository.GetAllAsync();
        var existUser = users.FirstOrDefault(u => u.ChatId == user.ChatId);
        if (existUser != null)
            return await UpdateAsync(existUser.Id, user.MapTo<UserUpdatedModel>());

        var createdUser = userRepository.InsertAsync(user.MapTo<User>());
        return createdUser.MapTo<UserViewModel>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var users = await userRepository.GetAllAsync();
        var existUser = users.FirstOrDefault(u => u.Id == id && !u.IsDeleted)
            ?? throw new Exception($"This user is not found With this id {id}");

        await userRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await userRepository.GetAllAsync();
        return users.Where(u => !u.IsDeleted).MapTo<UserViewModel>();
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var users = await userRepository.GetAllAsync();
        var existUser = users.FirstOrDefault(u => u.Id == id && !u.IsDeleted)
            ?? throw new Exception($"This user is not found With this id {id}");

        return existUser.MapTo<UserViewModel>();
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdatedModel user)
    {
        var users = await userRepository.GetAllAsync();

        var existUser = users.FirstOrDefault(u => u.Id == id)
                ?? throw new Exception($"This user is not found With this id {id}");

        var updatedUser = await userRepository.UpdateAsync(id, existUser);
        return updatedUser.MapTo<UserViewModel>();
    }
}
