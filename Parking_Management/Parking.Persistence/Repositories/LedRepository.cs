﻿using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Parking_Management.Parking.Persistence.Repositories
{
    public class LedRepository : ILedRepository
    {
        public readonly ParkingManagementContext _context;

        public LedRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Led>> GetAllAsync()
        {
            return await _context.Leds.ToListAsync();
        }

        public async Task<Led> GetByIdAsync(int id)
        {
            return await _context.Leds.FindAsync(id);
        }

        public async Task CreateAsync(Led led)
        {
            await _context.Leds.AddAsync(led);
        }

        public void Update(Led led)
        {
            _context.Leds.Update(led);
        }

        public void Delete(Led led)
        {
            _context.Leds.Remove(led);
        }
    }
}
