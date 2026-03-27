using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddScreeningStatusViewModel : AddViewModelBase<StatusSeansu>
    {

        #region Constructor

        public AddScreeningStatusViewModel() : base()
        {
            base.DisplayName = "Nowy status seansu";
            item = new StatusSeansu();
        
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

        public bool IsSellingTicketsAllowed
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
                    OnPropertyChanged(() => IsSellingTicketsAllowed);
                }
            }
        }

        #endregion

        #region Helpers

        public override void Save()
        {
            kinoEntities.StatusSeansu.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion


    }
}
