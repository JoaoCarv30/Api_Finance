using System.ComponentModel.DataAnnotations;
using Management.Models.Enum;

namespace Management.Models;

public class ModelTransaction
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public TypeTransaction Type { get; set; }
    [Required]
    public string Description { get; set; } 
    [Required]
    public decimal Value { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}