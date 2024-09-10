using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Models.Enum;

namespace APIMANAGEMENT.Data.Dtos
{
    public class GetTransactionDto
    {
    
    public int Id { get; set; }
    public TypeTransaction Type { get; set; }
    public string Description { get; set; } 
    public decimal Value { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}