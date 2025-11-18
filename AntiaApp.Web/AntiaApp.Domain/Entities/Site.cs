using System;
using System.Collections.Generic;

namespace AntiaApp.Domain.Entities;

public partial class Site
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string? Adresse { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
