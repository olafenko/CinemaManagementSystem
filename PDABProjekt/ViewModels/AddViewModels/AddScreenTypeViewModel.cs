using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class AddScreenTypeViewModel : AddViewModelBase<TypEkranu>
    {

        #region Konstruktor

        public AddScreenTypeViewModel() : base()
        {
            base.DisplayName = "Nowy typ ekranu";
            item = new TypEkranu();        
      
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

        public string MaxResolution
        {
            get
            {
                return item.MaksymalnaRozdzielczosc;
            }
            set
            {
                if (item.MaksymalnaRozdzielczosc != value)
                {
                    item.MaksymalnaRozdzielczosc = value;
                    OnPropertyChanged(() => MaxResolution);
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

        public bool Glasses3DRequired
        {
            get
            {
                return item.CzyWymaganeOkulary3D;
            }
            set
            {
                if (item.CzyWymaganeOkulary3D != value)
                {
                    item.CzyWymaganeOkulary3D = value;
                    OnPropertyChanged(() => Glasses3DRequired);
                }
            }
        }

        #endregion

        #region Helpers

        public override void Save()
        {

            kinoEntities.TypEkranu.Add(item);
            kinoEntities.SaveChanges();
        }

        #endregion


    }
}
