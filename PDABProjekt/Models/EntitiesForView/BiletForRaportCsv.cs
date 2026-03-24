using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{
    public class BiletForRaportCsv
    {


        #region Properties

        public string NazwaSeansu { get; set; }
        public string DataSeansu { get; set; }
        public TimeSpan SeansOd { get; set; }
        public TimeSpan SeansDo { get; set; }
        public int NumerSali { get; set; }
        public int NumerRzedu { get; set; }
        public int NumerMiejsca { get; set; }
        public string TypMiejsca { get; set; }
        public string TypBiletu { get; set; }
        public string Rabat { get; set; }
        public string CenaFinalna { get; set; }
        public DateTime DataSprzedazy { get; set; }

        #endregion

    }
}
