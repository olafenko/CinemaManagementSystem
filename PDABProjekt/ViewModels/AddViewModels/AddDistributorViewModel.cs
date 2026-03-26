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
                    OnPropertyChanged(() => Name);
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
                    OnPropertyChanged(() => CountryId);
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
                    OnPropertyChanged(() => Email);
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
                    OnPropertyChanged(() => ContactPhone);
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
                    OnPropertyChanged(() => SettlementModel);
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
                    OnPropertyChanged(() => CommissionPercentage);
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
                    OnPropertyChanged(() => IsContractSigned);
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
                    OnPropertyChanged(() => ContractNumber);
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
                    OnPropertyChanged(() => ContractDateFrom);
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
                    OnPropertyChanged(() => ContractDateUntil);
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
