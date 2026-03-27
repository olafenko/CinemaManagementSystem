using PDABProjekt.Models;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace PDABProjekt.ViewModels
{
    public class AllTicketsViewModel : DisplayAllViewModelBase<BiletForAllView>
    {

        #region Constructor

        public AllTicketsViewModel()
        {
            base.DisplayName = "Bilety";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<BiletForAllView> query = kinoEntities.Bilet.Where(b => b.CzyAktywny).Select(b => new BiletForAllView
            {
                Id = b.IdBiletu,
                NazwaSeansu = b.Seans.Film.Tytul,
                DataSeansu = b.Seans.DataSeansu,
                SeansOd = b.Seans.GodzinaOd,
                SeansDo = b.Seans.GodzinaDo,
                NumerSali = b.MiejsceWSali.Sala.NumerSali,
                NumerRzedu = b.MiejsceWSali.Rzad,
                NumerMiejsca = b.MiejsceWSali.Numer,
                TypMiejsca = b.MiejsceWSali.TypMiejsca,
                TypBiletu = b.TypBiletu.Nazwa,
                Rabat = b.Rabat,
                CenaFinalna = (b.Cena - (b.Cena * b.Rabat)),
                DataSprzedazy = b.DataSprzedazy,
                CzyAnulowany = b.CzyAnulowany ? "Tak" : "Nie",

            }).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);


            List = new ObservableCollection<BiletForAllView>(query.ToList());
        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Data sprzedaży", "Cena"
            };
        }

        private IQueryable<BiletForAllView> ApplySort(IQueryable<BiletForAllView> query)
        {

            switch (SortField)
            {
                case "Data sprzedaży": return query.OrderBy(b => b.DataSprzedazy);

                case "Cena": return query.OrderBy(b => b.CenaFinalna);

                default: return query;

            }

        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Seans", "Numer sali","Typ miejsca","Typ biletu"
            };
        }

        private IQueryable<BiletForAllView> ApplyFilter(IQueryable<BiletForAllView> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Seans": return query.Where(b => b.NazwaSeansu.Contains(FindTextBox));

                case "Numer sali":
                    {
                        if(int.TryParse(FindTextBox,out int searchedNumber))
                        {
                            return query.Where(b => b.NumerSali == searchedNumber);
                        }

                        return query;
                    }

                case "Typ miejsca": return query.Where(b => b.TypMiejsca.Contains(FindTextBox));

                case "Typ biletu": return query.Where(b => b.TypBiletu.Contains(FindTextBox));

                default: return query;
            }

        }

        #endregion
    }
}
