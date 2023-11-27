using System;
using System.Collections.Generic;

namespace AdoptiiAnimaleApp.Models.DBObjects;

public partial class Adoptii
{
    public Guid Id_adoptie { get; set; }

    public Guid IdUtilizator { get; set; }

    public Guid IdAnimal { get; set; }

    public DateTime DataAdoptiei { get; set; }

    public string StatusAdoptie { get; set; } = null!;

    public virtual Animale IdAnimalNavigation { get; set; } = null!;

    public virtual Utilizatori IdUtilizatorNavigation { get; set; } = null!;
}
