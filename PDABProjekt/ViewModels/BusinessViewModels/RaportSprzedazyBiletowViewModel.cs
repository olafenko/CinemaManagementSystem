using Microsoft.Win32;
using PDABProjekt.Helper;
using PDABProjekt.Models;
using PDABProjekt.Models.BusinessLogic;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PDABProjekt.ViewModels
{
    public class RaportSprzedazyBiletowViewModel : RaportViewModelBase
    {

        #region BazaDanych

        private readonly PABProjektEntities kinoEntities;

        #endregion


        #region Konstruktor

        public RaportSprzedazyBiletowViewModel()
        {

            base.DisplayName = "Raport sprzedaży";
            kinoEntities = new PABProjektEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            Utarg = 0;
            IloscBiletow = 0;
            SredniaCenaBiletu = 0;
        }


        #endregion


        #region Pola i wlasciwosci

        private DateTime _DataOd;

        public DateTime DataOd
        {
            get { return _DataOd; }

            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }

        private DateTime _DataDo;

        public DateTime DataDo
        {
            get { return _DataDo; }

            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }

        private int? _IdFilmu;

        public int? IdFilmu
        {
            get { return _IdFilmu; }

            set
            {
                if (_IdFilmu != value)
                {
                    _IdFilmu = value;
                    OnPropertyChanged(() => IdFilmu);
                }
            }
        }

        public IQueryable<KeyAndValue> FilmyComboBoxItems
        {
            get
            {         
                return new FilmB(kinoEntities).GetFilmyKeyAndValueItems();
            }
        }

        private decimal? _Utarg;

        public decimal? Utarg
        {
            get { return _Utarg; }

            set
            {
                if (_Utarg != value)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg);
                }
            }
        }

        private int? _IloscBiletow;

        public int? IloscBiletow
        {
            get { return _IloscBiletow; }

            set
            {
                if (_IloscBiletow != value)
                {
                    _IloscBiletow = value;
                    OnPropertyChanged(() => IloscBiletow);
                }
            }
        }

        private decimal? _SredniaCenaBiletu;

        public decimal? SredniaCenaBiletu
        {
            get { return _SredniaCenaBiletu; }

            set
            {
                if (_SredniaCenaBiletu != value)
                {
                    _SredniaCenaBiletu = value;
                    OnPropertyChanged(() => SredniaCenaBiletu);
                }
            }
        }

        #endregion


        #region Komendy

        public override void obliczRaportClick()
        {

            //po zmianach
            var daneRaportu = new SprzedazBiletowB(kinoEntities).ObliczRaportSprzedazy(IdFilmu, DataOd, DataDo);

            Utarg = daneRaportu.Utarg;
            IloscBiletow = daneRaportu.IloscBiletow;
            SredniaCenaBiletu = daneRaportu.SredniaCenaBiletu;

        }


        public override void eksportujRaportClick()
        {

            new SprzedazBiletowB(kinoEntities).EksportujRaportDoCsv(IdFilmu, DataOd, DataDo);

        }  



        #endregion

    }
}
