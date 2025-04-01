﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Models;
using Parking_Management.Parking.Persistence.DbContexts;
using Parking_Management.Parking.Application.Services.Abstractions;

namespace Parking_Management.Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedController : ControllerBase
    {
        private readonly ILedService _ledService;

        public LedController(ILedService ledService)
        {
            _ledService = ledService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LedDto>>> GetAll()
        {
            var leds = await _ledService.GetAllAsync();
            return Ok(leds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LedDto>> GetById(int id)
        {
            var led = await _ledService.GetByIdAsync(id);

            if (led == null)
                return NotFound();

            return Ok(led);
        }

        [HttpPost]
        public async Task<ActionResult<LedDto>> Create(CreateLedDto createLedDto)
        {
            var createdLed = await _ledService.CreateAsync(createLedDto);
            return CreatedAtAction(nameof(GetById), new { id = createdLed.Id }, createdLed);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LedDto>> Update(int id, UpdateLedDto updateLedDto)
        {
            var updatedLed = await _ledService.UpdateAsync(id, updateLedDto);

            if (updatedLed == null)
                return NotFound();

            return Ok(updatedLed);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _ledService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
