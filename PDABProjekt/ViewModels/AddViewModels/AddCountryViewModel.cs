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
    public class AddCountryViewModel : AddViewModelBase<Kraj>
    {

        #region Constructor

        public AddCountryViewModel() : base() {

            base.DisplayName = "Nowy kraj";
            item = new Kraj();

        }

        #endregion


        #region Properties

        public string Name
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
                    OnPropertyChanged(() => Name);
                }
            }
        }


        #endregion

        #region Helpers
        public override void Save()
        {
            kinoEntities.Kraj.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion


    }
}
