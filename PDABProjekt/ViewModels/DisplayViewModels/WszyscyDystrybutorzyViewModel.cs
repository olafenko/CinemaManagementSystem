using GalaSoft.MvvmLight.Messaging;
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
    public class WszyscyDystrybutorzyViewModel : WszystkieViewModel<DystrybutorForAllView>
    {
        #region Konstruktor

        public WszyscyDystrybutorzyViewModel()
        {
            base.DisplayName = "Dystrybutorzy";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<DystrybutorForAllView>(
                
                kinoEntities.Dystrybutor.Where(d => d.CzyAktywny).Select(d => new DystrybutorForAllView
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
                  
                })


                );
        }

        #endregion

        #region Wlasciwosci

        private DystrybutorForAllView _WybranyDystrybutor;
        public DystrybutorForAllView WybranyDystrybutor
        {
            get
            {
                return _WybranyDystrybutor;
            }

            set // gdy ustawiony zostanie wybrany dystrybutor to zamyka okno
            {
                if(_WybranyDystrybutor != value)
                {
                    _WybranyDystrybutor = value;
                    Messenger.Default.Send(_WybranyDystrybutor); // za pomocą messengera wysylamy wybranego dystrybutora do okna z nowym filmem
                    OnRequestClose();
                }
            }

        }

        #endregion


        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Procent prowizji", "Zakończenie umowy"
            };
        }

        public override void Sort()
        {
           

            switch (SortField)
            {
                case "Procent prowizji":
                    {
                        List = new ObservableCollection<DystrybutorForAllView>(List.OrderBy(d => d.ProcentProwizji));
                        break;
                    }

                case "Zakończenie umowy":
                    {
                        List = new ObservableCollection<DystrybutorForAllView>(List.OrderBy(d => d.UmowaDo));
                        break;
                    }



            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa","Kraj","Numer umowy"
            };
        }

        public override void Find()
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) {
                Load();
            }

            else
            {
                switch (FindField)
                {
                    case "Nazwa":
                        {
                            List = new ObservableCollection<DystrybutorForAllView>(List.Where(d => d.Nazwa.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Kraj":
                        {
                            List = new ObservableCollection<DystrybutorForAllView>(List.Where(d => d.NazwaKraju.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Numer umowy":
                        {
                            List = new ObservableCollection<DystrybutorForAllView>(List.Where(d => d.NumerUmowy.StartsWith(FindTextBox)));
                            break;
                        }

                }

                
            }

                

        }


        #endregion
    }
}
