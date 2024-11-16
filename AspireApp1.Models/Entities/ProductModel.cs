using System.ComponentModel.DataAnnotations;

namespace AspireApp1.Models.Entities;

public class ProductModel {
    [Required]
    public int Id { get; set; }
    [Required]
    
    public string ProductName { get; set; }=string.Empty;
    [Required]
    public int Quantity { get; set; }
    [Required]
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime CreateTime { get; set; }=DateTime.Now;
}