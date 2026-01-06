using FinancialControl.Models.DTOs;
using FinancialControl.Models.Entities;
using FinancialControl.Services.Services.Interfaces;
using Transaction = FinancialControl.Models.Entities.Transaction;

namespace FinancialControl.Services.Services
{
    public class TransactionServices : ITransactionService
    {
        //Cria lista para receber os objetos da classe
        private readonly List<Transaction> _transactions = new();

        //Método que adiciona os itens na lista
        public Transaction Add(CreatorTransactionDTO transactionDTO)
        {
            if (transactionDTO.Amount <= 0)
            {
                throw new ArgumentException("O valor deve ser maior que zero");
            }
            Transaction newTransaction = new(transactionDTO.Description, transactionDTO.Amount, transactionDTO.Type);
            _transactions.Add(newTransaction);
            return newTransaction;
        }

        //Método para retornar os itens da lista
        public List<Transaction> GetTransactions()
        {
            if (!_transactions.Any())
            {
                throw new InvalidOperationException("Nenhuma transação registrada até o momento.");
            }

            return _transactions;
        }

        //Método para retornar um item da lista pelo id
        public Transaction GetById(int id) 
        {
            Transaction transaction = _transactions.FirstOrDefault(x => x.Id == id);

            if(transaction == null)
            {
               throw new InvalidOperationException("Nenhuma transação foi encontrada com o id fornecido");
            
            }
            return transaction;
        }
        //Método para retornar uma lista itens do mesmo tipo
        public List<Transaction> GetTransactionsByType(string type)
        {
            var transactions = _transactions.Where(x => x.Type.Equals(type)).ToList();
            if (!transactions.Any()) 
            {
                throw new InvalidOperationException($"Nenhuma transação do tipo {type}");
            }
            return transactions;
        }

        public double GetBalance()
        {
            double total = _transactions.Sum(x => x.Amount);
            if (total == 0)
            {
                throw new InvalidOperationException("nenhuma transação registrada até o momento.");
            }
            return total;
        }


    }
}
