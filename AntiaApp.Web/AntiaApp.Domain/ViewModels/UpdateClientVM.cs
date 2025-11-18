using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiaApp.Domain.ViewModels;

public class UpdateClientVM
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Adresse { get; set; }

    public int SiteId { get; set; }
    public DateTime DateCreation { get; set; }

}
