using ExampleApiService.Data;
using ExampleApiService.Models;
using ExampleApiServices.Repositories;
using Microsoft.EntityFrameworkCore;
namespace ExampleApiServices.Services;
public class VehicleServices : IVehicleRepository
{
    private readonly ApplicationDbContext _context;
    public VehicleServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Add(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            throw new ArgumentNullException(nameof(vehicle), "The vehicle cannot be null.");
        }
        try
        {
            await _context.Vehicles.AddAsync(vehicle); 
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error adding the vehicle.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("unexpected error occurred.", ex);
        }
    }
    public Task<bool> CheckExistence(int id)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<Vehicle>> GetAll()
    {
        throw new NotImplementedException();
    }
    public Task<Vehicle?> GetById(int id)
    {
        throw new NotImplementedException();
    }
    public Task Update(Vehicle student)
    {
        throw new NotImplementedException();
    }
}