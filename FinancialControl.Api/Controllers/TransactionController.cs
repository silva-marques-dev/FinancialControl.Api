
using FinancialControl.Models.DTOs;
using FinancialControl.Models.Entities;
using FinancialControl.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace FinancialControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        //Endipoint para buscar a lista
        [HttpGet]
        public IActionResult GetTransaction()
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetTransactions();
                return Ok(transactions);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

        }

        //Endipoint para buscar um item na lista por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var transaction = _transactionService.GetById(id);
                return Ok(transaction);
            }
            catch (InvalidOperationException ex)
            {
                {
                    return NotFound(ex.Message);
                }

            }
        }
        //Endipoint para buscar itens do mesmo tipo
        [HttpGet("/type/{type}")]
        public IActionResult GetTransactionById(string type) 
        {
            try
            {
                var result = _transactionService.GetTransactionsByType(type);
                return Ok(result);
            }
            catch (InvalidOperationException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/balance")]
        public IActionResult GetBalance()
        {
            try
            {
                var balance = _transactionService.GetBalance();
                return Ok(balance);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Endipoint para adicionar itens na lista
        [HttpPost]
        public IActionResult Create([FromBody] CreatorTransactionDTO transaction)
        {
             try
             {
                var transactionCreated = _transactionService.Add(transaction);
                return Ok(transactionCreated);
             }
             catch (ArgumentException ex)
             {
                return BadRequest(ex.Message);
             }
        }
        }
    }
