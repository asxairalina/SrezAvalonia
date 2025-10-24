using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Microsoft.EntityFrameworkCore;
using Srez1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Srez1.Views;

public partial class AddEditProductWindow : Window, INotifyPropertyChanged
{
    private readonly Product _editingProduct;
    private readonly bool _isEditMode;
    private int? _originalTypeId = null;

    // Properties for data binding
    private string _productName = "";
    private string _minPartnerPrice = "0";
    private string _rollWidth = "0";
    private string _calculatedCost = "0";
    private string _productId = "";
    private ProductType _selectedProductType;
    private List<ProductType> _productTypes = new();

    public AddEditProductWindow(Product? product = null)
    {
        InitializeComponent();
        DataContext = this;

        if (product != null)
        {
            _editingProduct = product;
            _isEditMode = true;
            this.Title = "Edit Product";
            _originalTypeId = product.TypeId;
            LoadProductData();
        }
        else
        {
            _isEditMode = false;
            this.Title = "Add Product";
            ProductId = "Auto-generated";
        }

        LoadProductTypes();
        CalculateCost();
    }

    // Properties with change notification
    public string ProductName
    {
        get => _productName;
        set
        {
            SetField(ref _productName, value);
            CalculateCost();
        }
    }

    public string MinPartnerPrice
    {
        get => _minPartnerPrice;
        set
        {
            SetField(ref _minPartnerPrice, value);
            CalculateCost();
        }
    }

    public string RollWidth
    {
        get => _rollWidth;
        set
        {
            SetField(ref _rollWidth, value);
            CalculateCost();
        }
    }

    public string CalculatedCost
    {
        get => _calculatedCost;
        set => SetField(ref _calculatedCost, value);
    }

    public string ProductId
    {
        get => _productId;
        set => SetField(ref _productId, value);
    }

    public ProductType SelectedProductType
    {
        get => _selectedProductType;
        set
        {
            SetField(ref _selectedProductType, value);
            CalculateCost();
        }
    }

    public List<ProductType> ProductTypes
    {
        get => _productTypes;
        set => SetField(ref _productTypes, value);
    }

    private void LoadProductData()
    {
        if (_editingProduct != null)
        {
            ProductName = _editingProduct.Name;
            ProductId = _editingProduct.Id.ToString();
            MinPartnerPrice = _editingProduct.MinPartnerPrice?.ToString("F2") ?? "0.00";
            RollWidth = _editingProduct.RollWidth?.ToString("F2") ?? "0.00";

            if (_editingProduct.Param1.HasValue && _editingProduct.Param1 > 0)
            {
                CalculatedCost = _editingProduct.Param1.Value.ToString("F2");
            }
            else
            {
                CalculatedCost = "0.00";
            }
        }
    }

    private void LoadProductTypes()
    {
        try
        {
            ProductTypes = App.dbContext.ProductTypes.ToList();

            if (_isEditMode && _originalTypeId.HasValue)
            {
                SelectedProductType = ProductTypes.FirstOrDefault(t => t.Id == _originalTypeId.Value);
                if (SelectedProductType != null)
                {
                    Console.WriteLine($"Type loaded: {SelectedProductType.Name} (ID: {SelectedProductType.Id})");
                }
            }
            else if (!_isEditMode && ProductTypes.Any())
            {
                SelectedProductType = ProductTypes.First();
            }
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error loading product types: {ex.Message}");
        }
    }

    private void CalculateCost()
    {
        try
        {
            decimal baseCost = 0;

            if (SelectedProductType != null)
            {
                baseCost = SelectedProductType.Id * 500;
            }

            if (decimal.TryParse(MinPartnerPrice, out decimal minPrice) && minPrice > 0)
            {
                baseCost += minPrice * 0.7m;
            }

            if (decimal.TryParse(RollWidth, out decimal width) && width > 0)
            {
                baseCost += width * 200;
            }

            if (baseCost < 100) baseCost = 100;

            decimal overhead = baseCost * 0.15m;
            decimal totalCost = baseCost + overhead;
            totalCost = Math.Round(Math.Max(0, totalCost), 2);

            CalculatedCost = totalCost.ToString("F2");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error calculating cost: {ex.Message}");
            CalculatedCost = "0.00";
        }
    }

    // Новая кнопка "Назад" - возврат на страницу продуктов без сохранения
    private void BackClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("Back button clicked - returning to products page");
        this.Close(false); // Закрываем окно без сохранения
    }

    // Кнопка "Отмена" - то же самое что "Назад"
    private void CancelClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("Cancel button clicked - closing window");
        this.Close(false); // Закрываем окно без сохранения
    }

    // Кнопка "Сохранить" - сохраняет и закрывает
    private void SaveClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            Console.WriteLine("Save button clicked");

            if (!ValidateInput()) return;

            Product product;

            if (_isEditMode)
            {
                product = _editingProduct;
            }
            else
            {
                product = new Product();
                App.dbContext.Products.Add(product);
            }

            // Сохраняем данные
            product.Name = ProductName?.Trim() ?? "";

            if (decimal.TryParse(MinPartnerPrice, out decimal price))
            {
                product.MinPartnerPrice = Math.Round(Math.Max(0, price), 2);
            }

            if (decimal.TryParse(RollWidth, out decimal width))
            {
                product.RollWidth = Math.Round(Math.Max(0, width), 2);
            }

            if (SelectedProductType != null)
            {
                product.TypeId = SelectedProductType.Id;
            }

            if (decimal.TryParse(CalculatedCost, out decimal cost))
            {
                product.Param1 = cost;
            }

            App.dbContext.SaveChanges();
            this.Close(true); // Закрываем окно с результатом true
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error saving product: {ex.Message}");
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(ProductName))
        {
            ShowErrorMessage("Product name is required");
            return false;
        }

        if (SelectedProductType == null)
        {
            ShowErrorMessage("Please select product type");
            return false;
        }

        if (!decimal.TryParse(MinPartnerPrice, out decimal price) || price < 0)
        {
            ShowErrorMessage("Minimum price must be a positive number");
            return false;
        }

        if (!decimal.TryParse(RollWidth, out decimal width) || width < 0)
        {
            ShowErrorMessage("Roll width must be a positive number");
            return false;
        }

        return true;
    }

    private void ShowErrorMessage(string message)
    {
        Console.WriteLine($"ERROR: {message}");

        var errorDialog = new Window
        {
            Title = "Error",
            Width = 300,
            Height = 150,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        var stackPanel = new StackPanel
        {
            Margin = new Thickness(20),
            Spacing = 15
        };

        stackPanel.Children.Add(new TextBlock
        {
            Text = message,
            TextWrapping = TextWrapping.Wrap,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        });

        var okButton = new Button
        {
            Content = "OK",
            Width = 80,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };
        okButton.Click += (s, e) => errorDialog.Close();

        stackPanel.Children.Add(okButton);
        errorDialog.Content = stackPanel;

        errorDialog.ShowDialog(this);
    }

    // INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}