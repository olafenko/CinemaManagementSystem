using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowyStatusSeansuViewModel : AddViewModelBase<StatusSeansu>
    {

        #region Konstruktor

        public NowyStatusSeansuViewModel() : base()
        {
            base.DisplayName = "Nowy status seansu";
            item = new StatusSeansu();
        
        }


        #endregion


        #region Wlasciwosci

        public string NazwaStatusu
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
                    OnPropertyChanged(() => NazwaStatusu);
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

        public bool CzySprzedawacBilety
        {
            get
            {
                return item.CzySprzedawacBilety;
            }
            set
            {
                if (item.CzySprzedawacBilety != value)
                {
                    item.CzySprzedawacBilety = value;
                    OnPropertyChanged(() => CzySprzedawacBilety);
                }
            }
        }

        #endregion

        public override void Save()
        {
            item.CzyAktywny = true;            
            kinoEntities.StatusSeansu.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
