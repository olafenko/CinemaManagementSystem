using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.BusinessLogic
{
    public class DatabaseClass
    {


        #region BazaDanych

        protected PABProjektEntities kinoEntities;

        #endregion


        #region Konstruktor

        public DatabaseClass(PABProjektEntities kinoEntities)
        {
            this.kinoEntities = kinoEntities;
        }

        #endregion



    }
}
