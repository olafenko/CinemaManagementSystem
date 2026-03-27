using GalaSoft.MvvmLight.Messaging;
using PDABProjekt.Models;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PDABProjekt.ViewModels
{
    public class AllDistributorsViewModel : DisplayAllViewModelBase<DystrybutorForAllView>
    {
        #region Constructor

        public AllDistributorsViewModel()
        {
            base.DisplayName = "Dystrybutorzy";
        }

        #endregion

        #region List
        public override void Load()
        {

            IQueryable<DystrybutorForAllView> query = kinoEntities.Dystrybutor.Where(d => d.CzyAktywny).Select(d => new DystrybutorForAllView
            {

                Id = d.IdDystrybutora,
                Nazwa = d.Nazwa,
                NazwaKraju = d.Kraj.Nazwa,
                Email = d.Email,
                Telefon = d.TelefonKontaktowy,
                ProcentProwizji = d.ProcentProwizji,
                ModelRozliczen = d.ModelRozliczen,
                CzyUmowaPodpisana = d.CzyUmowaPodpisana,
                NumerUmowy = d.NumerUmowy,
                UmowaOd = d.UmowaOd,
                UmowaDo = d.UmowaDo

            }).AsQueryable();

     
            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<DystrybutorForAllView>(query.ToList());
        }

        #endregion

        #region Properties

        private DystrybutorForAllView _PickedDistributor;
        public DystrybutorForAllView PickedDistributor
        {
            get
            {
                return _PickedDistributor;
            }

            set 
            {
                if(_PickedDistributor != value)
                {
                    _PickedDistributor = value;
                    Messenger.Default.Send(_PickedDistributor);
                    OnRequestClose();
                }
            }

        }

        #endregion


        #region Sorting and filtering

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Procent prowizji", "Zakończenie umowy"
            };
        }

        private IQueryable<DystrybutorForAllView> ApplySort(IQueryable<DystrybutorForAllView> query)
        {

            switch (SortField)
            {
                case "Procent prowizji": return query.OrderBy(d => d.ProcentProwizji);

                case "Zakończenie umowy": return query.OrderBy(d => d.UmowaDo);

                default: return query;

            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa","Kraj","Numer umowy"
            };
        }



        private IQueryable<DystrybutorForAllView> ApplyFilter(IQueryable<DystrybutorForAllView> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;

     
                switch (FindField)
                {
                    case "Nazwa": return query.Where(d => d.Nazwa.StartsWith(FindTextBox));

                    case "Kraj": return query.Where(d => d.NazwaKraju.StartsWith(FindTextBox));

                    case "Numer umowy": return query.Where(d => d.NumerUmowy.StartsWith(FindTextBox));

                    default: return query;
                }

        }


        #endregion
    }
}
