using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddProducerViewModel : AddViewModelBase<Producent>
    {

        #region Constructor

        public AddProducerViewModel() : base()
        {
            base.DisplayName = "Nowy producent";
            item = new Producent();
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

            kinoEntities.Producent.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion



    }
}
