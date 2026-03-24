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
    public class WszystkieBiletyViewModel : WszystkieViewModel<BiletForAllView>
    {

        #region Konstruktor

        public WszystkieBiletyViewModel()
        {
            base.DisplayName = "Bilety";
        }

        #endregion

        #region Lista
        public override void Load()
        {
            List = new ObservableCollection<BiletForAllView>(
                kinoEntities.Bilet.ToList().Select(b => new BiletForAllView
                {
                    Id = b.IdBiletu,
                    NazwaSeansu = b.Seans.Film.Tytul,
                    DataSeansu = b.Seans.DataSeansu.ToString("yyyy-MM-dd"),
                    SeansOd = b.Seans.GodzinaOd,
                    SeansDo = b.Seans.GodzinaDo,
                    NumerSali = b.MiejsceWSali.Sala.NumerSali,
                    NumerRzedu = b.MiejsceWSali.Rzad,
                    NumerMiejsca = b.MiejsceWSali.Numer,
                    TypMiejsca = b.MiejsceWSali.TypMiejsca,
                    TypBiletu = b.TypBiletu.Nazwa,
                    Rabat = b.Rabat.ToString("P"),
                    CenaFinalna = (b.Cena - (b.Cena * b.Rabat)).ToString("C"),
                    DataSprzedazy = b.DataSprzedazy,
                    CzyAnulowany = b.CzyAnulowany ? "Tak" : "Nie",




                })
                );
        }

        #endregion

        #region Sortowanie i filtrowanie

        public override List<string> GetComboBoxSortList()
        {
            return new List<string>
            {
                "Data sprzedaży", "Cena"
            };
        }

        public override void Sort()
        {
            switch (SortField)
            {
                case "Data sprzedaży":
                    {
                        List = new ObservableCollection<BiletForAllView>(List.OrderBy(b => b.DataSprzedazy));
                        break;
                    }

                case "Cena":
                    {
                        List = new ObservableCollection<BiletForAllView>(List.OrderBy(b => b.CenaFinalna));
                        break;
                    }



            }
        }

        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Seans", "Numer sali","Typ miejsca","Typ biletu"
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
                    case "Seans":
                        {
                            List = new ObservableCollection<BiletForAllView>(List.Where(b => b.NazwaSeansu.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Numer sali":
                        {
                            List = new ObservableCollection<BiletForAllView>(List.Where(b => b.NumerSali == int.Parse(FindTextBox)));
                            break;
                        }

                    case "Typ miejsca":
                        {
                            List = new ObservableCollection<BiletForAllView>(List.Where(b => b.TypMiejsca.StartsWith(FindTextBox)));
                            break;
                        }

                    case "Typ biletu":
                        {
                            List = new ObservableCollection<BiletForAllView>(List.Where(b => b.TypBiletu.StartsWith(FindTextBox)));
                            break;
                        }

                }

                
            }

        }


        #endregion
    }
}
