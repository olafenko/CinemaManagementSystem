using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowaKategoriaWiekowaViewModel : AddViewModelBase<KategoriaWiekowa>
    {


        #region Konstruktor

        public NowaKategoriaWiekowaViewModel() : base() {

            base.DisplayName = "Nowa kategoria wiekowa";
            item = new KategoriaWiekowa();

        }

        #endregion



        #region Wlasciwosci


        public string NazwaKategorii 
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
                    OnPropertyChanged(() => item.NazwaKategorii);
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
                    OnPropertyChanged(() => item.Opis);
                }
            }
        }




        #endregion

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.KategoriaWiekowa.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
