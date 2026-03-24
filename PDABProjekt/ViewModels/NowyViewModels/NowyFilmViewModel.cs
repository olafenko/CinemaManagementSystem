using GalaSoft.MvvmLight.Messaging;
using PDABProjekt.Helper;
using PDABProjekt.Models;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDABProjekt.ViewModels
{
    public class NowyFilmViewModel : JedenViewModel<Film>
    {


        #region Konstruktor

        public NowyFilmViewModel()
        {
            base.DisplayName = "Film";
            item = new Film();

            //to jest messenger ktory lapie dystrybutora ktory zostal wyslany z okna wyswietlajacego wszystkich dystrybutorow
            Messenger.Default.Register<DystrybutorForAllView>(this,getWybranyDystrybutor); // jak go zlapie to wywola funkcje getWybranyDystrybutor
        }
        #endregion

        #region Commands

        //te komende podpinamy pod przycisk ... w widoku i wywola ona okno wszystkich dystrybutorow
        private BaseCommand _ShowDystrybutorzy;

        public ICommand ShowDystrybutorzy
        {
            get
            {
                if (_ShowDystrybutorzy == null) _ShowDystrybutorzy = new BaseCommand(
                    () => Messenger.Default.Send("DystrybutorzyShow")// messengerem wysylamy komunikat do MainWindowViewModel ktory nakazuje otworzyc okno wszyskich dystrybutorow
                    );
                return _ShowDystrybutorzy;
            }
        }
        #endregion

        #region Wlasciwosci

        public string Tytul
        {
            get
            {
                return item.Tytul;
            }

            set
            {
                if (item.Tytul != value)
                {
                    item.Tytul = value;
                    OnPropertyChanged(() => item.Tytul);
                }
            }
        }

        public string TytulOryginalny
        {
            get
            {
                return item.TytulOryginalny;
            }

            set
            {
                if (item.TytulOryginalny != value)
                {
                    item.TytulOryginalny = value;
                    OnPropertyChanged(() => item.TytulOryginalny);
                }
            }
        }

        public int CzasTrwania
        {
            get
            {
                return item.CzasTrwania;
            }

            set
            {
                if (item.CzasTrwania != value)
                {
                    item.CzasTrwania = value;
                    OnPropertyChanged(() => item.CzasTrwania);
                }
            }
        }

        public int IdGatunku
        {
            get
            {
                return item.IdGatunku;
            }

            set
            {
                if (item.IdGatunku != value)
                {
                    item.IdGatunku = value;
                    OnPropertyChanged(() => item.IdGatunku);
                }
            }
        }

        public int RokProdukcji
        {
            get
            {
                return item.RokProdukcji;
            }

            set
            {
                if (item.RokProdukcji != value) { 
                
                    item.RokProdukcji = value;
                    OnPropertyChanged(() => item.RokProdukcji);
                }
            }
        }


        public DateTime? DataPremiery
        {
            get
            {
                return item.DataPremiery;
            }

            set
            {
                if (item.DataPremiery != value)
                {
                    item.DataPremiery = value;
                    OnPropertyChanged(() => item.DataPremiery);
                }
            }
        }

        public int IdKategoriiWiekowej
        {
            get
            {
                return item.IdKategoriiWiekowej;
            }

            set
            {
                if (item.IdKategoriiWiekowej != value)
                {
                    item.IdKategoriiWiekowej = value;
                    OnPropertyChanged(() => item.IdKategoriiWiekowej);
                }
            }
        }

        public int IdJezykaOryginalnego
        {
            get
            {
                return item.IdJezykaOryginalnego;
            }

            set
            {
                if (item.IdJezykaOryginalnego != value)
                {
                    item.IdJezykaOryginalnego = value;
                    OnPropertyChanged(() => item.IdJezykaOryginalnego);
                }
            }
        }

        public int IdDystrybutora
        {
            get
            {
                return item.IdDystrybutora;
            }

            set
            {
                if (item.IdDystrybutora != value)
                {
                    item.IdDystrybutora = value;
                    OnPropertyChanged(() => item.IdDystrybutora);
                }
            }
        }

        private string _NazwaDystrybutora;

        public string NazwaDystrybutora
        {
            get { return _NazwaDystrybutora; }

            set {
                if(_NazwaDystrybutora != value)
                {
                    _NazwaDystrybutora = value;
                    OnPropertyChanged(() => NazwaDystrybutora);
                }
                
                 }
        }


        public int IdStatusu
        {
            get
            {
                return item.IdStatusuFilmu;
            }

            set
            {
                if (item.IdStatusuFilmu != value)
                {
                    item.IdStatusuFilmu = value;
                    OnPropertyChanged(() => item.IdStatusuFilmu);
                }
            }
        }

        public int IdProducenta
        {
            get
            {
                return item.IdProducenta;
            }

            set
            {
                if (item.IdProducenta != value)
                {
                    item.IdProducenta = value;
                    OnPropertyChanged(() => item.IdProducenta);
                }
            }
        }

        public int IdRezysera
        {
            get
            {
                return item.IdRezysera;
            }

            set
            {
                if (item.IdRezysera != value)
                {
                    item.IdRezysera = value;
                    OnPropertyChanged(() => item.IdRezysera);
                }
            }
        }

        public int IdKraju
        {
            get
            {
                return item.IdKraju;
            }

            set
            {
                if (item.IdKraju != value)
                {
                    item.IdKraju = value;
                    OnPropertyChanged(() => item.IdKraju);
                }
            }
        }



        public string UrlPlakatu
        {
            get
            {
                return item.UrlPlakatu;
            }

            set
            {
                if (item.UrlPlakatu != value)
                {
                    item.UrlPlakatu = value;
                    OnPropertyChanged(() => item.UrlPlakatu);
                }
            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }

            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => item.Opis);
                }
            }
        }

        //comboboxy
        public IQueryable<KategoriaWiekowa> KategorieWiekoweItems
        {
            get
            {
                return (
                    kinoEntities.KategoriaWiekowa.Where(k => k.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }

        public IQueryable<Jezyk> JezykiItems
        {
            get
            {
                return (
                    kinoEntities.Jezyk.Where(j => j.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }

        public IQueryable<StatusFilmu> StatusyFilmuItems
        {
            get
            {
                return (
                    kinoEntities.StatusFilmu.Where(s => s.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }

        public IQueryable<GatunekFilmu> GatunkiFilmuItems
        {
            get
            {
                return (
                    kinoEntities.GatunekFilmu.Where(g => g.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }

        public IQueryable<Kraj> KrajeProdukcjiItems
        {
            get
            {
                return (
                    kinoEntities.Kraj.Where(k => k.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }

        public IQueryable<Producent> ProducenciItems
        {
            get
            {
                return (
                    kinoEntities.Producent.Where(p => p.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }

        public IQueryable<Rezyser> RezyserzyItems
        {
            get
            {
                return (
                    kinoEntities.Rezyser.Where(r => r.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }



        #endregion

        #region Helpers

        public override void Save()
        {

            kinoEntities.Film.Add(item);
            kinoEntities.SaveChanges();
         
        }

        private void getWybranyDystrybutor(DystrybutorForAllView dystrybutor)
        {
            IdDystrybutora = dystrybutor.Id;
            NazwaDystrybutora = dystrybutor.Nazwa;
        }
        #endregion

    }
}
