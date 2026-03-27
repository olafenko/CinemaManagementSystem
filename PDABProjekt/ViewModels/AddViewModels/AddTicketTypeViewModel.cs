using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddTicketTypeViewModel : AddViewModelBase<TypBiletu>
    {




        #region Constructor

        public AddTicketTypeViewModel() :base()
        {

            base.DisplayName = "Nowy typ biletu";
            item = new TypBiletu();


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

        public decimal? BasePrice
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    OnPropertyChanged(() => BasePrice);
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

        public bool IsSubjectToPromotion
        {
            get
            {
                return item.CzyPodlegaPromocji;
            }
            set
            {
                if (item.CzyPodlegaPromocji != value)
                {
                    item.CzyPodlegaPromocji = value;
                    OnPropertyChanged(() => IsSubjectToPromotion);
                }
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {

            kinoEntities.TypBiletu.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion


    }
}
