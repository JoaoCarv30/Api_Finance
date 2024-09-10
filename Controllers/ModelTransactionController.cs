using System.Transactions;
using APIMANAGEMENT.Data;
using Management.Models;
using Management.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{


    [Route("[controller]")]
    [ApiController]

    public class ModelTransactionController : ControllerBase
    {

        private TransactionContext _context;

        public ModelTransactionController(TransactionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] ModelTransaction transaction)
        {
            _context.Add(transaction);
            _context.SaveChanges();
            return Ok(transaction);
        }

        [HttpGet]   

        public IActionResult GetTransactions()
        {
            var transactions = _context.Transactions.ToList();
            return Ok(transactions);
        }


        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            return Ok(transaction);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id, [FromBody] ModelTransaction transaction)
        {
            var transactionToUpdate = _context.Transactions.FirstOrDefault(t => t.Id == id);
            transactionToUpdate.Type = transaction.Type;
            transactionToUpdate.Description = transaction.Description;
            transactionToUpdate.Value = transaction.Value;
            transactionToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return Ok(transactionToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            _context.Remove(transaction);
            _context.SaveChanges();
            return Ok(transaction);
        }



    }
}
