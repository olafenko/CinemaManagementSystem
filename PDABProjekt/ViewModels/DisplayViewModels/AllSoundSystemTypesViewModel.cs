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
    public class AllSoundSystemTypesViewModel : DisplayAllViewModelBase<TypNaglosnienia>
    {

        #region Constructor

        public AllSoundSystemTypesViewModel()
        {
            base.DisplayName = "Typy naglosnienia sali";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<TypNaglosnienia> query = kinoEntities.TypNaglosnienia.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<TypNaglosnienia>(query.ToList());
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

        private IQueryable<TypNaglosnienia> ApplySort(IQueryable<TypNaglosnienia> query)
        {

            switch (SortField)
            {
                case "Nazwa": return query.OrderBy(n => n.Nazwa);
      
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

        private IQueryable<TypNaglosnienia> ApplyFilter(IQueryable<TypNaglosnienia> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(n => n.Nazwa.Contains(FindTextBox));

                default: return query;
            }

        }


        #endregion

    }
}
