using System.Transactions;
using APIMANAGEMENT.Data;
using APIMANAGEMENT.Data.Dtos;
using AutoMapper;
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
        private IMapper _mapper;

        public ModelTransactionController(TransactionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] CreateTransactionDto transactionDto)
        {
            var transaction = _mapper.Map<ModelTransaction>(transactionDto);
            _context.Add(transaction);
            _context.SaveChanges();
            return Ok(transaction);
        }

        [HttpGet]   

        public IActionResult GetTransactions()
        {
            var transactions = _context.Transactions.ToList();
            var transactionsDto = _mapper.Map<IEnumerable<GetTransactionDto>>(transactions);
            return Ok(transactionsDto);
        }


        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            var transactionDto = _mapper.Map<GetTransactionDto>(transaction);
            return Ok(transactionDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id, [FromBody] UpdateTransactionDto transactionDto)
        {
            var transaction = _mapper.Map<ModelTransaction>(transactionDto);
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
