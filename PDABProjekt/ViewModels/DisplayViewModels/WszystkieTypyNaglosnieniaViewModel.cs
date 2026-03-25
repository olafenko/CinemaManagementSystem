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
    public class WszystkieTypyNaglosnieniaViewModel : WszystkieViewModel<TypNaglosnienia>
    {

        #region Konstruktor

        public WszystkieTypyNaglosnieniaViewModel()
        {
            base.DisplayName = "Typy naglosnienia sali";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<TypNaglosnienia>(
                kinoEntities.TypNaglosnienia.Where(t => t.CzyAktywny == true).ToList()
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
                        List = new ObservableCollection<TypNaglosnienia>(List.OrderBy(n => n.Nazwa));
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
                            List = new ObservableCollection<TypNaglosnienia>(List.Where(n => n.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }


        #endregion

    }
}
