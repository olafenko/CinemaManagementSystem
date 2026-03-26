using PDABProjekt.Models;
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
    public class WszystkieGatunkiViewModel : DisplayAllViewModelBase<GatunekFilmu>
    {


        #region Konstruktor

        public WszystkieGatunkiViewModel()
        {
            base.DisplayName = "Gatunki filmowe";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<GatunekFilmu>(
                kinoEntities.GatunekFilmu.Where(t => t.CzyAktywny == true).ToList()
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
                        List = new ObservableCollection<GatunekFilmu>(List.OrderBy(g => g.NazwaGatunku));
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
                            List = new ObservableCollection<GatunekFilmu>(List.Where(g => g.NazwaGatunku.StartsWith(FindTextBox)));
                            break;
                        }                 
                }

                
            }
        }


        #endregion

    }
}
