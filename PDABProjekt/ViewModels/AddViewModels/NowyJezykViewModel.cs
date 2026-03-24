using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowyJezykViewModel : AddViewModelBase<Jezyk>
    {


        #region Konstruktor

        public NowyJezykViewModel() : base() {

            base.DisplayName = "Nowy jezyk";
            item = new Jezyk();

        }

        #endregion


        #region Wlasciwosci

        public string Nazwa
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
                    OnPropertyChanged(() => item.Nazwa);
                }
            }
        }

        public string KodISO
        {
            get
            {
                return item.KodISO;
            }
            set
            {
                if (item.KodISO != value)
                {
                    item.KodISO = value;
                    OnPropertyChanged(() => item.KodISO);
                }
            }
        }

        #endregion

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.Jezyk.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
