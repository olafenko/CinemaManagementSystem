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
    public class WszystkieSaleViewModel : WszystkieViewModel<SalaForAllView>
    {

        #region Konstruktor

        public WszystkieSaleViewModel()
        {
            base.DisplayName = "Sale";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<SalaForAllView>(
                kinoEntities.Sala.Select(s => new SalaForAllView
                {

                    Id = s.IdSali,
                    NumerSali = s.NumerSali,
                    LiczbaMiejsc = s.LiczbaMiejsc,
                    NazwaEkranu = s.TypEkranu.Nazwa,
                    RozdzielczoscEkranu = s.TypEkranu.MaksymalnaRozdzielczosc,
                    NazwaNaglosnienia = s.TypNaglosnienia.Nazwa,
                    TypSali = s.TypSali.Nazwa,
                    Uwagi = s.Uwagi,



                })
                );
        }

        #endregion

        #region Wlasciwosci

        private SalaForAllView _WybranaSala;
        public SalaForAllView WybranaSala
        {
            get
            {
                return _WybranaSala;
            }

            set
            {
                if (_WybranaSala != value)
                {
                    _WybranaSala = value;
                    Messenger.Default.Send(_WybranaSala);
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
                "Numer sali", "Liczba miejsc"
            };
        }

        public override void Sort()
        {

            switch (SortField)
            {
                case "Numer sali":
                    {
                        List = new ObservableCollection<SalaForAllView>(List.OrderBy(s => s.NumerSali));
                        break;
                    }

                case "Liczba miejsc":
                    {
                        List = new ObservableCollection<SalaForAllView>(List.OrderBy(s => s.LiczbaMiejsc));
                        break;
                    }



            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Ekran","Nagłośnienie","Typ sali"
            };
        }

        public override void Find()
        {
            if (String.IsNullOrWhiteSpace(FindTextBox))
            {
                Load();
            }

            else
            {
                switch (FindField)
                {
                    case "Ekran":
                        {
                            List = new ObservableCollection<SalaForAllView>(List.Where(s => s.NazwaEkranu.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Nagłośnienie":
                        {
                            List = new ObservableCollection<SalaForAllView>(List.Where(s => s.NazwaNaglosnienia.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Typ sali":
                        {
                            List = new ObservableCollection<SalaForAllView>(List.Where(s => s.TypSali.StartsWith(FindTextBox)));
                            break;
                        }
                  
                }

            }
        }


        #endregion
    }
}
