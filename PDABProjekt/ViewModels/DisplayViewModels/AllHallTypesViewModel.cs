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
    public class AllHallTypesViewModel : DisplayAllViewModelBase<TypSali>
    {
        #region Constructor

        public AllHallTypesViewModel()
        {
            base.DisplayName = "Typy sali";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<TypSali> query = kinoEntities.TypSali.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<TypSali>(query.ToList());
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

        private IQueryable<TypSali> ApplySort(IQueryable<TypSali> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(s => s.Nazwa);

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

        private IQueryable<TypSali> ApplyFilter(IQueryable<TypSali> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(s => s.Nazwa.Contains(FindTextBox));

                default: return query;
            }

        }

        #endregion

    }
}
