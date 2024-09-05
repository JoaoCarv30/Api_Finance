using Management.Models;
using Management.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers;


[Route("api/[controller]")]
[ApiController]

public class ModelTransactionController : ControllerBase
{
    private static List<ModelTransaction> _transactions = new();
    
    
 [HttpPost]
    public ActionResult<ModelTransaction> Create([FromBody] ModelTransaction transaction)
    {
        _transactions.Add(transaction);
        return transaction;
    }
    
    [HttpGet]
    public ActionResult<List<ModelTransaction>> Get()
    {
        return _transactions;
    }

    
}