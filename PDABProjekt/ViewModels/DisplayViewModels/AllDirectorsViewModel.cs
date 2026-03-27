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
    public class AllDirectorsViewModel : DisplayAllViewModelBase<RezyserForAllView>
    {

        #region Constructor

        public AllDirectorsViewModel()
        {
            base.DisplayName = "Reżyserzy";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<RezyserForAllView> query = kinoEntities.Rezyser.Where(r => r.CzyAktywny).Select(r => new RezyserForAllView
            { 

                ID = r.IdRezysera,
                Imie = r.Imie,
                Nazwisko = r.Nazwisko,
                Kraj = r.Kraj.Nazwa,

            }).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<RezyserForAllView>(query.ToList());


        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Kraj"
            };
        }

        private IQueryable<RezyserForAllView> ApplySort(IQueryable<RezyserForAllView> query)
        {

            switch (SortField)
            {
                case "Kraj": return query.OrderBy(p => p.Kraj);

                default: return query;

            }

        }

    

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Imie","Nazwisko"
            }; 
        }

        private IQueryable<RezyserForAllView> ApplyFilter(IQueryable<RezyserForAllView> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Imie": return query.Where(d => d.Imie.Contains(FindTextBox));

                case "Nazwisko": return query.Where(d => d.Nazwisko.Contains(FindTextBox));

                default: return query;
            }

        }
        #endregion
    }
}
