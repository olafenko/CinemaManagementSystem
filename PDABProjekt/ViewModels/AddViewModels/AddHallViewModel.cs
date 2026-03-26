using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddHallViewModel : AddViewModelBase<Sala>
    {


        #region Constructor
        public AddHallViewModel()
        {
            base.DisplayName = "Sala";
            item = new Sala();

            LoadDictionaries();

        }
        #endregion


        #region Commands

        #endregion

        #region Properties

        public int HallNumber
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
                    OnPropertyChanged(() => HallNumber);
                }
            }
        }

        public int SeatsCount
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
                    OnPropertyChanged(() => SeatsCount);
                }
            }
        }

        public int ScreenTypeId
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
                    OnPropertyChanged(() => ScreenTypeId);
                }
            }
        }

        public int SoundSystemTypeId
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
                    OnPropertyChanged(() => SoundSystemTypeId);
                }
            }
        }

        public int HallTypeId
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
                    OnPropertyChanged(() => HallTypeId);
                }
            }
        }

        #endregion

        #region Dictionatries ComboBoxe's
        public List<TypEkranu> ScreenTypes { get; set; }
        public List<TypNaglosnienia> SoundSystemTypes { get; set; }
        public List<TypSali> HallTypes { get; set; }

        #endregion

        #region Helpers

        public override void LoadDictionaries()
        {
            ScreenTypes = kinoEntities.TypEkranu.Where(e => e.CzyAktywny).ToList();
            SoundSystemTypes = kinoEntities.TypNaglosnienia.Where(n => n.CzyAktywny).ToList();
            HallTypes = kinoEntities.TypSali.Where(s => s.CzyAktywny).ToList();

        }

        public override void Save()
        {

            kinoEntities.Sala.Add(item);
            kinoEntities.SaveChanges();

        }

        #endregion

    }
}
