using System.Linq;
using System.Collections.ObjectModel;
using MVVMFirma.Model.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using MVVMFirma.Models.EntitiesForView;
using System.Collections.Generic;

namespace MVVMFirma.ViewModels
{
    internal class WszystkiePracownicyViewModel : WszystkieViewModel<PracownicyForAllView>
    {
        #region Constructor
        public WszystkiePracownicyViewModel()
        : base()
        {
            base.DisplayName = "Pracownicy";
        }
        #endregion // Constructor
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PracownicyForAllView>
            (
            from pracownicy  in komisEntities.Pracownicy
            select new PracownicyForAllView
            {
                IdPracownika = pracownicy.IdPracownika,
                Stanowisko = pracownicy.Stanowisko,
                Imie = pracownicy.Imie,
                Nazwisko = pracownicy.Nazwisko,
                DataUrodzenia = pracownicy.DataUrodzenia,
                PESEL = pracownicy.PESEL,
                Telefon1 = pracownicy.Telefon1,
                Telefon2 = pracownicy.Telefon2,
                Email = pracownicy.Email,
                DataRozpoczeciaPracy = pracownicy.DataRozpoczeciaPracy,
                DataZakonczenia = pracownicy.DataZakonczenia,

                //klucze obce
                AdresyKraj = pracownicy.AdresyPracownikow.Kraj,
                AdresyMiasto = pracownicy.AdresyPracownikow.Miasto,
                AdresyUlica = pracownicy.AdresyPracownikow.Ulica,
                AdresyNrDomu = pracownicy.AdresyPracownikow.NrDomu,
                AdresyNrLokalu = pracownicy.AdresyPracownikow.NrLokalu,
                AdresyKodPocztowy = pracownicy.AdresyPracownikow.KodPocztowy


            }
            );
        }
        #endregion //Helpers
        #region SortAndFind
        //w tej funkcji decydujemy jak sortowac
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Nazwisko));
            if (SortField == "Kod")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.AdresyKodPocztowy));
          //  if (SortField == "Cena")
             //   List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.AdresyNrDomu));
        }
        //w tej funkcji decydujemy po jakich kolumnach sortowac
        public override List<string> GetComboboxSortList()
        {
            return new List<string>
            {
                "Nazwa","Kod","Cena"
            };
        }
        //w tej funkcji decydujemy jak wyszukiwac
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.Nazwisko != null
                && item.Nazwisko.StartsWith(FindTextBox)));
            }
            if (FindField == "Kod")
            {
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.AdresyKodPocztowy != null
                && item.AdresyKodPocztowy.StartsWith(FindTextBox)));
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