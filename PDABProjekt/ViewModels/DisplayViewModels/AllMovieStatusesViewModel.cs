using PDABProjekt.Models;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AllMovieStatusesViewModel : DisplayAllViewModelBase<StatusFilmu>
    {

        #region Constructor

        public AllMovieStatusesViewModel()
        {
            base.DisplayName = "Statusy dla filmu";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<StatusFilmu> query = kinoEntities.StatusFilmu.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<StatusFilmu>(query.ToList());
        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Nazwa"
            };
        }

        private IQueryable<StatusFilmu> ApplySort(IQueryable<StatusFilmu> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(s => s.NazwaStatusu);

                default: return query;

            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa"
            };
        }

        private IQueryable<StatusFilmu> ApplyFilter(IQueryable<StatusFilmu> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(s => s.NazwaStatusu.Contains(FindTextBox));

                default: return query;
            }

        }

        #endregion

    }
}
