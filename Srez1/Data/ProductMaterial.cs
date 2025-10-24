using System;
using System.Collections.Generic;

namespace Srez1.Data;

public partial class ProductMaterial
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int MaterialId { get; set; }

    public decimal? MaterialQty { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public decimal TotalCost
    {
        get
        {
            if (Material != null && MaterialQty.HasValue)
            {
                return Material.Price * MaterialQty.Value;
            }
            return 0;
        }
    }
}
