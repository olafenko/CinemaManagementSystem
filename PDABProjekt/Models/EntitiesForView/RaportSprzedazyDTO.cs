using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{
 
    //klasa zawierająca pola do raportu sprzedazy biletow
    
    public class RaportSprzedazyDTO
    {
        

        public decimal? Utarg { get; set; }
        public int? IloscBiletow { get; set; }
        public decimal? SredniaCenaBiletu { get; set; }


    }
}
