using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{
    public class SalaForAllView
    {

        #region Properties

        public int Id { get; set; }
        public int NumerSali { get; set; }
        public int LiczbaMiejsc { get; set; }
        public string NazwaEkranu { get; set; }
        public string RozdzielczoscEkranu { get; set; }
        public string NazwaNaglosnienia { get; set; }
        public string TypSali { get; set; }
        public string Uwagi { get; set; }
        

        #endregion

    }
}
