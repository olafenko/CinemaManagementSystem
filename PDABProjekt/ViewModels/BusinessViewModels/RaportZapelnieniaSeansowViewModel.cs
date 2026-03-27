using PDABProjekt.Helper;
using PDABProjekt.Models;
using PDABProjekt.Models.BusinessLogic;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDABProjekt.ViewModels
{
    public class RaportZapelnieniaSeansowViewModel : RaportViewModelBase
    {

        #region BazaDanych

        private readonly PABProjektEntities kinoEntities;

        #endregion

        #region Konstruktor

        public RaportZapelnieniaSeansowViewModel()
        {
            base.DisplayName = "Raport wypełnienia seansów";
            kinoEntities = new PABProjektEntities();
            Data = DateTime.Now;          
        }

        #endregion

        #region Pola i wlasciwosci

        private DateTime _Data;

        public DateTime Data
        {
            get { return _Data; }
            set
            {
                if (_Data != value)
                {
                    _Data = value;
                    OnPropertyChanged(() => Data);
                }
            }
        }

        

        // kolekcja trzymająca rekordy raportu, generowane przez klase biznesową WypelnienieSeansowB
        private ObservableCollection<RaportZapelnieniaSeansowDTO> _ElementyRaportu;

        public ObservableCollection<RaportZapelnieniaSeansowDTO> ElementyRaportu
        {
            get { return _ElementyRaportu; }
            set
            {
                if (_ElementyRaportu != value)
                {
                    _ElementyRaportu = value;
                    OnPropertyChanged(() => ElementyRaportu);
                }
            }
        }



        #endregion


        #region Komendy


        //zaimplementowanie abstrakcyjnych metod z klasy RaportViewModelBase
        public override void obliczRaportClick()
        {
            //wypelnianie kolekcji ElementyRaportu, poprzez funkcje w klasie biznesowej
            ElementyRaportu = new ObservableCollection<RaportZapelnieniaSeansowDTO>(

                new ZapelnienieSeansowB(kinoEntities).GenerujDaneWypelnieniaSeansow(Data)
                );

        }

        public override void eksportujRaportClick()
        {
            new ZapelnienieSeansowB(kinoEntities).EksportujRaportDoCsv(Data);
        }

        #endregion


    }
}
