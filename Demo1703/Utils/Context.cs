using Demo1703.Context;
using Demo1703.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1703.Utils
{
    public static class Context
    {
        public static User18Context DbContext { get; set; } = new();
        public static List<Product> products { get; set; } = [.. DbContext.Products
            .Include(product => product.TypeNavigation)
            .Include(product => product.PartnersProducts)];
        public static List<Partner> partners { get; set; } = [.. DbContext.Partners
            .Include(partner => partner.PartnersProducts)];
        public static List<ProductType> productTypes { get; set; } = [.. DbContext.ProductTypes];
    }
}
