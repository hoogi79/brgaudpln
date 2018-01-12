using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnfGefB
{
    public partial class Gefährdungsfaktoren
    {
        [NotMapped]
        public string KategorieNummerGefährdungsfaktor
        {
            get
            {
                return this.Kategorie.ToString() + "." + this.Nummer.ToString() + " " + this.Gefährdungsfaktor;
            }
        }
    }
}
