using PDABProjekt.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.BusinessLogic
{
    public class FilmB : DatabaseClass
    {


        #region Konstruktor

        public FilmB(PABProjektEntities kinoEntities) : base(kinoEntities)
        {


        }
        #endregion


        #region Funkcje pomocnicze

        // ta funkcja ładuje filmy do combo boxa
        public IQueryable<KeyAndValue> GetFilmyKeyAndValueItems()
        {
            var listaFilmow = kinoEntities.Film.Where(f => f.CzyAktywny == true).ToList()
                .Select(f => new KeyAndValue
                {
                    Key = f.IdFilmu,
                    Value = f.Tytul + " " + f.GatunekFilmu.NazwaGatunku

                }).ToList();

            // dodaje na poczatek listy opcje wszystkie aby moc wybrac w comboboxie taka opcje generowania raportu
            listaFilmow.Insert(0, new KeyAndValue
            {
                Key = null,
                Value = "Wszystkie"
            });

            return listaFilmow.AsQueryable();
            
        }

     
        #endregion


    }
}
