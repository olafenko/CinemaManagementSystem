using PDABProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels.Abstract
{
    public abstract class DatabaseVMClass : WorkspaceViewModel
    {

        #region Database

        protected PABProjektEntities kinoEntities;

        public DatabaseVMClass()
        {
           kinoEntities = new PABProjektEntities();
        }

        #endregion


    }
}
