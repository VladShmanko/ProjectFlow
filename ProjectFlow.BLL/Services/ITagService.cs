using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(int id);
        Task<Tag?> GetByNameAsync(string name);
        Task<Tag> CreateAsync(Tag tag);
        Task<bool> UpdateAsync(Tag tag);
        Task<bool> DeleteAsync(int id);
    }
}
