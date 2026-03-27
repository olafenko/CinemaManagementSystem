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
    public class AllLanguagesViewModel : DisplayAllViewModelBase<Jezyk>
    {

        #region Constructor

        public AllLanguagesViewModel()
        {
            base.DisplayName = "Jezyki";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<Jezyk> query = kinoEntities.Jezyk.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<Jezyk>(query.ToList());
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

        private IQueryable<Jezyk> ApplySort(IQueryable<Jezyk> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(j => j.Nazwa);

                default: return query;

            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa", "Kod ISO"
            };
        }

        private IQueryable<Jezyk> ApplyFilter(IQueryable<Jezyk> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(j => j.Nazwa.Contains(FindTextBox));

                case "Kod ISO": return query.Where(j => j.KodISO.Contains(FindTextBox));

                default: return query;
            }

        }


        #endregion

    }
}
