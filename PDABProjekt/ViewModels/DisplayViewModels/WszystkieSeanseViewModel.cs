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
    public class WszystkieSeanseViewModel : WszystkieViewModel<SeansForAllView>
    {

        #region Konstruktor

        public WszystkieSeanseViewModel()
        {
            base.DisplayName = "Seanse";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<SeansForAllView>(

                kinoEntities.Seans.ToList().Select(s => new SeansForAllView
                {
                    Id = s.IdSeansu,
                    TytulFilmu = s.Film.Tytul,
                    Sala = s.Sala.NumerSali,
                    LiczbaMiejsc = s.Sala.LiczbaMiejsc,
                    TypSali = s.Sala.TypSali.Nazwa,
                    DataSeansu = s.DataSeansu.ToString("yyyy-MM-dd"),
                    GodzinaOd = s.GodzinaOd,
                    GodzinaDo = s.GodzinaDo,
                    CzasTrwania = s.Film.CzasTrwania,
                    JezykWersji = s.Jezyk.Nazwa,
                    WersjaJezykowa = s.CzyDubbing ? "Dubbing" : s.CzyLektor ? "Lektor" : s.CzyNapisy ? "Napisy" : "Audio oryginalne",
                    Status = s.StatusSeansu.Nazwa,
                    WolneMiejsca = s.Sala.LiczbaMiejsc - s.Bilet.Count()

                }

                )
            );
        }

        #endregion

        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Czas trwania", "Data seansu"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Czas trwania":
                    {
                        List = new ObservableCollection<SeansForAllView>(List.OrderBy(s => s.CzasTrwania));
                        break;
                    }

                    // jak ta sama data to po godzinie
                case "Data seansu":
                    {
                        List = new ObservableCollection<SeansForAllView>(List.OrderBy(s => s.DataSeansu).ThenBy(s=> s.GodzinaOd));
                        break;
                    }

            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Tytuł","Numer sali","Język","Wersja jezykowa"
            };
        }

        public override void Find()
        {
            if (String.IsNullOrWhiteSpace(FindTextBox))
            {
                Load();
            }

            else
            {
                switch (FindField)
                {
                    case "Tytuł":
                        {
                            List = new ObservableCollection<SeansForAllView>(List.Where(s => s.TytulFilmu.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Numer sali":
                        {
                            List = new ObservableCollection<SeansForAllView>(List.Where(s => s.Sala == int.Parse(FindTextBox)));
                            break;
                        }

                    case "Język":
                        {
                            List = new ObservableCollection<SeansForAllView>(List.Where(s => s.JezykWersji.StartsWith(FindTextBox)));
                            break;
                        }
                    case "Wersja jezykowa":
                    {
                        List = new ObservableCollection<SeansForAllView>(List.Where(s => s.WersjaJezykowa.StartsWith(FindTextBox)));
                        break;
                    }

                }

                
            }
        }


        #endregion

    }
}
