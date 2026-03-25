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
    public class WszystkieKategorieWiekoweViewModel : WszystkieViewModel<KategoriaWiekowa>
    {


        #region Konstruktor

        public WszystkieKategorieWiekoweViewModel()
        {
            base.DisplayName = "Kategorie wiekowe";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<KategoriaWiekowa>(
                kinoEntities.KategoriaWiekowa.ToList()
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
                        List = new ObservableCollection<KategoriaWiekowa>(List.OrderBy(k => k.NazwaKategorii));
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
                            List = new ObservableCollection<KategoriaWiekowa>(List.Where(k => k.NazwaKategorii.StartsWith(FindTextBox)));
                            break;
                        }
                }


            }
        }


        #endregion

    }
}
