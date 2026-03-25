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
    public class WszystkieJezykiViewModel : WszystkieViewModel<Jezyk>
    {

        #region Konstruktor

        public WszystkieJezykiViewModel()
        {
            base.DisplayName = "Jezyki";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<Jezyk>(
                kinoEntities.Jezyk.Where(t => t.CzyAktywny == true).ToList()
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
                        List = new ObservableCollection<Jezyk>(List.OrderBy(j => j.Nazwa));
                        break;
                    }

            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa", "Kod ISO"
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
                            List = new ObservableCollection<Jezyk>(List.Where(j => j.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Kod ISO":
                        {
                            List = new ObservableCollection<Jezyk>(List.Where(j => j.KodISO.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }


        #endregion

    }
}
