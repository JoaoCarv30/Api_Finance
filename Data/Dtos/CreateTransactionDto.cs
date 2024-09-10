using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Management.Models.Enum;

namespace APIMANAGEMENT.Data.Dtos
{
    public class CreateTransactionDto
    {
    public TypeTransaction Type { get; set; }
    [Required]
    public string Description { get; set; } 
    [Required]
    public decimal Value { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}