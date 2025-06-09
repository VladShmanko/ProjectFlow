using ProjectFlow.BLL.DTOs;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.BLL.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagDto>> GetAllAsync();
        Task<TagDto?> GetByIdAsync(int id);
        Task<TagDto?> GetByNameAsync(string name);
        Task<TagDto> CreateAsync(CreateTagDto tagDto);
        Task<bool> UpdateAsync(UpdateTagDto tagDto);
        Task<bool> DeleteAsync(int id);
    }
}
