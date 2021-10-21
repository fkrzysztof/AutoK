using System.Linq;
using System.Collections.ObjectModel;
using MVVMFirma.Model.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturyForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
        : base()
        {
            base.DisplayName = "Wszystkie faktury";
        }
        #endregion // Constructor
    
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<FakturyForAllView>
            (
            from faktura in komisEntities.Faktury
            select new FakturyForAllView
                {
                       IdFaktury = faktura.IdFaktury,
                       DataWystawienia = faktura.DataWystawienia,
                       Miejscowosc = faktura.Miejscowosc,
                       DataSprzedazy = faktura.DataSprzedazy,
                       DataPlatnosci = faktura.DataPlatnosci,
                       TerminPlatnosci = faktura.TerminPlatnosci,
                       NumerFaktury = faktura.NumerFaktury,
                       NumerRachunkuBankowego = faktura.NumerRachunkuBankowego,
                       Adnotacje = faktura.Adnotacje,

                       KontrahentKodPocztowy = faktura.Kontrahenci.AdresyKontrahentow1.KodPocztowy,
                       KontrahentKraj = faktura.Kontrahenci.AdresyKontrahentow1.Kraj,
                       KontrahentMiasto = faktura.Kontrahenci.AdresyKontrahentow1.Miasto,

                       KontrahentNazwa = faktura.Kontrahenci.Nazwa,
                       KontrahentImie = faktura.Kontrahenci.Imie,
                       KontrahentNazwisko = faktura.Kontrahenci.Nazwisko,
                       KontrahentDostawca = faktura.Kontrahenci.Dostawca,
                       
                       
                       // pracownik 1 - dyrektor pracownik 2 - sprzedawca
                       PracownikWystawiajacyImie = faktura.Pracownicy.Imie,
                       PracownikWystawiajacyNazwisko = faktura.Pracownicy.Nazwisko,
                       PracownikZatwierdzajacyImie = faktura.Pracownicy1.Imie,
                       PracownikZatwierdzajacyNazwisko = faktura.Pracownicy1.Nazwisko,

                       RodzajPlatnosciNazwa = faktura.RodzajePlatnosci.nazwa



                }
            );
        }
        #endregion //Helpers

        #region SortAndFind
        //w tej funkcji decydujemy jak sortowac
        public override void Sort()
        {
              if (SortField == "Nazwa")
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(item => item.KontrahentNazwa));
            if (SortField == "Kod")
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(item => item.KontrahentKodPocztowy));
            if (SortField == "OsobaKontaktowa")
                List = new ObservableCollection<FakturyForAllView>(List.OrderBy(item => item.KontrahentImie));
        }
        //w tej funkcji decydujemy po jakich kolumnach sortowac
        public override List<string> GetComboboxSortList()
        {
            return new List<string>
            {
                "Nazwa","Kod","OsobaKontaktowa"
            };
        }
        //w tej funkcji decydujemy jak wyszukiwac
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(item => item.KontrahentNazwa != null
                && item.KontrahentNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Kod")
            {
                List = new ObservableCollection<FakturyForAllView>(List.Where(item => item.KontrahentKodPocztowy != null
                && item.KontrahentKodPocztowy.StartsWith(FindTextBox)));
            }
        }
        //w tej funkcji decydujemy po jakich kolumnach mozna wyszukiwac
        public override List<string> GetComboboxFindList()
        {
            return new List<string>
            {
                "Nazwa","Kod"
            };
        }
        #endregion SortAndFind
    }
}