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
    public class AllAgeCategoriesViewModel : DisplayAllViewModelBase<KategoriaWiekowa>
    {


        #region Constructor

        public AllAgeCategoriesViewModel()
        {
            base.DisplayName = "Kategorie wiekowe";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable <KategoriaWiekowa> query = kinoEntities.KategoriaWiekowa;


            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<KategoriaWiekowa>(query.ToList());

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

        private IQueryable<KategoriaWiekowa> ApplySort(IQueryable<KategoriaWiekowa> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(k => k.NazwaKategorii);

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

        private IQueryable<KategoriaWiekowa> ApplyFilter(IQueryable<KategoriaWiekowa> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(k => k.NazwaKategorii.Contains(FindTextBox));

                default: return query;
            }

        }


        #endregion

    }
}
