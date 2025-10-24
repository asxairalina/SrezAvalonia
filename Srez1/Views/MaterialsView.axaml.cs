using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using Srez1.Data;
using System.Linq;

namespace Srez1.Views;

public partial class MaterialsView : UserControl
{
    private readonly AppDbContext _dbContext = new();

    public MaterialsView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        LoadMaterials();
    }

    private void LoadMaterials()
    {
        var materials = _dbContext.Materials
            .Include(m => m.Type)
            .Include(m => m.Unit)
            .ToList();

        MaterialsListBox.ItemsSource = materials;
    }
}