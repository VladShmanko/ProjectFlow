using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.BLL.DTOs;
using ProjectFlow.BLL.Services;
using ProjectFlow.DAL.Entities;

namespace ProjectFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMembersController : ControllerBase
    {
        private readonly IProjectMemberService _projectMemberService;

        public ProjectMembersController(IProjectMemberService projectMemberService)
        {
            _projectMemberService = projectMemberService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var members = await _projectMemberService.GetByUserIdAsync(userId);
            return Ok(members);
        }

        [HttpGet("is-member")]
        public async Task<IActionResult> IsUserMemberOfProject([FromQuery] int userId, [FromQuery] int projectId)
        {
            var isMember = await _projectMemberService.IsUserMemberOfProjectAsync(userId, projectId);
            return Ok(isMember);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] ProjectMemberDto memberDto)
        {
            if (memberDto == null)
                return BadRequest("Member data is required");

            var createdMember = await _projectMemberService.AddAsync(memberDto);
            return CreatedAtAction(nameof(GetByUserId), new { userId = createdMember.UserId }, createdMember);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMember([FromQuery] int userId, [FromQuery] int projectId)
        {
            var result = await _projectMemberService.RemoveAsync(userId, projectId);
            if (!result)
                return NotFound("Project member not found");

            return NoContent();
        }
    }
}
