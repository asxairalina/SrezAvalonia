using System;
using System.Collections.Generic;

namespace Srez1.Data;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TypeId { get; set; }

    public string Inn { get; set; } = null!;

    public int? Rating { get; set; }

    public DateOnly? StartDate { get; set; }

    public virtual ICollection<MaterialSupplier> MaterialSuppliers { get; set; } = new List<MaterialSupplier>();

    public virtual SupplierType? Type { get; set; }
}
