using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class WszystkieStatusyFilmuViewModel : DisplayAllViewModelBase<StatusFilmu>
    {

        #region Konstruktor

        public WszystkieStatusyFilmuViewModel()
        {
            base.DisplayName = "Statusy dla filmu";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<StatusFilmu>(
                kinoEntities.StatusFilmu.Where(t => t.CzyAktywny == true).ToList()
                );
        }

        #endregion

        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Nazwa"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    {
                        List = new ObservableCollection<StatusFilmu>(List.OrderBy(s => s.NazwaStatusu));
                        break;
                    }

            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa"
            };
        }

        public override void Find()
        {
            if (String.IsNullOrWhiteSpace(FindTextBox))
            {
                Load();
            }

            else
            {
                switch (FindField)
                {
                    case "Nazwa":
                        {
                            List = new ObservableCollection<StatusFilmu>(List.Where(s => s.NazwaStatusu.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }


        #endregion

    }
}
