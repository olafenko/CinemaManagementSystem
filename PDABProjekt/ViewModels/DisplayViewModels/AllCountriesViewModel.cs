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
    public class AllCountriesViewModel : DisplayAllViewModelBase<Kraj>
    {

        #region Constructor

        public AllCountriesViewModel()
        {
            base.DisplayName = "Kraje";
        }

        #endregion

        #region List
        public override void Load()
        {

            IQueryable<Kraj> query = kinoEntities.Kraj.AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);


            List = new ObservableCollection<Kraj>(query.ToList());
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

        private IQueryable<Kraj> ApplySort(IQueryable<Kraj> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(k => k.Nazwa);

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

        private IQueryable<Kraj> ApplyFilter(IQueryable<Kraj> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(k => k.Nazwa.Contains(FindTextBox));

                default: return query;
            }

        }


        #endregion

    }
}
