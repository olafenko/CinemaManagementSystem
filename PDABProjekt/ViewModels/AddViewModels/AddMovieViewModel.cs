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
    public class AddMovieViewModel : AddViewModelBase<Film>
    {


        #region Constructor

        public AddMovieViewModel()
        {
            base.DisplayName = "New Movie";
            item = new Film();

            LoadDictionaries();

            Messenger.Default.Register<DystrybutorForAllView>(this,GetSelectedDistributor);
        }
        #endregion

        #region Commands

        //te komende podpinamy pod przycisk ... w widoku i wywola ona okno wszystkich dystrybutorow
        private ICommand _ShowDistributors;

        public ICommand ShowDistributors
        {
            get
            {
                if (_ShowDistributors == null) _ShowDistributors = new BaseCommand(
                    () => Messenger.Default.Send("DystrybutorzyShow")// messengerem wysylamy komunikat do MainWindowViewModel ktory nakazuje otworzyc okno wszyskich dystrybutorow
                    );
                return _ShowDistributors;
            }
        }
        #endregion

        #region Properties

        public string Title
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
                    OnPropertyChanged(() => Title);
                }
            }
        }

        public string OriginalTitle
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
                    OnPropertyChanged(() => OriginalTitle);
                }
            }
        }

        public int DurationTime
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
                    OnPropertyChanged(() => DurationTime);
                }
            }
        }

        public int ProductionYear
        {
            get
            {
                return item.RokProdukcji;
            }

            set
            {
                if (item.RokProdukcji != value) { 
                
                    item.RokProdukcji = value;
                    OnPropertyChanged(() => ProductionYear);
                }
            }
        }


        public DateTime? PremiereDate
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
                    OnPropertyChanged(() => PremiereDate);
                }
            }
        }

        public string PosterUrl
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
                    OnPropertyChanged(() => PosterUrl);
                }
            }
        }

        public string Description
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
                    OnPropertyChanged(() => Description);
                }
            }
        }

        public int GenreId
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
                    OnPropertyChanged(() => GenreId);
                }
            }
        }

        public int AgeCategoryId
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
                    OnPropertyChanged(() => AgeCategoryId);
                }
            }
        }

        public int OriginalLanguageId
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
                    OnPropertyChanged(() => OriginalLanguageId);
                }
            }
        }

        public int DistributorId
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
                    OnPropertyChanged(() => DistributorId);
                }
            }
        }

        public int StatusId
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
                    OnPropertyChanged(() => StatusId);
                }
            }
        }

        public int ProducerId
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
                    OnPropertyChanged(() => ProducerId);
                }
            }
        }

        public int DirectorId
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
                    OnPropertyChanged(() => DirectorId);
                }
            }
        }

        public int CountryId
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
                    OnPropertyChanged(() => CountryId);
                }
            }
        }



        private string _DistributorName;

        public string DistributorName
        {
            get { return _DistributorName; }

            set
            {
                if (_DistributorName != value)
                {
                    _DistributorName = value;
                    OnPropertyChanged(() => DistributorName);
                }

            }
        }

        #endregion

        #region Dictionatries ComboBoxe's

        public List<KategoriaWiekowa> AgeCategories { get; private set; }
        public List<Jezyk> Languages { get; private set; }
        public List<StatusFilmu> MovieStatuses { get; private set; }
        public List<GatunekFilmu> Genres { get; private set; }
        public List<Kraj> Countries { get; private set; }
        public List<Rezyser> Directors { get; private set; }
        public List<Producent> Producers { get; private set; }
        
        #endregion

        

        #region Helpers

        public override void LoadDictionaries()
        {
            AgeCategories = kinoEntities.KategoriaWiekowa.Where(k => k.CzyAktywny).ToList();
            Languages = kinoEntities.Jezyk.Where(j => j.CzyAktywny).ToList();
            MovieStatuses = kinoEntities.StatusFilmu.Where(s => s.CzyAktywny).ToList();
            Genres = kinoEntities.GatunekFilmu.Where(g => g.CzyAktywny).ToList();
            Countries = kinoEntities.Kraj.Where(k => k.CzyAktywny).ToList();
            Directors = kinoEntities.Rezyser.Where(r => r.CzyAktywny).ToList();
            Producers = kinoEntities.Producent.Where(p => p.CzyAktywny).ToList();
        }

        public override void Save()
        {

            kinoEntities.Film.Add(item);
            kinoEntities.SaveChanges();
         
        }

        private void GetSelectedDistributor(DystrybutorForAllView selectedDistributor)
        {
            DistributorId = selectedDistributor.Id;
            DistributorName = selectedDistributor.Nazwa;
        }
        #endregion

    }
}
