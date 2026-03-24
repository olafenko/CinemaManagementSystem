using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using PDABProjekt.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowyKrajViewModel : AddViewModelBase<Kraj>
    {

        #region Konstruktor

        public NowyKrajViewModel() : base() {

            base.DisplayName = "Nowy kraj";
            item = new Kraj();

        }

        #endregion


        #region Wlasciwosci

        public string NazwaKraju
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


        #endregion

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.Kraj.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
