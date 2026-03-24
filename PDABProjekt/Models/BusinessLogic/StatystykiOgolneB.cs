using CsvHelper;
using Microsoft.Win32;
using PDABProjekt.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.BusinessLogic
{

    //klasa biznesowa licząca ogólne statystyki kina dla dnia/okresu
    public class StatystykiOgolneB : DatabaseClass
    {

        #region Konstruktor
        public StatystykiOgolneB(PABProjektEntities kinoEntities) : base(kinoEntities)
        {
        }
        #endregion

        #region Funkcje biznesowe

        public StatystykiOgolneDTO GenerujStatystykiOgolne(DateTime data)
        {

            // bierze wszystkie bilety na seanse dla danego dnia    
            var biletyData = kinoEntities.Bilet.Where(b =>
            b.Seans.DataSeansu == data &&
            b.CzyAktywny == true &&
            b.CzyOplacony == true &&
            b.CzyAnulowany == false
            );

            // bierze seanse na podana date
            var seanseDzien = kinoEntities.Seans.Where(s => s.DataSeansu == data && s.Sala.LiczbaMiejsc >0);


            return new StatystykiOgolneDTO()
            {

                SprzedaneBilety = biletyData.Count(),
                Utarg = biletyData.Select(b => (decimal?)b.Cena - (b.Cena * b.Rabat)).Sum() ?? 0,
                NajpopularniejszySeans = seanseDzien.OrderByDescending(s => s.Bilet.Count(b => b.CzyAktywny && b.CzyOplacony && !b.CzyAnulowany))
                                                                                   .Select(s => s.Film.Tytul).FirstOrDefault() ?? "brak",

                NajpopularniejszyFilm = seanseDzien.GroupBy(s => s.Film.Tytul).OrderByDescending(f => f.Sum(s => s.Bilet.Count(b => b.CzyAktywny && b.CzyOplacony && !b.CzyAnulowany)))
                                                                                   .Select(s => s.Key).FirstOrDefault() ?? "brak",
                LiczbaSeansow = seanseDzien.Count(),
                SrednieWypelnienieSali = seanseDzien.Select(s => (decimal?)s.Bilet.Count(b => b.CzyAktywny && b.CzyOplacony && !b.CzyAnulowany) / s.Sala.LiczbaMiejsc).Average() ?? 0,


            };

        }


        public void EksportujRaportDoCsv(DateTime data)
        {


            var daneDoRaportu = GenerujStatystykiOgolne(data);
            //tworzy okienko do zapisania nowego pliku
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Plik CSV (*.csv)|*.csv"; // ustawia formaty pliku do wybrania
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // ustawia defaultowa lokalizacje zapisywania pliku
            saveDialog.ShowDialog(); //wyswietla okienko

            //sprawdza czy nazwa pliku nie jest pusta, np w przypadku klikniecia anuluj w okienku, wtedy probowalo stworzyc StreamWritera bez sciezki i wywalalo
            if (!String.IsNullOrEmpty(saveDialog.FileName))
            {
                // tworzy plik na sciezce wybranej w saveDialog , pole saveDialog.FileName zawiera pelna sciezke do wybranego pliku
                using (var writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
                    {

                        csv.WriteField("Raport dzienny");

                        csv.NextRecord();
                        csv.WriteField("Dla dnia: ");
                        csv.WriteField(data);
                        csv.NextRecord();
                        csv.WriteField("Ilosc sprzedanych biletów: ");
                        csv.WriteField(daneDoRaportu.SprzedaneBilety);
                        csv.NextRecord();
                        csv.WriteField("Utarg: ");
                        csv.WriteField(daneDoRaportu.Utarg + "zł");
                        csv.NextRecord();
                        csv.WriteField("Najpopularniejszy seans: ");
                        csv.WriteField(daneDoRaportu.NajpopularniejszySeans);
                        csv.NextRecord();
                        csv.WriteField("Najpopularniejszy film: ");
                        csv.WriteField(daneDoRaportu.NajpopularniejszyFilm);
                        csv.NextRecord();
                        csv.WriteField("Średnie wypełnienie sali: ");
                        csv.WriteField(daneDoRaportu.SrednieWypelnienieSali + "%");
                        csv.NextRecord();
                        csv.WriteField("Ilość seansów: ");
                        csv.WriteField(daneDoRaportu.LiczbaSeansow);
                        csv.NextRecord();
                    }
                }
            }


        }

        #endregion

    }
}
