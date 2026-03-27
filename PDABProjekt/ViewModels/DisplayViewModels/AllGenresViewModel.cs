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
    public class AllGenresViewModel : DisplayAllViewModelBase<GatunekFilmu>
    {


        #region Constructor

        public AllGenresViewModel()
        {
            base.DisplayName = "Gatunki filmowe";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<GatunekFilmu> query = kinoEntities.GatunekFilmu.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplyFilter(query);


            List = new ObservableCollection<GatunekFilmu>(query.ToList());
        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "brak"
            };
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa"
            };
        }

        private IQueryable<GatunekFilmu> ApplyFilter(IQueryable<GatunekFilmu> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(g => g.NazwaGatunku.Contains(FindTextBox));

                default: return query;
            }

        }


        #endregion

    }
}
