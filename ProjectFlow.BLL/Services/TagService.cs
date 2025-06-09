using ProjectFlow.BLL.DTOs;
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

        public async Task<IEnumerable<TagDto>> GetAllAsync()
        {
            var tags = await _unitOfWork.Tags.GetAllAsync();
            return tags.Select(t => new TagDto
            {
                Id = t.Id,
                Name = t.Name
            });
        }

        public async Task<TagDto?> GetByIdAsync(int id)
        {
            var tag = await _unitOfWork.Tags.GetByIdAsync(id);
            return tag == null ? null : new TagDto { Id = tag.Id, Name = tag.Name };
        }

        public async Task<TagDto?> GetByNameAsync(string name)
        {
            var tag = await _unitOfWork.Tags.GetByNameAsync(name);
            return tag == null ? null : new TagDto { Id = tag.Id, Name = tag.Name };
        }

        public async Task<TagDto> CreateAsync(CreateTagDto tagDto)
        {
            var tag = new Tag { Name = tagDto.Name };
            await _unitOfWork.Tags.AddAsync(tag);
            await _unitOfWork.SaveAsync();

            return new TagDto { Id = tag.Id, Name = tag.Name };
        }

        public async Task<bool> UpdateAsync(UpdateTagDto tagDto)
        {
            var existing = await _unitOfWork.Tags.GetByIdAsync(tagDto.Id);
            if (existing == null) return false;

            existing.Name = tagDto.Name;
            _unitOfWork.Tags.Update(existing);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tag = await _unitOfWork.Tags.GetByIdAsync(id);
            if (tag == null) return false;

            _unitOfWork.Tags.Delete(tag);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
