using CsvHelper;
using Microsoft.Win32;
using PDABProjekt.Models.EntitiesForView;
using PDABProjekt.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.BusinessLogic
{
    public class SprzedazBiletowB : DatabaseClass
    {

        #region Konstruktor
        public SprzedazBiletowB(PABProjektEntities kinoEntities) : base(kinoEntities)
        {
        }

        #endregion

        #region Funkcje biznesowe

        // logika generowania raportu sprzedazy
        public RaportSprzedazyDTO ObliczRaportSprzedazy(int? idFilmu, DateTime dataOd, DateTime dataDo)
        {

            // wspólne zapytanie dla kazdego z elementów raportu
            // bierze bilety pokrywające się z parametrami
            var bilety = getBiletyDoRaportu(idFilmu,dataOd,dataDo);


            return new RaportSprzedazyDTO
            {
                Utarg = bilety.Select(b => (decimal?)b.Cena - (b.Cena * b.Rabat)).Sum() ?? 0,
                IloscBiletow = bilety.Count(),
                SredniaCenaBiletu = bilety.Select(b =>(decimal?) b.Cena).Average() ?? 0

            };


        }

        public void EksportujRaportDoCsv(int? idFilmu, DateTime dataOd, DateTime dataDo)
        {

            var bilety = getBiletyDoRaportu(idFilmu, dataOd, dataDo);

            //lista biletów do raportu
            var biletyDoRaportu = bilety.ToList().Select(b => new BiletForRaportCsv
            {
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
            });

            //obiekt trzymający dane z raportu
            var r = ObliczRaportSprzedazy(idFilmu,dataOd,dataDo);


            //tworzy okienko do zapisania nowego pliku
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Plik CSV (*.csv)|*.csv"; // ustawia formaty pliku do wybrania
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // ustawia defaultowa lokalizacje zapisywania pliku
            saveDialog.ShowDialog(); //wyswietla okienko

            //sprawdza czy nazwa pliku nie jest pusta, np w przypadku klikniecia anuluj w okienku, wtedy probowalo stworzyc StreamWritera bez sciezki i wywalalo
            if(!String.IsNullOrEmpty(saveDialog.FileName))
            {
                //tworzy plik na sciezce wybranej w saveDialog , pole saveDialog.FileName zawiera pelna sciezke do wybranego pliku
                using (var writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
                    {

                        csv.WriteField("Raport sprzedaży biletów");

                        csv.NextRecord();
                        csv.WriteField("Okres sprzedaży: ");
                        csv.WriteField(dataOd);
                        csv.WriteField(dataDo);

                        csv.NextRecord();
                        csv.WriteField("Film: ");
                        csv.WriteField(idFilmu != null ? biletyDoRaportu.Select(b => b.NazwaSeansu).FirstOrDefault() : "Wszystkie filmy");

                        csv.NextRecord();
                        csv.WriteHeader<RaportSprzedazyDTO>();
                        csv.NextRecord();
                        csv.WriteRecord(r);

                        csv.NextRecord();
                        csv.NextRecord();
                        csv.WriteField("Wszystkie bilety");
                        csv.NextRecord();
                        csv.WriteHeader<BiletForRaportCsv>();
                        csv.NextRecord();
                        csv.WriteRecords(biletyDoRaportu);


                    }
                }
            }
          
            

        }

        //metoda zwracajaca kolekcje biletów dla raportu związanych z konkretnym filmem lub z zadnym, w danym przedziale czasowym
        private IQueryable<Bilet> getBiletyDoRaportu(int? idFilmu, DateTime dataOd, DateTime dataDo)
        {
           var bilety = kinoEntities.Bilet.Where(b =>
           b.CzyAktywny == true &&
           b.CzyAnulowany == false &&
           b.DataSprzedazy >= dataOd &&
           b.DataSprzedazy <= dataDo &&
           b.CzyOplacony == true);

            if (idFilmu != null)
            {
                bilety = bilety.Where(b => b.Seans.Film.IdFilmu == idFilmu);
            }

            return bilety;

        }
      
        #endregion

    }
}
