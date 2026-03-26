using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace PDABProjekt.ViewModels
{
    public class WszyscyProducenciViewModel : DisplayAllViewModelBase<ProducentForAllView>
    {

        #region Konstruktor

        public WszyscyProducenciViewModel()
        {
            base.DisplayName = "Producenci";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<ProducentForAllView>(
                kinoEntities.Producent.Where(p => p.CzyAktywny).Select(p => new ProducentForAllView
                {

                    ID = p.IdProducenta,
                    Nazwa = p.Nazwa,
                    Kraj = p.Kraj.Nazwa,
                    Opis = p.Opis

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
                        List = new ObservableCollection<ProducentForAllView>(List.OrderBy(p => p.Kraj));
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
                            List = new ObservableCollection<ProducentForAllView>(List.Where(p => p.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }
                   
                   

                }

               
            }
        }


        #endregion

    }
}
