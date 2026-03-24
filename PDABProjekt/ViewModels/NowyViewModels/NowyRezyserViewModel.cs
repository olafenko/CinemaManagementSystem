using PDABProjekt.Models;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.ViewModels.NowyViewModels
{
    public class NowyRezyserViewModel : JedenViewModel<Rezyser>
    {

        #region Konstruktor

        public NowyRezyserViewModel()
        {
            base.DisplayName = "Rezyser";
            item = new Rezyser();
        }

        #endregion

        #region Wlasciwosci

        #endregion

        #region Helpers

        public override void Save()
        {
            item.CzyAktywny = true;
            item.KtoDodal = "admin";
            item.KiedyDodal = DateTime.Now;
            kinoEntities.Rezyser.Add(item);
            kinoEntities.SaveChanges();

        }
        #endregion
    }
}
