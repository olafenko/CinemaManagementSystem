using PDABProjekt.Helper;
using PDABProjekt.Models;
using PDABProjekt.Models.BusinessLogic;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDABProjekt.ViewModels
{
    public class StatystykiOgolneViewModel : RaportViewModelBase
    {

        #region Baza danych

        private readonly PABProjektEntities kinoEntities;

        #endregion

        #region Konstruktor

        public StatystykiOgolneViewModel()
        {
            base.DisplayName = "Statystyki dzienne";
            kinoEntities = new PABProjektEntities();
            Data = DateTime.Now.Date;
            SprzedaneBilety = 0;
            Utarg = 0;
            NajpopularniejszyFilm = "brak";
            NajpopularniejszySeans = "brak";
            SrednieWypelnienieSali = 0;
            LiczbaSeansow = 0;
        }

        #endregion


        #region Pola i wlasciwosci

        private DateTime _Data;

        public DateTime Data
        {
            get { return _Data; }

            set
            {
                if (value != _Data)
                {
                    _Data = value;
                    OnPropertyChanged(() => Data);
                }
            }
        }


        private int? _SprzedaneBilety;

        public int? SprzedaneBilety
        {
            get { return _SprzedaneBilety; }

            set
            {
                if (value != _SprzedaneBilety)
                {
                    _SprzedaneBilety = value;
                    OnPropertyChanged(() => SprzedaneBilety);
                }
            }
        }

        private decimal? _Utarg;

        public decimal? Utarg
        {
            get { return _Utarg; }

            set
            {
                if (value != _Utarg)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg);
                }
            }
        }

        private string _NajpopularniejszySeans;

        public string NajpopularniejszySeans
        {
            get { return _NajpopularniejszySeans; }

            set
            {
                if (value != _NajpopularniejszySeans)
                {
                    _NajpopularniejszySeans = value;
                    OnPropertyChanged(() => NajpopularniejszySeans);
                }
            }
        }

        private string _NajpopularniejszyFilm;

        public string NajpopularniejszyFilm
        {
            get { return _NajpopularniejszyFilm; }

            set
            {
                if (value != _NajpopularniejszyFilm)
                {
                    _NajpopularniejszyFilm = value;
                    OnPropertyChanged(() => NajpopularniejszyFilm);
                }
            }
        }

        private decimal? _SrednieWypelnienieSali;

        public decimal? SrednieWypelnienieSali
        {
            get { return _SrednieWypelnienieSali; }

            set
            {
                if (value != _SrednieWypelnienieSali)
                {
                    _SrednieWypelnienieSali = value;
                    OnPropertyChanged(() => SrednieWypelnienieSali);
                }
            }
        }

        private int? _LiczbaSeansow;

        public int? LiczbaSeansow
        {
            get { return _LiczbaSeansow; }

            set
            {
                if (value != _LiczbaSeansow)
                {
                    _LiczbaSeansow = value;
                    OnPropertyChanged(() => LiczbaSeansow);
                }
            }
        }



        #endregion

        #region Komendy       

        public override void obliczRaportClick()
        {

            var statystykiB = new StatystykiOgolneB(kinoEntities).GenerujStatystykiOgolne(Data);

            SprzedaneBilety = statystykiB.SprzedaneBilety;
            Utarg = statystykiB.Utarg;
            NajpopularniejszySeans = statystykiB.NajpopularniejszySeans;
            NajpopularniejszyFilm = statystykiB.NajpopularniejszyFilm;
            SrednieWypelnienieSali = statystykiB.SrednieWypelnienieSali;
            LiczbaSeansow = statystykiB.LiczbaSeansow;


        }


        public override void eksportujRaportClick()
        {
            new StatystykiOgolneB(kinoEntities).EksportujRaportDoCsv(Data);
        }



        #endregion


    }
}
