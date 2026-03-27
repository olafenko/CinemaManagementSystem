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
using System.Windows.Documents;

namespace PDABProjekt.ViewModels
{
    public class AllProducersViewModel : DisplayAllViewModelBase<ProducentForAllView>
    {

        #region Constructor

        public AllProducersViewModel()
        {
            base.DisplayName = "Producenci";
        }

        #endregion

        #region List
        public override void Load()
        {

            IQueryable<ProducentForAllView> query = kinoEntities.Producent.Where(p => p.CzyAktywny).Select(p => new ProducentForAllView
            {

                ID = p.IdProducenta,
                Nazwa = p.Nazwa,
                Kraj = p.Kraj.Nazwa,
                Opis = p.Opis

            }).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<ProducentForAllView>(query.ToList());
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

        private IQueryable<ProducentForAllView> ApplySort(IQueryable<ProducentForAllView> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(p => p.Nazwa);

                default: return query;

            }

        }


        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Kraj"
            };
        }

        private IQueryable<ProducentForAllView> ApplyFilter(IQueryable<ProducentForAllView> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Kraj": return query.Where(k => k.Kraj.Contains(FindTextBox));

                default: return query;
            }

        }

        #endregion

    }
}
