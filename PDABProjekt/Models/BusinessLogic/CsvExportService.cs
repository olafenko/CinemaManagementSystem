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
using System.Windows.Markup;

namespace PDABProjekt.Models.BusinessLogic
{
    public class CsvExportService
    {

        public void Export()
        {

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
                    //tworzy obiekt który zapisuje do pliku w formacie csv
                    using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
                    {

                      

                    }
                }
            }


        }


    }
}
