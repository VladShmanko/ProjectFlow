using ProjectFlow.DAL.Entities;
using ProjectFlow.DAL.Repositories;

namespace ProjectFlow.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _unitOfWork.Users.GetByUsernameAsync(username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _unitOfWork.Users.GetByEmailAsync(email);
        }

        public async Task<User> CreateAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(user.Id);
            if (existingUser is null)
                return false;

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;

            _unitOfWork.Users.Update(existingUser);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user is null)
                return false;

            _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
