using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Srez1.Views;

namespace Srez1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        NavigateToProducts(null, null);
    }

    private void NavigateToProducts(object? sender, RoutedEventArgs? e)
    {
        MainContent.Content = new ProductsView();
        UpdateButtonStyles(ProductsBtn);
        this.Title = "Production Management System - Products";
    }

    private void NavigateToMaterials(object? sender, RoutedEventArgs? e)
    {
        MainContent.Content = new MaterialsView();
        UpdateButtonStyles(MaterialsBtn);
        this.Title = "Production Management System - Materials";
    }

    private void NavigateToSuppliers(object? sender, RoutedEventArgs? e)
    {
        MainContent.Content = new SuppliersView();
        UpdateButtonStyles(SuppliersBtn);
        this.Title = "Production Management System - Suppliers";
    }

    private void UpdateButtonStyles(Button activeButton)
    {
        
        ProductsBtn.Background = Brushes.Transparent;
        MaterialsBtn.Background = Brushes.Transparent;
        SuppliersBtn.Background = Brushes.Transparent;

        ProductsBtn.Foreground = new SolidColorBrush(Color.Parse("#546F94"));
        MaterialsBtn.Foreground = new SolidColorBrush(Color.Parse("#546F94"));
        SuppliersBtn.Foreground = new SolidColorBrush(Color.Parse("#546F94"));

        
        activeButton.Background = new SolidColorBrush(Color.Parse("#546F94"));
        activeButton.Foreground = Brushes.White;
    }
}