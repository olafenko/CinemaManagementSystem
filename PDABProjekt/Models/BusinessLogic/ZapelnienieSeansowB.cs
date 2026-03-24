using CsvHelper;
using Microsoft.Win32;
using PDABProjekt.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDABProjekt.Models.BusinessLogic
{
    // klasa biznesowa 
    public class ZapelnienieSeansowB : DatabaseClass
    {
        #region Konstruktor
        public ZapelnienieSeansowB(PABProjektEntities kinoEntities) : base(kinoEntities)
        {
        }

        #endregion

        #region Funkcje binzesowe

        //funkcja zwracająca kolekcje raportow dla kazdego rekordu seansu pokrywajacego sie z parametrami

        public List<RaportZapelnieniaSeansowDTO> GenerujDaneWypelnieniaSeansow(DateTime data)
        {
                     
            return kinoEntities.Seans.Where(s =>
            s.DataSeansu == data &&
            s.Sala.LiczbaMiejsc > 0
            ).Select(r => new RaportZapelnieniaSeansowDTO
            {

                TytulSeansu = r.Film.Tytul,
                GodzinaOd = r.GodzinaOd,
                GodzinaDo = r.GodzinaDo,
                LiczbaMiejsc = r.Sala.LiczbaMiejsc,
                LiczbaZajetychMiejsc = r.Bilet.Where(b => b.CzyAktywny && !b.CzyAnulowany && b.CzyOplacony).Count(),
                ProcentWypelnienia = ((decimal?)r.Bilet.Where(b => b.CzyAktywny && !b.CzyAnulowany && b.CzyOplacony).Count() / r.Sala.LiczbaMiejsc),
                StatusWypelnienia = ((decimal?)r.Bilet.Where(b => b.CzyAktywny && !b.CzyAnulowany && b.CzyOplacony).Count() / r.Sala.LiczbaMiejsc) * 100 < 30 ? "Słabe" :
                                    ((decimal?)r.Bilet.Where(b => b.CzyAktywny && !b.CzyAnulowany && b.CzyOplacony).Count() / r.Sala.LiczbaMiejsc) * 100 < 65 ? "Średnie" : "Dobre"

            }).OrderBy(r => r.GodzinaOd).ToList();
                  
        }

        public void EksportujRaportDoCsv(DateTime data)
        {

            var daneRaportu = GenerujDaneWypelnieniaSeansow(data);

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

                        csv.WriteField("Raport wypełnienia seansów");

                        csv.NextRecord();
                        csv.WriteField("Dla dnia: ");
                        csv.WriteField(data);

                        csv.NextRecord();
                        csv.WriteHeader<RaportZapelnieniaSeansowDTO>();
                        csv.NextRecord();
                        csv.WriteRecords(daneRaportu);

                    }
                }
            }


        }


        #endregion


    }
}

