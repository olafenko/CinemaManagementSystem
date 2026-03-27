using GalaSoft.MvvmLight.Messaging;
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

namespace PDABProjekt.ViewModels
{
    public class AllHallsViewModel : DisplayAllViewModelBase<SalaForAllView>
    {

        #region Constructor

        public AllHallsViewModel()
        {
            base.DisplayName = "Sale";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<SalaForAllView> query = kinoEntities.Sala.Select(s => new SalaForAllView
            {

                Id = s.IdSali,
                NumerSali = s.NumerSali,
                LiczbaMiejsc = s.LiczbaMiejsc,
                NazwaEkranu = s.TypEkranu.Nazwa,
                RozdzielczoscEkranu = s.TypEkranu.MaksymalnaRozdzielczosc,
                NazwaNaglosnienia = s.TypNaglosnienia.Nazwa,
                TypSali = s.TypSali.Nazwa,
                Uwagi = s.Uwagi,



            }).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);


            List = new ObservableCollection<SalaForAllView>(query.ToList());
        }

        #endregion

        #region Properties

        private SalaForAllView _PickedHall;
        public SalaForAllView PickedHall
        {
            get
            {
                return _PickedHall;
            }

            set
            {
                if (_PickedHall != value)
                {
                    _PickedHall = value;
                    Messenger.Default.Send(_PickedHall);
                    OnRequestClose();
                }
            }

        }

        #endregion


        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Numer sali", "Liczba miejsc"
            };
        }

        private IQueryable<SalaForAllView> ApplySort(IQueryable<SalaForAllView> query)
        {

            switch (SortField)
            {
                case "Numer sali": return query.OrderBy(s => s.NumerSali);

                case "Liczba miejsc": return query.OrderBy(s => s.LiczbaMiejsc);

                default: return query;

            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Ekran","Nagłośnienie","Typ sali"
            };
        }


        private IQueryable<SalaForAllView> ApplyFilter(IQueryable<SalaForAllView> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Ekran": return query.Where(s => s.NazwaEkranu.Contains(FindTextBox));

                case "Nagłośnienie": return query.Where(s => s.NazwaNaglosnienia.Contains(FindTextBox));

                case "Typ sali": return query.Where(s => s.TypSali.Contains(FindTextBox));

                default: return query;
            }

        }

        #endregion
    }
}
