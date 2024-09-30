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

        // PUT method
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest("The vehicle ID in the URL does not match the vehicle ID in the request body.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingVehicle = await _context.Vehicles.FindAsync(id);
            if (existingVehicle == null)
            {
                return NotFound();
            }

            existingVehicle.Make = vehicle.Make;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Year = vehicle.Year;
            existingVehicle.Price = vehicle.Price;
            existingVehicle.Color = vehicle.Color;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE method
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST method
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleDTO inputVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newVehicle = new Vehicle
            {
                Make = inputVehicle.Make,
                Model = inputVehicle.Model,
                Year = inputVehicle.Year,
                Price = inputVehicle.Price,
                Color = inputVehicle.Color
            };

            _context.Vehicles.Add(newVehicle);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newVehicle.Id }, newVehicle);
        }
    }
}