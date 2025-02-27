using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Domain.Interface;
using Parking_Management.Domain.Entities;
using Parking_Management.Business.Repositories;
using Parking_Management.Business.Services;
using System.Linq;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService _cameraService;

        public CameraController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camera>>> GetAll()
        {
            return Ok(await _cameraService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Camera>> GetById(int id)
        {
            var camera = await _cameraService.GetById(id);
            if (camera == null)
            {
                return NotFound("Camera not found");
            }
            return camera;
        }

        [HttpPost]
        public async Task<ActionResult<Camera>> Create([FromBody] CameraOnly cameraOnly)
        {
            var camera = await _cameraService.Add(cameraOnly);
            return CreatedAtAction(nameof(GetById), new { id = camera.Id }, camera);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CameraOnly cameraOnly)
        {
            await _cameraService.Update(id, cameraOnly);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var camera = await _cameraService.GetById(id);
            if (camera == null)
            {
                return NotFound("Camera not found");
            }
            await _cameraService.Delete(id);
            return NoContent();
        }
    }
}
