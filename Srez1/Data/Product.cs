using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Srez1.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TypeId { get; set; }

    public decimal? MinPartnerPrice { get; set; }

    public decimal? RollWidth { get; set; }

    public decimal? Param1 { get; set; }

    public decimal? Param2 { get; set; }

    [NotMapped]
    public decimal CalculatedCost { get; set; }

    public virtual ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();

    public virtual ProductType? Type { get; set; }
}
