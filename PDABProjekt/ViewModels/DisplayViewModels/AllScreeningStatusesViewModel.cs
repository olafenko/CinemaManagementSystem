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
    public class AllScreeningStatusesViewModel : DisplayAllViewModelBase<StatusSeansu>
    {
        #region Constructor

        public AllScreeningStatusesViewModel()
        {
            base.DisplayName = "Statusy dla seansu";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<StatusSeansu> query = kinoEntities.StatusSeansu.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<StatusSeansu>(query.ToList());
        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Nazwa","Sprzedaż biletów"
            };
        }

        private IQueryable<StatusSeansu> ApplySort(IQueryable<StatusSeansu> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(s => s.Nazwa);

                case "Sprzedaż biletów": return query.OrderBy(s => s.CzySprzedawacBilety);

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


        private IQueryable<StatusSeansu> ApplyFilter(IQueryable<StatusSeansu> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(s => s.Nazwa.Contains(FindTextBox));

                default: return query;
            }


        #endregion

        }
    }
}
