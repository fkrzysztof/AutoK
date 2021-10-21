using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Model.EntitiesForView;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.ViewModels.Abstract;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahenciForAllView>
    {
        #region Constructor
        public WszyscyKontrahenciViewModel()
        : base()
        {
            base.DisplayName = "Wszyscy Kontrahenci";
        }
        #endregion  Constructor
        #region Properties 
        private KontrahenciForAllView _WybranyKontrahent;
        public KontrahenciForAllView WybranyKontrahent
        {
            get { return _WybranyKontrahent; }
            set
            {
                if (_WybranyKontrahent != value)
                {
                    _WybranyKontrahent = value;
               //     ShowMessageBoxInformation("Kontrahent: " + _WybranyKontrahent.Nazwa + " " + _WybranyKontrahent.PESEL);
                    Messenger.Default.Send(_WybranyKontrahent);
                    onRequestClose();
                }
            }
        }

        #endregion  Properties
        
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KontrahenciForAllView>
            (
            from kontrahent in komisEntities.Kontrahenci
            select new KontrahenciForAllView
            {
                IdKontrahenta = kontrahent.IdKontrahenta,
                Imie = kontrahent.Imie,
                Nazwa = kontrahent.Nazwa,
                OsobaKontaktowa = kontrahent.OsobaKontaktowa,
                PESEL = kontrahent.PESEL,
                NIP = kontrahent.NIP,
                REGON = kontrahent.REGON,
                Telefon1 = kontrahent.Telefon1,
                Telefon2 = kontrahent.Telefon2,
                Email1 = kontrahent.Email1,
                Email2 = kontrahent.Email2,
                RachunekBankowy = kontrahent.RachunekBankowy,
                Dostawca = kontrahent.Dostawca,
                Adnotacje = kontrahent.Adnotacje,

                //klucze obce
                KonKodPocztowy = kontrahent.AdresyKontrahentow1.KodPocztowy,
                KonKraj = kontrahent.AdresyKontrahentow1.Kraj,
                KonMiasto = kontrahent.AdresyKontrahentow1.Miasto,
                KonUlica = kontrahent.AdresyKontrahentow1.Ulica,
                KonNrDomu = kontrahent.AdresyKontrahentow1.NrDomu,
                KonNrLokalu = kontrahent.AdresyKontrahentow1.NrLokalu
                
                //Id = kontrahent.id,
                //Kod = kontrahent.kod,
                //Nip = kontrahent.nip,
                //Nazwa = kontrahent.nazwa,
                //RodzajNazwa = kontrahent.Rodzaje.nazwa,
                //StatusNazwa = kontrahent.Statusy.nazwa
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