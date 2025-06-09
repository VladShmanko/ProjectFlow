using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.BLL.DTOs;
using ProjectFlow.BLL.Services;

namespace ProjectFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemTagsController : ControllerBase
    {
        private readonly ITaskItemTagService _taskItemTagService;

        public TaskItemTagsController(ITaskItemTagService taskItemTagService)
        {
            _taskItemTagService = taskItemTagService;
        }

        [HttpGet("by-task/{taskItemId}")]
        public async Task<IActionResult> GetByTaskItemId(int taskItemId)
        {
            var result = await _taskItemTagService.GetByTaskItemIdAsync(taskItemId);
            return Ok(result);
        }

        [HttpGet("by-tag/{tagId}")]
        public async Task<IActionResult> GetByTagId(int tagId)
        {
            var result = await _taskItemTagService.GetByTagIdAsync(tagId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskItemTagCreateDto dto)
        {
            var result = await _taskItemTagService.AddAsync(dto);
            return CreatedAtAction(nameof(GetByTaskItemId), new { taskItemId = result.TaskItemId }, result);
        }

        [HttpDelete("{taskItemId}/{tagId}")]
        public async Task<IActionResult> Delete(int taskItemId, int tagId)
        {
            var success = await _taskItemTagService.DeleteAsync(taskItemId, tagId);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
