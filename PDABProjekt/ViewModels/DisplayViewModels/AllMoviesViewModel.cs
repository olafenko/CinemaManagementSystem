using GalaSoft.MvvmLight.Messaging;
using PDABProjekt.Models;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PDABProjekt.ViewModels
{
    public class AllMoviesViewModel : WszystkieViewModel<FilmForAllView>
    {

        #region Constructor

        public AllMoviesViewModel()
        {
            base.DisplayName = "Filmy";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<FilmForAllView>(

                kinoEntities.Film.Where(film => film.CzyAktywny == true)
                .Select(film => new FilmForAllView
                {
                    Id = film.IdFilmu,
                    Tytul = film.Tytul,
                    TytulOryginalny = film.TytulOryginalny,
                    NazwaGatunku = film.GatunekFilmu.NazwaGatunku,
                    JezykOryginalny = film.Jezyk.Nazwa,
                    KategoriaWiekowa = film.KategoriaWiekowa.NazwaKategorii,
                    CzasTrwania = film.CzasTrwania,
                    NazwaDystrybutora = film.Dystrybutor.Nazwa,
                    DataPremiery = film.DataPremiery,
                    RokProdukcji = film.RokProdukcji,
                    KrajProdukcji = film.Kraj.Nazwa,
                    NazwaProducenta = film.Producent.Nazwa,
                    NazwaRezysera = film.Rezyser.Imie + " " + film.Rezyser.Nazwisko,
                    Status = film.StatusFilmu.NazwaStatusu,
                    UrlPlakatu = film.UrlPlakatu,
                    Opis = film.Opis

                }
                ).ToList()
            );
        }

        #endregion

        #region Wlasciwosci

        private FilmForAllView _WybranyFilm;
        public FilmForAllView WybranyFilm
        {
            get
            {
                return _WybranyFilm;
            }

            set 
            {
                if (_WybranyFilm != value)
                {
                    _WybranyFilm = value;
                    Messenger.Default.Send(_WybranyFilm);
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
                "Czas trwania","Rok produkcji","Kategoria wiekowa","Status"
            };
        }

        public override void Sort()
        {          

            switch (SortField)
            {
                case "Czas trwania" :
                    {
                        List = new ObservableCollection<FilmForAllView>(List.OrderBy(f => f.CzasTrwania));
                        break;
                    }
                case "Rok produkcji":
                    {
                        List = new ObservableCollection<FilmForAllView>(List.OrderBy(f => f.RokProdukcji));
                        break;
                    }
                case "Status":
                    {
                        List = new ObservableCollection<FilmForAllView>(List.OrderBy(f => f.Status));
                        break;
                    }
            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Tytuł","Gatunek","Kategoria wiekowa","Rok produkcji","Język","Kraj produkcji","Producent","Reżyser"
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

                    case "Tytuł":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.Tytul != null && f.Tytul.StartsWith(FindTextBox)));
                            break;
                        }
                    case "Gatunek":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.NazwaGatunku != null && f.NazwaGatunku.IndexOf(FindTextBox, StringComparison.OrdinalIgnoreCase) != -1));
                            break;
                        }
                    case "Kategoria wiekowa":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.KategoriaWiekowa != null && f.KategoriaWiekowa.StartsWith(FindTextBox)));
                            break;
                        }
                    case "Rok produkcji":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.RokProdukcji != null && f.RokProdukcji == int.Parse(FindTextBox)));
                            break;
                        }
                    case "Język":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.JezykOryginalny != null && f.JezykOryginalny.StartsWith(FindTextBox)));
                            break;
                        }
                    case "Kraj produkcji":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.KrajProdukcji != null && f.KrajProdukcji.IndexOf(FindTextBox, StringComparison.OrdinalIgnoreCase) != -1));
                            break;
                        }
                    case "Producent":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.NazwaProducenta != null && f.NazwaProducenta.IndexOf(FindTextBox, StringComparison.OrdinalIgnoreCase) != -1));
                            break;
                        }
                    case "Reżyser":
                        {
                            List = new ObservableCollection<FilmForAllView>(List.Where(f => f.NazwaRezysera != null && f.NazwaRezysera.IndexOf(FindTextBox, StringComparison.OrdinalIgnoreCase) != -1));
                            break;
                        }

                }

               
            }
        }


        #endregion




    }
}
