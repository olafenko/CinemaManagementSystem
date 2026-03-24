using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels
{
    public class NowyTypEkranuViewModel : JedenViewModel<TypEkranu>
    {

        #region Konstruktor

        public NowyTypEkranuViewModel() : base()
        {
            base.DisplayName = "Nowy typ ekranu";
            item = new TypEkranu();        
      
        }

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
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }

        public string MaksymalnaRozdzielczosc
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
                    OnPropertyChanged(() => MaksymalnaRozdzielczosc);
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
                    OnPropertyChanged(() => Opis);
                }
            }
        }

        public bool CzyWymaganeOkulary3D
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
                    OnPropertyChanged(() => CzyWymaganeOkulary3D);
                }
            }
        }

        #endregion

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.TypEkranu.Add(item);
            kinoEntities.SaveChanges();
        }
    }
}
