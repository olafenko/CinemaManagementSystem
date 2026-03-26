using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PDABProjekt.ViewModels
{
    public class WszyscyRezyserzyViewModel : DisplayAllViewModelBase<RezyserForAllView>
    {

        #region Konstruktor

        public WszyscyRezyserzyViewModel()
        {
            base.DisplayName = "Reżyserzy";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<RezyserForAllView>(
                kinoEntities.Rezyser.Where(r => r.CzyAktywny).Select(r => new RezyserForAllView
                {

                    ID = r.IdRezysera,
                    Imie = r.Imie,
                    Nazwisko = r.Nazwisko,
                    Kraj = r.Kraj.Nazwa,

                })
                );

        }

        #endregion

        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Kraj"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Kraj":
                    {
                        List = new ObservableCollection<RezyserForAllView>(List.OrderBy(r => r.Kraj));
                        break;
                    }

            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Imie","Nazwisko"
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
                    case "Imie":
                        {
                            List = new ObservableCollection<RezyserForAllView>(List.Where(r => r.Imie.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Nazwisko":
                        {
                            List = new ObservableCollection<RezyserForAllView>(List.Where(r => r.Nazwisko.StartsWith(FindTextBox)));
                            break;
                        }



                }

                
            }
        }


        #endregion
    }
}
