using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{
    public class FilmForAllView
    {


        #region Properties

        public int Id { get; set; }
        public string Tytul { get; set; }
        public string TytulOryginalny { get; set; }
        public string Opis { get; set; }
        public int CzasTrwania{ get; set; }
        public int? RokProdukcji { get; set; }
        public string JezykOryginalny { get; set; }
        public string NazwaGatunku { get; set; }
        public string KrajProdukcji { get; set; } 
        public string NazwaDystrybutora { get; set; } // nazwa zamiast id 
        public DateTime? DataPremiery { get; set; }
        public string UrlPlakatu { get; set; }
        public string Status{ get; set; } // nazwa zamiast id
        public string KategoriaWiekowa { get; set; }         // nazwa zamiast id
        public string NazwaRezysera { get; set; } 
        public string NazwaProducenta { get; set; } 
      

        #endregion
    }

}
