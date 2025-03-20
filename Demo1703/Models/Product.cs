using System;
using System.Collections.Generic;
using System.Linq;

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
    
    //Список партнёров товара
    public string PartnerNames
    {
        get
        {
            return string.Join(", ", PartnersProducts.Select(p => p.PartnerNavigation.Name));
        }
    }
    
    //В зависимости от количества проданой (с начала 2024 года) продуктции, товар окрашивается в определённый цвет
    public string ItemColor
    {
        get
        {
            DateOnly date = new DateOnly(2024, 01, 01);
            switch(PartnersProducts.Where(p => p.SaleDate >= date).Select(p => p.ProductQuantity).Sum())
            {
                case < 10000: return "Salmon";
                case < 60000: return "SandyBrown";
                case >= 60000: return "PaleGreen";
            }
        }
    }
}
