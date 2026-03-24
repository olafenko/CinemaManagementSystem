using PDABProjekt.Helper;
using PDABProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDABProjekt.ViewModels.Abstract
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {

        #region BazaDanych

        protected PABProjektEntities kinoEntities;
        protected T item;

        #endregion

        #region Konstruktor

        public JedenViewModel()
        {
            kinoEntities = new PABProjektEntities();
        }

        #endregion

        #region Command

        //to jest komenda ktora zostanie podpieta pod przycisk zapisz i zamknij
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null) _SaveAndCloseCommand = new BaseCommand(SaveAndClose);
                return _SaveAndCloseCommand;
            }
        }

        public abstract void Save();

        private void SaveAndClose()
        {
            Save();
            OnRequestClose();// zamyka zakladke
        }


        #endregion


    }
}
