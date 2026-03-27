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
    public class AllMoviesViewModel : DisplayAllViewModelBase<FilmForAllView>
    {

        #region Constructor

        public AllMoviesViewModel()
        {
            base.DisplayName = "Filmy";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<FilmForAllView> query = kinoEntities.Film.Where(film => film.CzyAktywny)
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
                ).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);

            List = new ObservableCollection<FilmForAllView>(query.ToList());


        }

        #endregion

        #region Properties

        private FilmForAllView _PickedMovie;
        public FilmForAllView PickedMovie
        {
            get
            {
                return _PickedMovie;
            }

            set 
            {
                if (_PickedMovie != value)
                {
                    _PickedMovie = value;
                    Messenger.Default.Send(_PickedMovie);
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
                "Czas trwania","Rok produkcji","Kategoria wiekowa","Status"
            };
        }

        private IQueryable<FilmForAllView> ApplySort(IQueryable<FilmForAllView> query)
        {

            switch (SortField)
            {
                case "Czas trwania": return query.OrderBy(f => f.CzasTrwania);

                case "Rok produkcji": return query.OrderBy(f => f.RokProdukcji);

                case "Status": return query.OrderBy(f => f.Status);

                case "Kategoria wiekowa": return query.OrderBy(f => f.KategoriaWiekowa);

                default: return query;

            }

        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Tytuł","Gatunek","Kategoria wiekowa","Rok produkcji","Język","Kraj produkcji","Producent","Reżyser"
            };
        }


        private IQueryable<FilmForAllView> ApplyFilter(IQueryable<FilmForAllView> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Tytuł": return query.Where(f => f.Tytul != null && f.Tytul.Contains(FindTextBox));

                case "Gatunek": return query.Where(f => f.NazwaGatunku != null && f.NazwaGatunku.Contains(FindTextBox));

                case "Kategoria wiekowa": return query.Where(f => f.KategoriaWiekowa != null && f.KategoriaWiekowa.Contains(FindTextBox));

                case "Rok produkcji":
                    {
                        if (int.TryParse(FindTextBox, out int searchedYear))
                        {
                            return query.Where(f => f.RokProdukcji != null && f.RokProdukcji == searchedYear);
                        }
                        else
                        {
                            return query;
                        }
                    
                    }
                   

                case "Język": return query.Where(f => f.JezykOryginalny != null && f.JezykOryginalny.Contains(FindTextBox));

                case "Kraj produkcji": return query.Where(f => f.KrajProdukcji != null && f.KrajProdukcji.Contains(FindTextBox));

                case "Producent": return query.Where(f => f.NazwaProducenta != null && f.NazwaProducenta.Contains(FindTextBox));

                case "Reżyser": return query.Where(f => f.NazwaRezysera != null && f.NazwaRezysera.Contains(FindTextBox));


                default: return query;
            }

        }

        #endregion




    }
}
