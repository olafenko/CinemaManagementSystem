using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddDirectorViewModel : AddViewModelBase<Rezyser>
    {

        #region Constructor

        public AddDirectorViewModel()
        {
            base.DisplayName = "Rezyser";
            item = new Rezyser();

            LoadDictionaries();
        }

        #endregion

        #region Properties

        public string Name
        {

            get
            {
                return item.Imie;
            }


            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        public string LastName
        {

            get
            {
                return item.Nazwisko;
            }


            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public int CountryId
        {
            get
            {
                return item.IdKrajuPochodzenia;
            }
            set
            {
                if (item.IdKrajuPochodzenia != value)
                {
                    item.IdKrajuPochodzenia = value;
                    OnPropertyChanged(() => CountryId);
                }
            }
        }

        #endregion


        #region Dictionaries ComboBoxe's

        public List<Kraj> Countries { get; set; }


        #endregion

        #region Helpers

        public override void LoadDictionaries()
        {

            Countries = kinoEntities.Kraj.Where(k => k.CzyAktywny).ToList();


        }

        public override void Save()
        {

            kinoEntities.Rezyser.Add(item);
            kinoEntities.SaveChanges();

        }
        #endregion
    }
}
