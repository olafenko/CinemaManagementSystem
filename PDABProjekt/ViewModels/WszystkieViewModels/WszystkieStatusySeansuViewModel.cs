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
    public class WszystkieStatusySeansuViewModel : WszystkieViewModel<StatusSeansu>
    {
        #region Konstruktor

        public WszystkieStatusySeansuViewModel()
        {
            base.DisplayName = "Statusy dla seansu";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<StatusSeansu>(
                kinoEntities.StatusSeansu.ToList()
                );
        }

        #endregion

        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Nazwa","Sprzedaż biletów"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    {
                        List = new ObservableCollection<StatusSeansu>(List.OrderBy(s => s.Nazwa));
                        break;
                    }
                case "Sprzedaż biletów":
                    {
                        List = new ObservableCollection<StatusSeansu>(List.OrderBy(s => s.CzySprzedawacBilety));
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
                            List = new ObservableCollection<StatusSeansu>(List.Where(s => s.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }


        #endregion

    }
}
