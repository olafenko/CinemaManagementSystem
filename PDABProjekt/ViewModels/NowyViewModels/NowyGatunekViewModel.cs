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
    public class NowyGatunekViewModel : JedenViewModel<GatunekFilmu>
    {

        #region Konstruktor

        public NowyGatunekViewModel() : base() {

            base.DisplayName = "Nowy gatunek";
            item = new GatunekFilmu();

        }

        #endregion

        #region Wlasciwosci

        public string NazwaGatunku
        {
            get
            {
                return item.NazwaGatunku;
            }
            set
            {
                if (item.NazwaGatunku != value)
                {
                    item.NazwaGatunku = value;
                    OnPropertyChanged(() => NazwaGatunku);
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
            kinoEntities.GatunekFilmu.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
