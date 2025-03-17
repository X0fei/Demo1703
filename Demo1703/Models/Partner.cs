using System;
using System.Collections.Generic;

namespace Demo1703.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public int Rating { get; set; }

    public int Type { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual PartnerType TypeNavigation { get; set; } = null!;
}
