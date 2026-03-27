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
    public class AllAgeCategoriesViewModel : DisplayAllViewModelBase<KategoriaWiekowa>
    {


        #region Constructor

        public AllAgeCategoriesViewModel()
        {
            base.DisplayName = "Kategorie wiekowe";
        }

        #endregion

        #region Llist
        public override void Load()
        {
            List = new ObservableCollection<KategoriaWiekowa>(
                kinoEntities.KategoriaWiekowa.ToList()
                );
        }

        #endregion

        #region Sorting and filtering

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
