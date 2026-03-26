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
    public class WszystkieTypyEkranuViewModel : DisplayAllViewModelBase<TypEkranu>
    {

        #region Konstruktor

        public WszystkieTypyEkranuViewModel()
        {
            base.DisplayName = "Typy ekranu sali";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<TypEkranu>(
                kinoEntities.TypEkranu.Where(t => t.CzyAktywny == true).ToList()
                );
        }

        #endregion

        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Maksymalna rozdzielczość","Wymagane okulary"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Maksymalna rozdzielczość":
                    {
                        List = new ObservableCollection<TypEkranu>(List.OrderBy(e => e.MaksymalnaRozdzielczosc));
                        break;

                    }
                case "Wymagane okulary":
                    {
                        List = new ObservableCollection<TypEkranu>(List.OrderBy(e => e.CzyWymaganeOkulary3D));
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
                            List = new ObservableCollection<TypEkranu>(List.Where(e => e.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }

        #endregion

    }
}
