using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.EntitiesForView
{
    public class DystrybutorForAllView
    {

        #region Properties


        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string NazwaKraju { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public decimal? ProcentProwizji { get; set; }
        public string ModelRozliczen { get; set;   }
        public bool CzyUmowaPodpisana { get; set; }
        public string NumerUmowy { get; set; }
        public DateTime? UmowaOd { get; set; }
        public DateTime? UmowaDo { get; set; }


        #endregion


    }
}
