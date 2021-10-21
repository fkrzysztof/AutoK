using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    class WszyscyDostawcyViewModel : WszystkieViewModel<KontrahenciForAllView>
    {
        #region Constructor
        public WszyscyDostawcyViewModel()
        : base()
        {
            base.DisplayName = "Wszystkie faktury";
        }
        #endregion // Constructor
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KontrahenciForAllView>
            (
            from kontrahenci in komisEntities.Kontrahenci
            where kontrahenci.Dostawca == true
            select new KontrahenciForAllView
            {
                IdKontrahenta = kontrahenci.IdKontrahenta,
                Imie = kontrahenci.Imie,
                Nazwisko = kontrahenci.Nazwisko,
                Nazwa = kontrahenci.Nazwa,
                OsobaKontaktowa = kontrahenci.OsobaKontaktowa,
                PESEL = kontrahenci.PESEL,
                NIP = kontrahenci.NIP,
                REGON = kontrahenci.REGON,
                Telefon1 = kontrahenci.Telefon1,
                Telefon2 = kontrahenci.Telefon2,
                Email1 = kontrahenci.Email1,
                Email2 = kontrahenci.Email2,
                RachunekBankowy = kontrahenci.RachunekBankowy,
                Adnotacje = kontrahenci.Adnotacje,

                KonKraj = kontrahenci.AdresyKontrahentow1.Kraj,
                KonMiasto = kontrahenci.AdresyKontrahentow1.Miasto,
                KonUlica = kontrahenci.AdresyKontrahentow1.Ulica,
                KonNrDomu = kontrahenci.AdresyKontrahentow1.NrDomu,
                KonNrLokalu = kontrahenci.AdresyKontrahentow1.NrLokalu,
                KonKodPocztowy = kontrahenci.AdresyKontrahentow1.KodPocztowy

            }
            );
        }
        #endregion //Helpers
        #region SortAndFind
        //w tej funkcji decydujemy jak sortowac
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Kod")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.KonKodPocztowy));
            if (SortField == "OsobaKontaktowa")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.Imie));
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
                //    List = new ObservableCollection<FakturyForAllView>(List.Where(item => item.Nazwa != null
                //      && item.Nazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Kod")
            {
                //     List = new ObservableCollection<FakturyForAllView>(List.Where(item => item.KonKodPocztowy != null
                //      && item.KonKodPocztowy.StartsWith(FindTextBox)));
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