using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{

    //klasa trzymająca pola do statystyk ogolnych kina
    public class StatystykiOgolneDTO
    {

        public int? SprzedaneBilety { get; set; }
        public decimal? Utarg { get; set; }

        public string NajpopularniejszySeans {get; set; }
        public string NajpopularniejszyFilm {get; set; }
        public decimal? SrednieWypelnienieSali {get; set; }
        public int? LiczbaSeansow {get; set; }


    }
}
