using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddAgeCategoryViewModel : AddViewModelBase<KategoriaWiekowa>
    {


        #region Constructor

        public AddAgeCategoryViewModel() : base() {

            base.DisplayName = "Nowa kategoria wiekowa";
            item = new KategoriaWiekowa();

        }

        #endregion



        #region Properties


        public string CategoryName 
        { 
            get
            {
                return item.NazwaKategorii;
            }

            set
            {
                if (item.NazwaKategorii != value)
                {
                    item.NazwaKategorii = value;
                    OnPropertyChanged(() => CategoryName);
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

        public override void Save()
        {
            kinoEntities.KategoriaWiekowa.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
