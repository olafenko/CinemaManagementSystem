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
    public class NowySeansViewModel : AddViewModelBase<Seans>
    {

        #region Konstruktor
        public NowySeansViewModel()
        {
            base.DisplayName = "Seans";
            item = new Seans();
            item.DataSeansu = DateTime.Now;

            Messenger.Default.Register<FilmForAllView>(this, getWybranyFilm);
            Messenger.Default.Register<SalaForAllView>(this, getWybranaSala);
        }
        #endregion


        #region Commands
        
        private BaseCommand _ShowFilmy;

        public ICommand ShowFilmy
        {
            get
            {
                if (_ShowFilmy == null) _ShowFilmy = new BaseCommand(
                    () => Messenger.Default.Send("FilmyShow")
                    );
                return _ShowFilmy;
            }
        }

        private BaseCommand _ShowSale;

        public ICommand ShowSale
        {
            get
            {
                if (_ShowSale == null) _ShowSale = new BaseCommand(
                    () => Messenger.Default.Send("SaleShow")
                    );
                return _ShowSale;
            }
        }

        #endregion

        #region Wlasciwosci

        public int IdFilmu
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
                    OnPropertyChanged(() => item.IdFilmu);
                }
            }
        }

        private string _TytulFilmu;

        public string TytulFilmu
        {
            get { return _TytulFilmu; }

            set
            {
                if (_TytulFilmu != value)
                {
                    _TytulFilmu = value;
                    OnPropertyChanged(() => _TytulFilmu);
                }

            }
        }

        private string _GatunekFilmu;

        public string GatunekFilmu
        {
            get { return _GatunekFilmu; }

            set
            {
                if (_GatunekFilmu != value)
                {
                    _GatunekFilmu = value;
                    OnPropertyChanged(() => _GatunekFilmu);
                }

            }
        }

        private int _CzasTrwaniaFilmu;

        public int CzasTrwaniaFilmu
        {
            get { return _CzasTrwaniaFilmu; }

            set
            {
                if (_CzasTrwaniaFilmu != value)
                {
                    _CzasTrwaniaFilmu = value;
                    
                    OnPropertyChanged(() => _CzasTrwaniaFilmu);
                    GodzinaDoUi = GodzinaOdUi.AddMinutes(CzasTrwaniaFilmu);
                }

            }
        }

        public int IdSali
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
                    OnPropertyChanged(() => item.IdSali);
                }
            }
        }

        private int _NumerSali;

        public int NumerSali
        {
            get { return _NumerSali; }

            set
            {
                if (_NumerSali != value)
                {
                    _NumerSali = value;
                    OnPropertyChanged(() => _NumerSali);
                }

            }
        }

        private string _TypSali;

        public string TypSali
        {
            get { return _TypSali; }

            set
            {
                if (_TypSali != value)
                {
                    _TypSali = value;
                    OnPropertyChanged(() => _TypSali);
                }

            }
        }

        public int IdStatusuSeansu
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
                    OnPropertyChanged(() => item.IdStatusuSeansu);
                }
            }
        }

        public int IdJezyka
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
                    OnPropertyChanged(() => item.IdJezyka);
                }
            }
        }

        public DateTime DataSeansu
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
                    OnPropertyChanged(() => item.DataSeansu);
                }
            }
        }

        private DateTime _GodzinaOdUi; // prop do pola z widoku bo zapisuje wybrany czas jako DateTime, potem przy save wyciagam z niego sam czas i przypisuje do wlasciwego pola
        public DateTime GodzinaOdUi {
            get { return _GodzinaOdUi; }
            set {
                if (_GodzinaOdUi != value)
                {
                    _GodzinaOdUi = value;
                   
                    OnPropertyChanged(() => GodzinaOdUi);
                    GodzinaDoUi = GodzinaOdUi.AddMinutes(CzasTrwaniaFilmu);
                }
            }
        }

        private DateTime _GodzinaDoUi;
        public DateTime GodzinaDoUi
        {
            get { return _GodzinaDoUi; }
            set
            {
                if (_GodzinaDoUi != value)
                {
                    _GodzinaDoUi = value;
                   
                    OnPropertyChanged(() => GodzinaDoUi);
                }
            }
        }

        public TimeSpan GodzinaOd
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
                    OnPropertyChanged(() => item.GodzinaOd);
                }
            }
        }

        public TimeSpan GodzinaDo
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
                    OnPropertyChanged(() => item.GodzinaDo);
                }
            }
        }

        public bool CzyLektor
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
                    OnPropertyChanged(() => item.CzyLektor);
                }
            }
        }

        public bool CzyNapisy
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
                    OnPropertyChanged(() => item.CzyNapisy);
                }
            }
        }

        public bool CzyDubbing
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
                    OnPropertyChanged(() => item.CzyDubbing);
                }
            }
        }


        //comboboxy

        public IQueryable<StatusSeansu> StatusySeansuItems
        {
            get
            {
                return (
                    kinoEntities.StatusSeansu.Where(s => s.CzyAktywny).ToList().AsQueryable()
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



        #endregion

        #region Helpers

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            item.GodzinaOd = GodzinaOdUi.TimeOfDay;
            item.GodzinaDo = GodzinaDoUi.TimeOfDay;
            kinoEntities.Seans.Add(item);
            kinoEntities.SaveChanges();

        }

        private void getWybranyFilm(FilmForAllView film)
        {
            IdFilmu = film.Id;
            TytulFilmu = film.Tytul;
            GatunekFilmu = film.NazwaGatunku;
            CzasTrwaniaFilmu = film.CzasTrwania;

        }

        private void getWybranaSala(SalaForAllView sala)
        {
            IdSali = sala.Id;
            NumerSali = sala.NumerSali;
            TypSali = sala.TypSali;

        }

        #endregion


    }




}
