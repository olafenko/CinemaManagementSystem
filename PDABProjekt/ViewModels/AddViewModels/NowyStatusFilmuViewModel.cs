using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowyStatusFilmuViewModel : AddViewModelBase<StatusFilmu>
    {

        #region Konstruktor
        public NowyStatusFilmuViewModel() : base()
        {

            base.DisplayName = "Nowy status filmu";
            item = new StatusFilmu();

        }



        #endregion

        #region Wlasciwosci

        public string NazwaStatusu
        {
            get
            {
                return item.NazwaStatusu;
            }
            set
            {
                if (item.NazwaStatusu != value)
                {
                    item.NazwaStatusu = value;
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


        #endregion

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.StatusFilmu.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
