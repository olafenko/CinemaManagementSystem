using GalaSoft.MvvmLight.Messaging;
using PDABProjekt.Helper;
using PDABProjekt.Models;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using PDABProjekt.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDABProjekt.ViewModels
{
    public class AddScreeningViewModel : AddViewModelBase<Seans>
    {

        #region Constructor
        public AddScreeningViewModel()
        {
            base.DisplayName = "Seans";
            item = new Seans();
            item.DataSeansu = DateTime.Now;

            LoadDictionaries();

            Messenger.Default.Register<FilmForAllView>(this, GetSelectedMovie);
            Messenger.Default.Register<SalaForAllView>(this, GetSelectedHall);
        }
        #endregion


        #region Commands
        
        private BaseCommand _ShowMovies;

        public ICommand ShowMovies
        {
            get
            {
                if (_ShowMovies == null) _ShowMovies = new BaseCommand(
                    () => Messenger.Default.Send("FilmyShow")
                    );
                return _ShowMovies;
            }
        }

        private BaseCommand _ShowHalls;

        public ICommand ShowHalls
        {
            get
            {
                if (_ShowHalls == null) _ShowHalls = new BaseCommand(
                    () => Messenger.Default.Send("SaleShow")
                    );
                return _ShowHalls;
            }
        }

        #endregion

        #region Properties

        public int MovieId
        {
            get
            {
                return item.IdFilmu;
            }

            set
            {
                if (item.IdFilmu != value)
                {
                    item.IdFilmu = value;
                    OnPropertyChanged(() => MovieId);
                }
            }
        }

        private string _MovieTitle;

        public string MovieTitle
        {
            get { return _MovieTitle; }

            set
            {
                if (_MovieTitle != value)
                {
                    _MovieTitle = value;
                    OnPropertyChanged(() => MovieTitle);
                }

            }
        }

        private string _MovieGenre;

        public string MovieGenre
        {
            get { return _MovieGenre; }

            set
            {
                if (_MovieGenre != value)
                {
                    _MovieGenre = value;
                    OnPropertyChanged(() => MovieGenre);
                }

            }
        }

        private int _MovieDuration;

        public int MovieDuration
        {
            get { return _MovieDuration; }

            set
            {
                if (_MovieDuration != value)
                {
                    _MovieDuration = value;
                    
                    OnPropertyChanged(() => MovieDuration);
                    EndTimeFromUI = StartTimeFromUI.AddMinutes(MovieDuration);
                }

            }
        }

        public int HallId
        {
            get
            {
                return item.IdSali;
            }

            set
            {
                if (item.IdSali != value)
                {
                    item.IdSali = value;
                    OnPropertyChanged(() => HallId);
                }
            }
        }

        private int _HallNumber;

        public int HallNumber
        {
            get { return _HallNumber; }

            set
            {
                if (_HallNumber != value)
                {
                    _HallNumber = value;
                    OnPropertyChanged(() => HallNumber);
                }

            }
        }

        private string _HallType;

        public string HallType
        {
            get { return _HallType; }

            set
            {
                if (_HallType != value)
                {
                    _HallType = value;
                    OnPropertyChanged(() => HallType);
                }

            }
        }

        public int ScreeningStatusId
        {
            get
            {
                return item.IdStatusuSeansu;
            }

            set
            {
                if (item.IdStatusuSeansu != value)
                {
                    item.IdStatusuSeansu = value;
                    OnPropertyChanged(() => ScreeningStatusId);
                }
            }
        }

        public int LanguageId
        {
            get
            {
                return item.IdJezyka;
            }

            set
            {
                if (item.IdJezyka != value)
                {
                    item.IdJezyka = value;
                    OnPropertyChanged(() => LanguageId);
                }
            }
        }

        public DateTime ScreeningDate
        {
            get
            {
                return item.DataSeansu;
            }

            set
            {
                if (item.DataSeansu != value)
                {
                    item.DataSeansu = value;
                    OnPropertyChanged(() => ScreeningDate);
                }
            }
        }

        private DateTime _StartTimeFromUI;
        public DateTime StartTimeFromUI {
            get { return _StartTimeFromUI; }
            set {
                if (_StartTimeFromUI != value)
                {
                    _StartTimeFromUI = value;
                   
                    OnPropertyChanged(() => StartTimeFromUI);

                    EndTimeFromUI = StartTimeFromUI.AddMinutes(MovieDuration);
                }
            }
        }

        private DateTime _EndTimeFromUI;
        public DateTime EndTimeFromUI
        {
            get { return _EndTimeFromUI; }
            set
            {
                if (_EndTimeFromUI != value)
                {
                    _EndTimeFromUI = value;
                   
                    OnPropertyChanged(() => EndTimeFromUI);
                }
            }
        }

        public TimeSpan StartTime
        {
            get
            {
                return item.GodzinaOd;
            }

            set
            {
                if (item.GodzinaOd != value)
                {
                    item.GodzinaOd = value;
                    OnPropertyChanged(() => StartTime);
                }
            }
        }

        public TimeSpan EndTime
        {
            get
            {
                return item.GodzinaDo;
            }

            set
            {
                if (item.GodzinaDo != value)
                {
                    item.GodzinaDo = value;
                    OnPropertyChanged(() => EndTime);
                }
            }
        }

        public bool Lector
        {
            get
            {
                return item.CzyLektor;
            }

            set
            {
                if (item.CzyLektor != value)
                {
                    item.CzyLektor = value;
                    OnPropertyChanged(() => Lector);
                }
            }
        }

        public bool Subtitles
        {
            get
            {
                return item.CzyNapisy;
            }

            set
            {
                if (item.CzyNapisy != value)
                {
                    item.CzyNapisy = value;
                    OnPropertyChanged(() => Subtitles);
                }
            }
        }

        public bool Dubbing
        {
            get
            {
                return item.CzyDubbing;
            }

            set
            {
                if (item.CzyDubbing != value)
                {
                    item.CzyDubbing = value;
                    OnPropertyChanged(() => Dubbing);
                }
            }
        }


        #endregion

        #region Dictionaries ComboBoxe's


        public List<StatusSeansu> ScreeningStatuses { get; set; }
        public List<Jezyk> Languages { get; set; }


        #endregion


        #region Helpers

        public override void LoadDictionaries()
        {
            ScreeningStatuses = kinoEntities.StatusSeansu.Where(s => s.CzyAktywny).ToList();
            Languages = kinoEntities.Jezyk.Where(j => j.CzyAktywny).ToList();
        }

        public override void Save()
        {

            item.GodzinaOd = StartTimeFromUI.TimeOfDay;
            item.GodzinaDo = EndTimeFromUI.TimeOfDay;
            kinoEntities.Seans.Add(item);
            kinoEntities.SaveChanges();

        }

        private void GetSelectedMovie(FilmForAllView movie)
        {
            MovieId = movie.Id;
            MovieTitle = movie.Tytul;
            MovieGenre = movie.NazwaGatunku;
            MovieDuration = movie.CzasTrwania;

        }

        private void GetSelectedHall(SalaForAllView hall)
        {
            HallId = hall.Id;
            HallNumber = hall.NumerSali;
            HallType = hall.TypSali;

        }

        #endregion


    }




}
