using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace PDABProjekt.ViewModels
{
    public class AllScreeningsViewModel : DisplayAllViewModelBase<SeansForAllView>
    {

        #region Constructor

        public AllScreeningsViewModel()
        {
            base.DisplayName = "Seanse";
        }

        #endregion

        #region List
        public override void Load()
        {
            IQueryable<SeansForAllView> query = kinoEntities.Seans.Where(s => s.CzyAktywny).Select(s => new SeansForAllView
            {
                Id = s.IdSeansu,
                TytulFilmu = s.Film.Tytul,
                Sala = s.Sala.NumerSali,
                LiczbaMiejsc = s.Sala.LiczbaMiejsc,
                TypSali = s.Sala.TypSali.Nazwa,
                DataSeansu = s.DataSeansu,
                GodzinaOd = s.GodzinaOd,
                GodzinaDo = s.GodzinaDo,
                CzasTrwania = s.Film.CzasTrwania,
                JezykWersji = s.Jezyk.Nazwa,
                WersjaJezykowa = s.CzyDubbing ? "Dubbing" : s.CzyLektor ? "Lektor" : s.CzyNapisy ? "Napisy" : "Audio oryginalne",
                Status = s.StatusSeansu.Nazwa,
                WolneMiejsca = s.Sala.LiczbaMiejsc - s.Bilet.Count()

            }).AsQueryable();

            query = ApplySort(query);
            query = ApplyFilter(query);


            List = new ObservableCollection<SeansForAllView>(query.ToList());


        }

        #endregion

        #region Sort and filter

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Czas trwania", "Data seansu"
            };
        }

        private IQueryable<SeansForAllView> ApplySort(IQueryable<SeansForAllView> query)
        {

            switch (SortField)
            {
                case "Czas trwania": return query.OrderBy(s => s.CzasTrwania);

                case "Data seansu": return query.OrderBy(s => s.DataSeansu).ThenBy(s => s.GodzinaOd);

                default: return query;

            }

        }


        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Tytuł","Numer sali","Język","Wersja jezykowa"
            };
        }

        private IQueryable<SeansForAllView> ApplyFilter(IQueryable<SeansForAllView> query)
        {

            if (String.IsNullOrWhiteSpace(FindTextBox)) return query;


            switch (FindField)
            {
                case "Tytuł": return query.Where(s => s.TytulFilmu.Contains(FindTextBox));

                case "Numer sali":
                    {
                        if (int.TryParse(FindTextBox, out int searchedHallNum))
                        {
                            return query.Where(s => s.Sala == searchedHallNum);
                        }

                        return query;
                    }

                case "Język": return query.Where(s => s.JezykWersji.Contains(FindTextBox));

                case "Wersja jezykowa": return query.Where(s => s.WersjaJezykowa.StartsWith(FindTextBox));

                default: return query;
            }

        }

        #endregion

    }
}
