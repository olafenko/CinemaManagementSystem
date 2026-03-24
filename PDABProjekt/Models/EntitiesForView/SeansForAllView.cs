using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{
    public class SeansForAllView
    {


        #region Properties

        public int Id { get; set; }
        public string TytulFilmu { get; set; }
        public int Sala { get; set; }
        public int LiczbaMiejsc { get; set; }

        public string TypSali { get; set; }

        public string DataSeansu{ get; set; }
        public TimeSpan GodzinaOd { get; set; }
        public TimeSpan GodzinaDo { get; set; }

        public int CzasTrwania { get; set; }
        public string Status { get; set; }
        public string JezykWersji { get; set; }
        public string WersjaJezykowa { get; set; }

        public int WolneMiejsca { get; set; }

        #endregion


    }
}
