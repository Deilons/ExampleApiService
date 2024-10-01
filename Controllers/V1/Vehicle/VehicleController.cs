using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiService.Data;
using ExampleApiService.DTOs;
using ExampleApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _context.Vehicles.ToListAsync();

            if (vehicles.Any() == false)
            {
                return NoContent();
            }
            return Ok(vehicles);
        }

        // GET method by ID
        [HttpGet("{id}/exists")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
    }
}