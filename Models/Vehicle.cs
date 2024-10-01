using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApiService.Models;

public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Make { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    [Range(1970,9999)]
    public int Year { get; set; }

    [Required]
    [Range(double.Epsilon, double.MaxValue)]
    public double Price { get; set; }

    [Required]
    [StringLength(100)]
    public string Color { get; set; }

    public Vehicle(string make, string model, int year, double price, string color)
    {
        Make = make.ToLower().Trim();
        Model = model.ToLower().Trim();;
        Year = year;
        Price = price;
        Color = color.ToLower().Trim();;
    }
}
