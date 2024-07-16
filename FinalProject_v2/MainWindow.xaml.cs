using FinalProject_v2.Models;
using System.Windows;
using Microsoft.Win32;
using FinalProject_v2.Services;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace FinalProject_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TransactionService _transactionService;
        private CategoryService _categoryService;

        public MainWindow()
        {
            InitializeComponent();
            _transactionService = new TransactionService();
            _categoryService = new CategoryService();
            FinanceDataGrid.ItemsSource = _transactionService.Transactions;
            List<Category> categories = _categoryService.GetCategories();
            CategoriesListBox.ItemsSource = categories;
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to create a new file? All unsaved data will be lost.", "New File", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _transactionService.NewTransactions();
                FinanceDataGrid.ItemsSource = _transactionService.Transactions;
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                _transactionService.SaveTransactions(saveFileDialog.FileName);
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                _transactionService.LoadTransactions(openFileDialog.FileName);
                FinanceDataGrid.ItemsSource = _transactionService.Transactions;
            }
        }

        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {
            var transaction = new Transaction();
            var dialog = new TransactionAction(transaction);
            if (dialog.ShowDialog() == true)
            {
                _transactionService.AddTransaction(dialog.Transaction);
            }
        }

        private void EditTransaction_Click(object sender, RoutedEventArgs e)
        {
            var selectedTransaction = (Transaction)FinanceDataGrid.SelectedItem;
            if (selectedTransaction != null)
            {
                var transaction = new Transaction
                {
                    Date = selectedTransaction.Date,
                    Description = selectedTransaction.Description,
                    Category = selectedTransaction.Category,
                    Amount = selectedTransaction.Amount
                };

                var dialog = new TransactionAction(transaction);
                if (dialog.ShowDialog() == true)
                {
                    _transactionService.EditTransaction(dialog.Transaction, FinanceDataGrid.SelectedIndex);
                }
            }
        }

        private void DeleteTransaction_Click(object sender, RoutedEventArgs e)
        {
            var selectedTransaction = (Transaction)FinanceDataGrid.SelectedItem;
            if (selectedTransaction != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the transaction?\n\nDate: {selectedTransaction.Date}\nDescription: {selectedTransaction.Description}\nCategory: {selectedTransaction.Category}\nAmount: {selectedTransaction.Amount.ToString("C")}", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    _transactionService.DeleteTransaction(selectedTransaction);
                }
            }
        }

        private void CategoriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesListBox.SelectedItem is Category selectedCategory)
            {
                var filteredTransactions = _transactionService.Transactions.Where(t => t.Category == selectedCategory.Name).ToList();
                FinanceDataGrid.ItemsSource = new ObservableCollection<Transaction>(filteredTransactions);
            }
            else
            {
                FinanceDataGrid.ItemsSource = _transactionService.Transactions;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();
    }
}