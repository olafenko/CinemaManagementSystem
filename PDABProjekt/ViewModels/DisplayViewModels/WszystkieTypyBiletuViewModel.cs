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
    public class WszystkieTypyBiletuViewModel : DisplayAllViewModelBase<TypBiletu>
    {
        #region Konstruktor

        public WszystkieTypyBiletuViewModel()
        {
            base.DisplayName = "Typy biletów";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<TypBiletu>(
                kinoEntities.TypBiletu.Where(t => t.CzyAktywny == true).ToList()
                );
        }

        #endregion

        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Cena bazowa"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Cena bazowa":
                    {
                        List = new ObservableCollection<TypBiletu>(List.OrderBy(b => b.Cena));
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
                            List = new ObservableCollection<TypBiletu>(List.Where(b => b.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }


        #endregion

    }
}
