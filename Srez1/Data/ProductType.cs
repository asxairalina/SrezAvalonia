using System;
using System.Collections.Generic;

namespace Srez1.Data;

public partial class ProductType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal CoeffType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
