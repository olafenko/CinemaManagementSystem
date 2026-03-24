using PDABProjekt.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDABProjekt.ViewModels.Abstract
{


    // klasa bazowa dla klas zwiazanych z raportami
    public abstract class RaportViewModelBase : WorkspaceViewModel
    {


        private BaseCommand _ObliczCommand;

        public ICommand ObliczCommand

        {
            get
            {
                if (_ObliczCommand == null) _ObliczCommand = new BaseCommand(obliczRaportClick);
                return _ObliczCommand;
            }

        }


        public abstract void obliczRaportClick();

        private BaseCommand _ExportCommand;

        public ICommand ExportCommand
        {
            get
            {
                if (_ExportCommand == null) _ExportCommand = new BaseCommand(eksportujRaportClick);
                return _ExportCommand;
            }
        }

        public abstract void eksportujRaportClick();

        }
}
