using System;
using System.Collections.Generic;

namespace AdoptiiAnimaleApp.Models.DBObjects;

public partial class Favorite
{
    internal Guid ID_Favorit;

    public Guid IdFavorit { get; set; }

    public Guid IdUtilizator { get; set; }

    public Guid IdAnimal { get; set; }

    public DateTime DataAdugare { get; set; }

    public virtual Animale IdAnimalNavigation { get; set; } = null!;

    public virtual Utilizatori IdUtilizatorNavigation { get; set; } = null!;
    public Guid ID_utilizator { get; internal set; }
    public Guid ID_animal { get; internal set; }
    public Guid ID_favorit { get; internal set; }
}
