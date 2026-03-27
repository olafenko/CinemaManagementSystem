using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddLanguageViewModel : AddViewModelBase<Jezyk>
    {


        #region Constructor

        public AddLanguageViewModel() : base() {

            base.DisplayName = "Nowy język";
            item = new Jezyk();

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

        public string CodeISO
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
                    OnPropertyChanged(() => CodeISO);
                }
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            kinoEntities.Jezyk.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion


    }
}
