using System;
using System.Collections.Generic;

namespace Srez1.Data;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TypeId { get; set; }

    public decimal Price { get; set; }

    public decimal? StockQuantity { get; set; }

    public decimal? MinQuantity { get; set; }

    public decimal? PackQuantity { get; set; }

    public int? UnitId { get; set; }

    public virtual ICollection<MaterialSupplier> MaterialSuppliers { get; set; } = new List<MaterialSupplier>();

    public virtual ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();

    public virtual MaterialType? Type { get; set; }

    public virtual UnitType? Unit { get; set; }
}
