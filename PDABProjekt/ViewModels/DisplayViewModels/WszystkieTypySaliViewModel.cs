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
    public class WszystkieTypySaliViewModel : WszystkieViewModel<TypSali>
    {
        #region Konstruktor

        public WszystkieTypySaliViewModel()
        {
            base.DisplayName = "Typy sali";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<TypSali>(
                kinoEntities.TypSali.Where(t => t.CzyAktywny == true).ToList()
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
                        List = new ObservableCollection<TypSali>(List.OrderBy(s => s.Nazwa));
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
                            List = new ObservableCollection<TypSali>(List.Where(s => s.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }


        #endregion

    }
}
