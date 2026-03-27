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
    public class AllScreenTypesViewModel : DisplayAllViewModelBase<TypEkranu>
    {

        #region Constructor

        public AllScreenTypesViewModel()
        {
            base.DisplayName = "Typy ekranu sali";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<TypEkranu> query = kinoEntities.TypEkranu.Where(t => t.CzyAktywny).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<TypEkranu>(query.ToList());
        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Maksymalna rozdzielczość","Wymagane okulary"
            };
        }

        private IQueryable<TypEkranu> ApplySort(IQueryable<TypEkranu> query)
        {

            switch (SortField)
            {
                case "Maksymalna rozdzielczość": return query.OrderBy(e => e.MaksymalnaRozdzielczosc);

                case "Wymagane okulary": return query.OrderBy(e => e.CzyWymaganeOkulary3D);

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

        private IQueryable<TypEkranu> ApplyFilter(IQueryable<TypEkranu> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Nazwa": return query.Where(t => t.Nazwa.Contains(FindTextBox));

                default: return query;
            }

        }

        #endregion

    }
}
