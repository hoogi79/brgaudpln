using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnfGefB
{
    public partial class GefährdungsfaktorenKategorien
    {
        
        public string NummerText
        {
            get
            {
                return this.Nummer.ToString() + ": " + this.Text;
            }
        }
    }
}
