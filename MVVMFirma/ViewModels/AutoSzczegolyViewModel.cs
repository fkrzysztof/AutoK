using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;

namespace MVVMFirma.ViewModels
{
    class AutoSzczegolyViewModel : JedenViewModel<PojazdyForAllView>
    {
        #region Constructor
        public AutoSzczegolyViewModel()
        : base()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Faktura";
            //tworzymy nowy pusty obiekt biznesowy
            //this.item = new Faktury();
            Messenger.Default.Register<PojazdyForAllView>(this, getWybranyPojazd);
            MarkaPojazdu = "ISUZU";
        }

        #endregion Constructor


        #region Properties
        //dla kazdego pola na interfejsie edytowalnego tworzymy propertisa z standardowym kodem

        public string MarkaPojazdu { get; set; }
        private string _PojazdMarka;
        public string PojazdMarka
        {
            get
            {
                return _PojazdMarka;
            }
            set
            {
                if (value == _PojazdMarka)
                    return;
                _PojazdMarka = value;
                //base.OnPropertyChanged(() => PojazdMarka);
                OnPropertyChanged(() => PojazdMarka);
            }
        }
        #endregion Properties

        #region Helpers
        private void getWybranyPojazd(PojazdyForAllView pojazd)
        {
            //IdNabywca = kontrahent.IdKontrahenta;
            //KontrahentDane = kontrahent.Nazwa + " " + kontrahent.Nazwisko + " " + kontrahent.Imie;
            PojazdMarka = pojazd.PojazdMarka;
        }

        // nie weim
        //to jest metoda ktora zapisuje rekod
        public override void Save()
        {
            //najpierw dodajemy nowy rekord do lokalnej kolekcji
            //komisEntities.Faktury.Add(item);
            //nastepnie zapisujemy zmiany w bazie danych
            //   komisEntities.SaveChanges();
        }
        #endregion Helpers



    }
}
