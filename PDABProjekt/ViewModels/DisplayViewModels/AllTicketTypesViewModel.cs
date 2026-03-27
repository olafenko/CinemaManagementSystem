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
    public class AllTicketTypesViewModel : DisplayAllViewModelBase<TypBiletu>
    {
        #region Constructor

        public AllTicketTypesViewModel()
        {
            base.DisplayName = "Typy biletów";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<TypBiletu> query = kinoEntities.TypBiletu.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<TypBiletu>(query.ToList());
        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Cena bazowa"
            };
        }

        private IQueryable<TypBiletu> ApplySort(IQueryable<TypBiletu> query)
        {

            switch (SortField)
            {
                case "Cena bazowa": return query.OrderBy(b => b.Cena);

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

        private IQueryable<TypBiletu> ApplyFilter(IQueryable<TypBiletu> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(b => b.Nazwa.Contains(FindTextBox));

                default: return query;
            }

        }



        #endregion

    }
}
