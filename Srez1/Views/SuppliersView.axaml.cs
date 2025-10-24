using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using Srez1.Data;
using System.Linq;

namespace Srez1.Views;

public partial class SuppliersView : UserControl
{
    private readonly AppDbContext _dbContext = new();

    public SuppliersView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        LoadSuppliers();
    }

    private void LoadSuppliers()
    {
        var suppliers = _dbContext.Suppliers
            .Include(s => s.Type)
            .ToList();

        SuppliersListBox.ItemsSource = suppliers;
    }
}