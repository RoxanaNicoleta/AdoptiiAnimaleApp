using AdoptiiAnimaleApp.Models.DBObjects;
using System;
using System.Collections.Generic;


namespace AdoptiiAnimaleApp.Models
{
    public class AnimaleModel
    {
        public Guid IdAnimal { get; set; }

        public string Nume { get; set; } = null!;

        public string Specie { get; set; } = null!;

        public string Rasa { get; set; } = null!;

        public int Varsta { get; set; }

        public string Gen { get; set; } = null!;

        public string? Descriere { get; set; }

        public string? Poza { get; set; }

        public virtual ICollection<Adoptii> Adoptiis { get; set; } = new List<Adoptii>();

        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    }
}
