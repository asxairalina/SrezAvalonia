using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using Srez1.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Srez1.Views;

public partial class ProductsView : UserControl
{
    private List<Product> _allProducts = new();

    public ProductsView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
        SearchBox.TextChanged += (s, e) => ApplyFilter();
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        LoadProducts();
    }

    private void LoadProducts()
    {
        try
        {
            _allProducts = App.dbContext.Products
                .Include(p => p.Type) 
                .Include(p => p.ProductMaterials)
                    .ThenInclude(pm => pm.Material)
                .ToList();

            bool hasChanges = false;

            foreach (var product in _allProducts)
            {
               
                if (product.Param1.HasValue && product.Param1 > 0)
                {
                    product.CalculatedCost = product.Param1.Value;
                }
                else
                {
                    
                    decimal calculatedCost = CalculateProductCost(product);
                    product.CalculatedCost = calculatedCost;
                    product.Param1 = calculatedCost;
                    hasChanges = true;
                }
            }

            if (hasChanges)
            {
                App.dbContext.SaveChanges();
                Console.WriteLine("Product costs saved to Param1");
            }

            ApplyFilter();
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error loading products: {ex.Message}");
        }
    }

    private decimal CalculateProductCost(Product product)
    {
        if (product?.ProductMaterials == null || !product.ProductMaterials.Any())
            return 0;

        decimal totalMaterialCost = 0;

        foreach (var productMaterial in product.ProductMaterials)
        {
            if (productMaterial.Material != null && productMaterial.MaterialQty.HasValue)
            {
                decimal materialPrice = productMaterial.Material.Price;
                decimal materialQuantity = productMaterial.MaterialQty.Value;
                totalMaterialCost += materialPrice * materialQuantity;
            }
        }

        decimal overheadCost = totalMaterialCost * 0.15m;
        decimal totalCost = totalMaterialCost + overheadCost;
        return Math.Max(0, Math.Round(totalCost, 2));
    }

    private void ApplyFilter()
    {
        try
        {
            string searchText = SearchBox.Text?.Trim() ?? "";

            var filteredProducts = _allProducts
                .Where(p => string.IsNullOrEmpty(searchText) ||
                           p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                           p.Id.ToString().Contains(searchText))
                .ToList();

            ProductsListBox.ItemsSource = filteredProducts;
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Filter error: {ex.Message}");
        }
    }

    private void AddProductClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var addProductWindow = new AddEditProductWindow();
            addProductWindow.Closed += (s, e) =>
            {
                Console.WriteLine("AddEditProductWindow closed, reloading products...");
                LoadProducts();
            };
            addProductWindow.Show();
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error opening add form: {ex.Message}");
        }
    }

    private void EditProductClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (sender is Button button && button.Tag is int productId)
            {
                var product = _allProducts.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    var editProductWindow = new AddEditProductWindow(product);
                    editProductWindow.Closed += (s, e) => LoadProducts();
                    editProductWindow.Show();
                }
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error opening edit form: {ex.Message}");
        }
    }

    private void DeleteProductClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (sender is Button button && button.Tag is int productId)
            {
                var product = _allProducts.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    App.dbContext.Products.Remove(product);
                    App.dbContext.SaveChanges();
                    LoadProducts();

                    ShowInfoMessage("Product deleted successfully");
                }
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error deleting product: {ex.Message}");
        }
    }

    private void RecalculateCostsClick(object? sender, RoutedEventArgs e)
    {
        RecalculateAllCosts();
    }

    // ћетод дл€ принудительного пересчета стоимости
    public void RecalculateAllCosts()
    {
        try
        {
            var products = App.dbContext.Products
                .Include(p => p.ProductMaterials)
                    .ThenInclude(pm => pm.Material)
                .ToList();

            foreach (var product in products)
            {
                decimal calculatedCost = CalculateProductCost(product);
                product.CalculatedCost = calculatedCost;
                product.Param1 = calculatedCost;
                Console.WriteLine($"Product {product.Name}: Cost updated to {calculatedCost:C}");
            }

            int changes = App.dbContext.SaveChanges();
            LoadProducts();
            ShowInfoMessage($"All product costs recalculated successfully. {changes} records updated.");
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error recalculating costs: {ex.Message}");
        }
    }

    private void ShowErrorMessage(string message)
    {
        Console.WriteLine($"ERROR: {message}");
    }

    private void ShowInfoMessage(string message)
    {
        Console.WriteLine($"INFO: {message}");
    }
}