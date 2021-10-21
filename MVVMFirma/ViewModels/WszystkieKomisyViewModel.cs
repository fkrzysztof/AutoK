using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
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
    internal class WszystkieKomisyViewModel : WszystkieViewModel<KomisyForAllView>
    {
        #region Constructor
        public WszystkieKomisyViewModel()
        : base()
        {
            base.DisplayName = "Wszystkie Komisy";
        }
        #endregion // Constructor
        
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<KomisyForAllView>
            (
            from komisy in komisEntities.Komisy
            select new KomisyForAllView
            {
             IdKomisu = komisy.IdKomisu,
             OsobaKontaktowa = komisy.OsobaKontaktowa,
             NrKomisu = komisy.NrKomisu,
             NazwaKomisu = komisy.NazwaKomisu,
             Telefon1 = komisy.Telefon1,
             Telefon2 = komisy.Telefon2,
             Email1 = komisy.Email1,
             Email2 = komisy.Email2,
             DataDodania = komisy.DataDodania,
             Adnotacje = komisy.Adnotacje,
             //klucze obce

             KomisKraj = komisy.AdresyKomisow.Kraj,
             KomisMiasto = komisy.AdresyKomisow.Miasto,
             KomisUlica = komisy.AdresyKomisow.Ulica,
             KomisNrDomu = komisy.AdresyKomisow.NrDomu,
             KomisNrLokalu = komisy.AdresyKomisow.NrLokalu,
             KomisKodPocztowy = komisy.AdresyKomisow.KodPocztowy


    }
            );
        }
        #endregion //Helpers

        #region SortAndFind
        //w tej funkcji decydujemy jak sortowac
        public override void Sort()
        {
          //  if (SortField == "Nazwa")
            //    List = new ObservableCollection<Komisy>(List.OrderBy(item => item.NazwaKomisu));
            if (SortField == "Kod")
                List = new ObservableCollection<KomisyForAllView>(List.OrderBy(item => item.KomisKodPocztowy));
            if (SortField == "OsobaKontaktowa")
            {
                List = new ObservableCollection<KomisyForAllView>(List.OrderBy(item => item.OsobaKontaktowa));
                List = new ObservableCollection<KomisyForAllView>(List.Where(item => item.NrKomisu == "1"));

            }
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
                List = new ObservableCollection<KomisyForAllView>(List.Where(item => item.NazwaKomisu != null
                && item.NazwaKomisu.StartsWith(FindTextBox)));
            }
            if (FindField == "Kod")
            {
                List = new ObservableCollection<KomisyForAllView>(List.Where(item => item.KomisKodPocztowy != null
                && item.KomisKodPocztowy.StartsWith(FindTextBox)));
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
