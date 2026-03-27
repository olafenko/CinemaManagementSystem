using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddHallTypeViewModel : AddViewModelBase<TypSali>
    {

        #region Constructor

        public AddHallTypeViewModel() : base()
        {
            base.DisplayName = "Nowy typ sali";
            item = new TypSali();

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

        #endregion

        #region Helpers

        public override void Save()
        {
            kinoEntities.TypSali.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion


    }

}

