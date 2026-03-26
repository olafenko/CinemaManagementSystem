using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddDistributorViewModel : AddViewModelBase<Dystrybutor>
    {

        #region Constructor
        public AddDistributorViewModel()
        {
            base.DisplayName = "Dystrybutor";
            item = new Dystrybutor();

            LoadDictionaries();
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
                    OnPropertyChanged(() => item.Nazwa);
                }
            }
        }

        public int CountryId
        {
            get
            {
                return item.IdKraju;
            }

            set
            {
                if (item.IdKraju != value)
                {
                    item.IdKraju = value;
                    OnPropertyChanged(() => item.IdKraju);
                }
            }
        }

        public string Email
        {
            get
            {
                return item.Email;
            }

            set
            {
                if (item.Email != value)
                {
                    item.Email = value;
                    OnPropertyChanged(() => item.Email);
                }
            }
        }

        public string ContactPhone
        {
            get
            {
                return item.TelefonKontaktowy;
            }

            set
            {
                if (item.TelefonKontaktowy != value)
                {
                    item.TelefonKontaktowy = value;
                    OnPropertyChanged(() => item.TelefonKontaktowy);
                }
            }
        }

        public string SettlementModel
        {
            get
            {
                return item.ModelRozliczen;
            }

            set
            {
                if (item.ModelRozliczen != value)
                {
                    item.ModelRozliczen = value;
                    OnPropertyChanged(() => item.ModelRozliczen);
                }
            }
        }
      
        public decimal? CommissionPercentage
        {
            get
            {
                return item.ProcentProwizji;
            }

            set
            {
                if (item.ProcentProwizji != value)
                {
                    item.ProcentProwizji = value;
                    OnPropertyChanged(() => item.ProcentProwizji);
                }
            }
        }

        public bool IsContractSigned
        {
            get
            {
                return item.CzyUmowaPodpisana;
            }

            set
            {
                if (item.CzyUmowaPodpisana != value)
                {
                    item.CzyUmowaPodpisana = value;
                    OnPropertyChanged(() => item.CzyUmowaPodpisana);
                }
            }
        }

        public string ContractNumber
        {
            get
            {
                return item.NumerUmowy;
            }

            set
            {
                if (item.NumerUmowy != value)
                {
                    item.NumerUmowy = value;
                    OnPropertyChanged(() => item.NumerUmowy);
                }
            }
        }

        public DateTime? ContractDateFrom
        {
            get
            {
                return item.UmowaOd;
            }

            set
            {
                if (item.UmowaOd != value)
                {
                    item.UmowaOd = value;
                    OnPropertyChanged(() => item.UmowaOd);
                }
            }
        }

        public DateTime? ContractDateUntil
        {
            get
            {
                return item.UmowaDo;
            }

            set
            {
                if (item.UmowaDo != value)
                {
                    item.UmowaDo = value;
                    OnPropertyChanged(() => item.UmowaDo);
                }
            }
        }

        #endregion

        #region Dictionatries ComboBoxe's

        public List<Kraj> Countries { get; set; }

        #endregion

        #region Helpers

        public override void LoadDictionaries()
        {
            Countries = kinoEntities.Kraj.Where(k => k.CzyAktywny).ToList();
        }

        public override void Save()
        {
            kinoEntities.Dystrybutor.Add(item);
            kinoEntities.SaveChanges();

        }

        #endregion

    }
}
