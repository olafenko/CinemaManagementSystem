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
    public class AddGenreViewModel : AddViewModelBase<GatunekFilmu>
    {

        #region Constructor

        public AddGenreViewModel() : base() {

            base.DisplayName = "Nowy gatunek";
            item = new GatunekFilmu();

        }

        #endregion

        #region Properties

        public string Name
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
                    OnPropertyChanged(() => Name);
                }
            }
        }

        public string Description
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
                    OnPropertyChanged(() => Description);
                }
            }
        }

        #endregion

        #region Helpers

        public override void Save()
        {
            kinoEntities.GatunekFilmu.Add(item);
            kinoEntities.SaveChanges();
        }
    }

        #endregion


}
