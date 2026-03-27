using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddMovieStatusViewModel : AddViewModelBase<StatusFilmu>
    {

        #region Constructor
        public AddMovieStatusViewModel() : base()
        {

            base.DisplayName = "Nowy status filmu";
            item = new StatusFilmu();

        }



        #endregion

        #region Properties

        public string Name
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

            kinoEntities.StatusFilmu.Add(item);
            kinoEntities.SaveChanges();
        }
        #endregion


    }
}
