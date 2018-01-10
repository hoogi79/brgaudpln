using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnfGefB
{
    public partial class Gesetze
    {
        [NotMapped]
        public List<int> ParagraphenListe
        {
            get
            {
                return this.Paragraphen.Select(p => p.Paragraph).ToList();
            }
        }
    }
}
