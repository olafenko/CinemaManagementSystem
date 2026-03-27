using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddSoundSystemTypeViewModel : AddViewModelBase<TypNaglosnienia>
    {

        #region Constructor

        public AddSoundSystemTypeViewModel() : base()
        {
            base.DisplayName = "Nowy typ naglosnienia";
            item = new TypNaglosnienia();

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
            kinoEntities.TypNaglosnienia.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion


    }


}

