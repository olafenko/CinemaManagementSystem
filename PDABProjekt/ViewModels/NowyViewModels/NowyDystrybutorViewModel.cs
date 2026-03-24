using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowyDystrybutorViewModel : JedenViewModel<Dystrybutor>
    {

        #region Konstruktor
        public NowyDystrybutorViewModel()
        {
            base.DisplayName = "Dystrybutor";
            item = new Dystrybutor();
        }
        #endregion


        #region Commands

        #endregion

        #region Wlasciwosci

        public string Nazwa
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

        public int IdKraju
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

        public string TelefonKontaktowy
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

        public string ModelRozliczen
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
      
        public decimal? ProcentProwizji
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

        public bool CzyUmowaPodpisana
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

        public string NumerUmowy
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

        public DateTime? UmowaOd
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

        public DateTime? UmowaDo
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

      
        //comboboxy

        public IQueryable<Kraj> KrajeItems
        {
            get
            {
                return (
                    kinoEntities.Kraj.Where(k => k.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }


        #endregion

        #region Helpers

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.Dystrybutor.Add(item);
            kinoEntities.SaveChanges();

        }
        #endregion

    }
}
