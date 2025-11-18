using System;
using System.Collections.Generic;

namespace AntiaApp.Domain.Entities;

public partial class Assurance
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public decimal Montant { get; set; }

    public DateOnly DateDebut { get; set; }

    public DateOnly DateFin { get; set; }

    public string Statut { get; set; } = null!;

    public string? Description { get; set; }

    public int ClientId { get; set; }

    public DateTime DateCreation { get; set; }

    public DateTime? DateModification { get; set; }

    public virtual Client? Client { get; set; }
}
