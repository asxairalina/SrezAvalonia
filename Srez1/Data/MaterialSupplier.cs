using System;
using System.Collections.Generic;

namespace Srez1.Data;

public partial class MaterialSupplier
{
    public int Id { get; set; }

    public int MaterialId { get; set; }

    public int SupplierId { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
