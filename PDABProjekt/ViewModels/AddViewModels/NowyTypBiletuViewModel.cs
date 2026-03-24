using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowyTypBiletuViewModel : AddViewModelBase<TypBiletu>
    {




        #region Konstruktor

        public NowyTypBiletuViewModel() :base()
        {

            base.DisplayName = "Nowy typ biletu";
            item = new TypBiletu();


        }

        #endregion

        #region Wlasciwosci

        public string NazwaTypuBiletu
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => NazwaTypuBiletu);
                }
            }
        }

        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    OnPropertyChanged(() => Cena);
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
                    OnPropertyChanged(() => Opis);
                }
            }
        }

        public bool CzyPodlegaPromocji
        {
            get
            {
                return item.CzyPodlegaPromocji;
            }
            set
            {
                if (item.CzyPodlegaPromocji != value)
                {
                    item.CzyPodlegaPromocji = value;
                    OnPropertyChanged(() => CzyPodlegaPromocji);
                }
            }
        }

        #endregion


        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.TypBiletu.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
