
using FinancialControl.Models.DTOs;
using FinancialControl.Models.Entities;
namespace FinancialControl.Services.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction Add(CreatorTransactionDTO transaction);
        List<Transaction> GetTransactions();
        Transaction GetById(int id);
        List<Transaction> GetTransactionsByType(string type);
        double GetBalance();
    }
}
