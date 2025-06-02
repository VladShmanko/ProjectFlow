using ProjectFlow.DAL.Entities;
using ProjectFlow.DAL.Repositories;

namespace ProjectFlow.BLL.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _unitOfWork.Tags.GetAllAsync();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Tags.GetByIdAsync(id);
        }

        public async Task<Tag?> GetByNameAsync(string name)
        {
            return await _unitOfWork.Tags.GetByNameAsync(name);
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            await _unitOfWork.Tags.AddAsync(tag);
            await _unitOfWork.SaveAsync();
            return tag;
        }

        public async Task<bool> UpdateAsync(Tag tag)
        {
            var existing = await _unitOfWork.Tags.GetByIdAsync(tag.Id);
            if (existing == null)
                return false;

            existing.Name = tag.Name;
            _unitOfWork.Tags.Update(existing);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tag = await _unitOfWork.Tags.GetByIdAsync(id);
            if (tag == null)
                return false;

            _unitOfWork.Tags.Delete(tag);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
