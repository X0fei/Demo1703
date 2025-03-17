using System;
using System.Collections.Generic;

namespace Demo1703.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public string Article { get; set; } = null!;

    public decimal MinimalCost { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual ProductType TypeNavigation { get; set; } = null!;
}
