using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowaSalaViewModel : JedenViewModel<Sala>
    {


        #region Konstruktor
        public NowaSalaViewModel()
        {
            base.DisplayName = "Sala";
            item = new Sala();
        }
        #endregion


        #region Commands

        #endregion

        #region Wlasciwosci

        public int NumerSali
        {
            get
            {
                return item.NumerSali;
            }

            set
            {
                if (item.NumerSali != value)
                {
                    item.NumerSali = value;
                    OnPropertyChanged(() => item.NumerSali);
                }
            }
        }

        public int LiczbaMiejsc
        {
            get
            {
                return item.LiczbaMiejsc;
            }

            set
            {
                if (item.LiczbaMiejsc != value)
                {
                    item.LiczbaMiejsc = value;
                    OnPropertyChanged(() => item.LiczbaMiejsc);
                }
            }
        }

        public int IdTypuEkranu
        {
            get
            {
                return item.IdTypuEkranu;
            }

            set
            {
                if (item.IdTypuEkranu != value)
                {
                    item.IdTypuEkranu = value;
                    OnPropertyChanged(() => item.IdTypuEkranu);
                }
            }
        }

        public int IdTypuNaglosnienia
        {
            get
            {
                return item.IdTypuNaglosnienia;
            }

            set
            {
                if (item.IdTypuNaglosnienia != value)
                {
                    item.IdTypuNaglosnienia = value;
                    OnPropertyChanged(() => item.IdTypuNaglosnienia);
                }
            }
        }

        public int IdTypuSali
        {
            get
            {
                return item.IdTypuSali;
            }

            set
            {
                if (item.IdTypuSali != value)
                {
                    item.IdTypuSali = value;
                    OnPropertyChanged(() => item.IdTypuSali);
                }
            }
        }


        //comboboxy

        public IQueryable<TypEkranu> TypyEkranuItems
        {
            get
            {
                return (
                    kinoEntities.TypEkranu.Where(e => e.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }

        public IQueryable<TypNaglosnienia> TypyNaglosnieniaItems
        {
            get
            {
                return (
                    kinoEntities.TypNaglosnienia.Where(n => n.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }
        public IQueryable<TypSali> TypySaliItems
        {
            get
            {
                return (
                    kinoEntities.TypSali.Where(s => s.CzyAktywny).ToList().AsQueryable()
                    );
            }
        }


        #endregion

        #region Helpers

        public override void Save()
        {
            item.CzyAktywna = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.Sala.Add(item);
            kinoEntities.SaveChanges();

        }
        #endregion

    }
}
