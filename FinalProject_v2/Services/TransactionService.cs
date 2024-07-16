using FinalProject_v2.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace FinalProject_v2.Services
{
    public class TransactionService
    {
        public ObservableCollection<Transaction> Transactions { get; set; }

        public TransactionService()
        {
            Transactions = new ObservableCollection<Transaction>();
        }

        public void NewTransactions()
        {
            Transactions.Clear();
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void EditTransaction(Transaction transaction, int index)
        {
            if (index >= 0 && index < Transactions.Count)
            {
                Transactions[index] = transaction;
            }
        }

        public void DeleteTransaction(Transaction transaction)
        {
            Transactions.Remove(transaction);
        }

        public void SaveTransactions(string filePath)
        {
            string json = JsonSerializer.Serialize(Transactions);
            File.WriteAllText(filePath, json);
        }

        public void LoadTransactions(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Transactions = JsonSerializer.Deserialize<ObservableCollection<Transaction>>(json);
            }
        }
    }
}
