using System;
using System.Collections.Generic;

namespace Srez1.Data;

public partial class UnitType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
