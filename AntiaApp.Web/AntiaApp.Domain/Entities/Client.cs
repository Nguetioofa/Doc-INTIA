using System;
using System.Collections.Generic;

namespace AntiaApp.Domain.Entities;

public partial class Client
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Adresse { get; set; }

    public int SiteId { get; set; }

    public DateTime DateCreation { get; set; }

    public DateTime? DateModification { get; set; }

    public virtual ICollection<Assurance> Assurances { get; set; } = new List<Assurance>();

    public virtual Site Site { get; set; } = null!;
}
