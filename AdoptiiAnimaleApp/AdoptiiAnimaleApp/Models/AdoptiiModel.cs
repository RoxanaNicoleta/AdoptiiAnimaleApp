using AdoptiiAnimaleApp.Models.DBObjects;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace AdoptiiAnimaleApp.Models
{
    public class AdoptiiModel
    {

        public Guid IdAdoptie { get; set; }

        public Guid IdUtilizator { get; set; }

        public Guid IdAnimal { get; set; }

        [DisplayFormat (DataFormatString ="0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        
        public DateTime DataAdoptiei { get; set; }

        public string StatusAdoptie { get; set; } = null!;

        public virtual Animale IdAnimalNavigation { get; set; } = null!;

        public virtual Utilizatori IdUtilizatorNavigation { get; set; } = null!;

       
    }
}
