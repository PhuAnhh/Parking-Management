﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Models;
using Parking_Management.Parking.Persistence.DbContexts;
using Parking_Management.Parking.Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace Parking_Management.Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly IGateService _gateService;

        public GateController(IGateService gateService)
        {
            _gateService = gateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GateDto>>> GetAll()
        {
            var gates = await _gateService.GetAllAsync();
            return Ok(gates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GateDto>> GetById(int id)
        {
            var gate = await _gateService.GetByIdAsync(id);

            if (gate == null)
                return NotFound();

            return Ok(gate);
        }

        [HttpPost]
        public async Task<ActionResult<GateDto>> Create(CreateGateDto createGateDto)
        {
            var createdGate = await _gateService.CreateAsync(createGateDto);
            return CreatedAtAction(nameof(GetById), new { id = createdGate.Id }, createdGate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GateDto>> Update(int id, UpdateGateDto updateGateDto)
        {
            var updatedGate = await _gateService.UpdateAsync(id, updateGateDto);

            if (updatedGate == null)
                return NotFound();

            return Ok(updatedGate);
        }


        [HttpDelete("{id}")]
            //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _gateService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
    