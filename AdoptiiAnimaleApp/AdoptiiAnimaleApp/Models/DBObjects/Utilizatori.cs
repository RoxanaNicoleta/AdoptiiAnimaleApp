using System;
using System.Collections.Generic;

namespace AdoptiiAnimaleApp.Models.DBObjects;

public partial class Utilizatori
{
    public Guid IdUtilizator { get; set; }

    public string TipUtilizator { get; set; } = null!;

    public string Nume { get; set; } = null!;

    public string Prenume { get; set; } = null!;

    public string Adresa { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NrTelefon { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Parola { get; set; } = null!;

    public virtual ICollection<Adoptii> Adoptiis { get; set; } = new List<Adoptii>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
