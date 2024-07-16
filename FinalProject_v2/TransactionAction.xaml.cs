using FinalProject_v2.Models;
using FinalProject_v2.Services;
using System.Windows;

namespace FinalProject_v2;
public partial class TransactionAction : Window
{
    public Transaction Transaction { get; set; }
    public CategoryService _categoryService { get; set; }
    public List<Category> Categories { get; set; } // Assuming you have a Category model

    public TransactionAction(Transaction transaction)
    {
        InitializeComponent();
        Transaction = transaction ?? new Transaction();
        DataContext = Transaction;
        _categoryService = new CategoryService();
        LoadCategories();
    }

    private void LoadCategories()
    {
        // Assuming GetCategories() fetches your categories
        Categories = _categoryService.GetCategories();
        CategoryComboBox.ItemsSource = Categories;

        // If you want to select the category of the current transaction (if it exists)
        if (Transaction != null && !string.IsNullOrEmpty(Transaction.Category))
        {
            CategoryComboBox.SelectedValue = Transaction.Category;
        }
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}
