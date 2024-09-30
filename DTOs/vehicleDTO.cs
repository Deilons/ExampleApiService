using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApiService.DTOs;

public class vehicleDTO
{   
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Make is required")]
    [StringLength(50, ErrorMessage = "Make must be less than 50 characters")]
    public string Make { get; set; }

    [Required(ErrorMessage = "Model is required")]
    public string Model { get; set; }

    [Range(1970,9999)]
    [Required(ErrorMessage = "Year is required")]
    public int Year { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    [Required(ErrorMessage = "Price is required")]
    public double Price { get; set; }


    [Required(ErrorMessage = "Color is required")]
    [StringLength(50, ErrorMessage = "Color must be less than 50 characters")]
    public string Color { get; set; }
}
