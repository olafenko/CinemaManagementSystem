using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{

    // klasa trzymająca pola do raportu  
    public class RaportZapelnieniaSeansowDTO
    {

        public string TytulSeansu { get; set; }
        public TimeSpan GodzinaOd { get; set; }
        public TimeSpan GodzinaDo { get; set; }
        
        public int LiczbaMiejsc { get; set; }
        public int? LiczbaZajetychMiejsc { get; set; }

        public decimal? ProcentWypelnienia{ get; set; }
        public string StatusWypelnienia { get; set; }

        


    }
}
