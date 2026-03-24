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
    public abstract class AddViewModelBase<T> : DatabaseVMClass
    {

        #region Fields

        protected T item;

        #endregion

        #region Konstruktor

        public AddViewModelBase() : base() { }

        #endregion

        #region Commands

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
            OnRequestClose();
        }


        #endregion


    }
}
