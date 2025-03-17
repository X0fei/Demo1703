using System;
using System.Collections.Generic;

namespace Demo1703.Models;

public partial class PartnersProduct
{
    public int Id { get; set; }

    public int Product { get; set; }

    public int Partner { get; set; }

    public int ProductQuantity { get; set; }

    public DateOnly SaleDate { get; set; }

    public virtual Partner PartnerNavigation { get; set; } = null!;

    public virtual Product ProductNavigation { get; set; } = null!;
}
