using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validatory;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class KlientAutoViewModel : JedenViewModel<Kontrahenci>,IDataErrorInfo
    {
        #region Constructor
        public KlientAutoViewModel()
        : base()
        {
            base.DisplayName = "Nowy Komis";
            item = new Kontrahenci();
            itemAdresKontrahenta = new AdresyKontrahentow();
            itemPojazdy = new Pojazdy();
            ItemPozycjeFaktury = new PozycjeFaktury();
            ItemFaktury = new Faktury();
            Messenger.Default.Register<PojazdyForAllView>(this, getPojazdDoUmowy);

            FakturaDataPlatnosci = DateTime.Now;
            FakturaDataSprzedazy = DateTime.Now;
            FakturaDataWystawienia = DateTime.Now;
            FakturaTerminPlatnosci = DateTime.Now;
        }

        #endregion 


        #region Fields

        private BaseCommand _ZapiszDaneKlienta;
        private AdresyKontrahentow itemAdresKontrahenta;
        private Pojazdy itemPojazdy;
        private PozycjeFaktury ItemPozycjeFaktury;
        private Faktury ItemFaktury;
        
       
        #endregion Fields


        #region Command
        //to jest komenda ktora zostanie podpieta pod przycisk zapisu
        public ICommand ZapiszDaneKlienta
        {
            get
            {
                if (_ZapiszDaneKlienta == null)
                    _ZapiszDaneKlienta = new BaseCommand(() => zapiszKlienta()); //ta komenda wywola metode saveAndClose() ktora zapisze rekod i zamknie zakladke
                return _ZapiszDaneKlienta;
            }
        }


        #endregion Command

        #region Properties

       

        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (value == item.Imie)
                    return;
                item.Imie = value;
                base.OnPropertyChanged(() => Imie );
            }
        }

        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (value == item.Nazwisko)
                    return;
                item.Nazwisko = value;
                base.OnPropertyChanged(() => Nazwisko);
            }
        }
        
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (value == item.Nazwa)
                    return;
                item.Nazwa = value;
                base.OnPropertyChanged(() => Nazwa);
            }
        }
                
        public string Telefon1
        {
            get
            {
                return item.Telefon1;
            }
            set
            {
                if (value == item.Telefon1)
                    return;
                item.Telefon1 = value;
                base.OnPropertyChanged(() => Telefon1);
            }
        }
                        
        public string Email1
        {
            get
            {
                return item.Email1;
            }
            set
            {
                if (value == item.Email1)
                    return;
                item.Email1 = value;
                base.OnPropertyChanged(() => Email1);
            }
        }
                                
        public string PESEL
        {
            get
            {
                return item.PESEL;
            }
            set
            {
                if (value == item.PESEL)
                    return;
                item.PESEL = value;
                base.OnPropertyChanged(() => PESEL);
            }
        }
                                        
        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (value == item.NIP)
                    return;
                item.NIP = value;
                base.OnPropertyChanged(() => NIP);
            }
        }
                                                
        public string REGON
        {
            get
            {
                return item.REGON;
            }
            set
            {
                if (value == item.REGON)
                    return;
                item.REGON = value;
                base.OnPropertyChanged(() => REGON);
            }
        }
                                                        
        public string Adnotacje
        {
            get
            {
                return item.Adnotacje;
            }
            set
            {
                if (value == item.Adnotacje)
                    return;
                item.Adnotacje = value;
                base.OnPropertyChanged(() => Adnotacje);
            }
        }

        //klucze obce

        //adres

        public int? IdKontrahenta
        {
            get
            {
                return itemAdresKontrahenta.IdKontrahenta;
            }
            set
            {
                if (value == itemAdresKontrahenta.IdKontrahenta)
                    return;
                itemAdresKontrahenta.IdKontrahenta = value;
            //    base.OnPropertyChanged(() => IdKontrahenta);
            }
        }
        
        public string Kraj
        {
            get
            {
                return itemAdresKontrahenta.Kraj;
            }
            set
            {
                if (value == itemAdresKontrahenta.Kraj)
                    return;
                itemAdresKontrahenta.Kraj = value;
                base.OnPropertyChanged(() => Kraj);
            }
        }
        
        public string Miasto
        {
            get
            {
                return itemAdresKontrahenta.Miasto;
            }
            set
            {
                if (value == itemAdresKontrahenta.Miasto)
                    return;
                itemAdresKontrahenta.Miasto = value;
                base.OnPropertyChanged(() => Miasto);
            }
        }
                
        public string Ulica
        {
            get
            {
                return itemAdresKontrahenta.Ulica;
            }
            set
            {
                if (value == itemAdresKontrahenta.Ulica)
                    return;
                itemAdresKontrahenta.Ulica = value;
                base.OnPropertyChanged(() => Ulica);
            }
        }
                        
        public string KodPocztowy
        {
            get
            {
                return itemAdresKontrahenta.KodPocztowy;
            }
            set
            {
                if (value == itemAdresKontrahenta.KodPocztowy)
                    return;
                itemAdresKontrahenta.KodPocztowy = value;
                base.OnPropertyChanged(() => KodPocztowy);
            }
        }
                                
        public string NrDomu
        {
            get
            {
                return itemAdresKontrahenta.NrDomu;
            }
            set
            {
                if (value == itemAdresKontrahenta.NrDomu)
                    return;
                itemAdresKontrahenta.NrDomu = value;
                base.OnPropertyChanged(() => NrDomu);
            }
        }
                
        public string NrLokalu
        {
            get
            {
                return itemAdresKontrahenta.NrLokalu;
            }
            set
            {
                if (value == itemAdresKontrahenta.NrLokalu)
                    return;
                itemAdresKontrahenta.NrLokalu = value;
                base.OnPropertyChanged(() => NrLokalu);
            }
        }
       //pojazd id          

        public string PokazAutoDlaKlienta { get; set; }
        public string PokazAutoDlaKlientaFoto { get; set; }
        public decimal? PokazAutoDlaKlientaCena { get; set; }

        //pozycje Faktury

        public string PozycjeFakturyNazwa
        {
            get
            {
                return ItemPozycjeFaktury.Nazwa;
            }
            set
            {
                if (value == ItemPozycjeFaktury.Nazwa)
                    return;
                ItemPozycjeFaktury.Nazwa = value;
                //base.OnPropertyChanged(() => Nazwa);
            }
        }

        public int? PozycjeFakturyIdPojazdu
        {
            get
            {
                return ItemPozycjeFaktury.IdPojazdu;
            }
            set
            {
                if (value == ItemPozycjeFaktury.IdPojazdu)
                    return;
                ItemPozycjeFaktury.IdPojazdu = value;
                //OnPropertyChanged(() => IdPojazdu);
            }
        }
        
        public decimal? PozycjeFakturyCena
        {
            get
            {
                return ItemPozycjeFaktury.Cena;
            }
            set
            {
                if (value == ItemPozycjeFaktury.Cena)
                    return;
                ItemPozycjeFaktury.Cena = value;
                //OnPropertyChanged(() => Cena);
            }
        }

        // Faktury     
        // ******************************************* NOWE ********************************
        public int? FakturyIdNabywca
        {
            get
            {
                return ItemFaktury.IdNabywca;
            }
            set
            {
                if (value == ItemFaktury.IdNabywca)
                    return;
                ItemFaktury.IdNabywca = value;
                //OnPropertyChanged(() => Cena);
            }
        }
                                                
        public int? FakturyIdPozycjeFaktury
        {
            get
            {
                return ItemFaktury.IdPozycjeFaktury;
            }
            set
            {
                if (value == ItemFaktury.IdPozycjeFaktury)
                    return;
                ItemFaktury.IdPozycjeFaktury = value;
                //OnPropertyChanged(() => Cena);
            }
        }

        public int? FakturaIdRodzajPlatnosci
        {
            get
            {
                return ItemFaktury.IdRodzajPlatnosci;
            }
            set
            {
                if (value == ItemFaktury.IdRodzajPlatnosci)
                    return;
                ItemFaktury.IdRodzajPlatnosci = value;
            }
        }
        public IQueryable<ComboBoxKeyAndValue> RodzajPlatnosciComboBoxItems
        {
            get
            {
                return
                    (
                        from RodzajePlatnosci in komisEntities.RodzajePlatnosci //Dla kazdego kontrahenta z bazy danych Kontrahentow                  
                        select new ComboBoxKeyAndValue  //Tworzymy ComboboxKeyAndValue
                        {
                            Key = RodzajePlatnosci.IdRodzajuPlatnosci,
                            Value = RodzajePlatnosci.nazwa // + " " + kontrahent.NIP + " " + kontrahent.Imie
                        }
                    ).ToList().AsQueryable();
            }
        }

        public int? FakturaIdPracownikaWystawiajacego
        {
            get
            {
                return ItemFaktury.IdPracownikaWystawiajacego;
            }
            set
            {
                if (value == ItemFaktury.IdPracownikaWystawiajacego)
                    return;
                ItemFaktury.IdPracownikaWystawiajacego = value;
            }
        }


        public IQueryable<ComboBoxKeyAndValue> PracownikWystawilComboBoxItems
        {
            get
            {
                return
                    (
                        from pracownicy in komisEntities.Pracownicy //Dla kazdego kontrahenta z bazy danych Kontrahentow                  
                        select new ComboBoxKeyAndValue  //Tworzymy ComboboxKeyAndValue
                        {
                            Key = pracownicy.IdPracownika,
                            Value = pracownicy.Imie + " " + pracownicy.Nazwisko + " / " + pracownicy.Stanowisko
                        }
                    ).ToList().AsQueryable();
            }
        }


        public IQueryable<ComboBoxKeyAndValue> PracownikZatwierdzilComboBoxItems
        {
            get
            {
                return
                    (
                        from pracownicy in komisEntities.Pracownicy //Dla kazdego kontrahenta z bazy danych Kontrahentow                  
                        select new ComboBoxKeyAndValue  //Tworzymy ComboboxKeyAndValue
                        {
                            Key = pracownicy.IdPracownika,
                            Value = pracownicy.Imie + " " + pracownicy.Nazwisko + " / " + pracownicy.Stanowisko
                        }
                    ).ToList().AsQueryable();
            }
        }

        public int? IdPracownikaSprawdzajacego
        {
            get
            {
                return ItemFaktury.IdPracownikaSprawdzajacego;
            }
            set
            {
                if (value == ItemFaktury.IdPracownikaSprawdzajacego)
                    return;
                ItemFaktury.IdPracownikaSprawdzajacego = value;
            }
        }

        public string FakturaMiejscowosc
        {
            get
            {
                return ItemFaktury.Miejscowosc;
            }
            set
            {
                if (value == ItemFaktury.Miejscowosc)
                    return;
                ItemFaktury.Miejscowosc = value;
            }
        }

        public DateTime? FakturaTerminPlatnosci
        {
            get
            {
                return ItemFaktury.TerminPlatnosci;
            }
            set
            {
                if (ItemFaktury.TerminPlatnosci != value)
                {
                    ItemFaktury.TerminPlatnosci = value;
                }
            }
        }
        
        public DateTime? FakturaDataSprzedazy
        {
            get
            {
                return ItemFaktury.DataSprzedazy;
            }
            set
            {
                if (ItemFaktury.DataSprzedazy != value)
                {
                    ItemFaktury.DataSprzedazy = value;
                }
            }
        }
                
        public DateTime? FakturaDataPlatnosci
        {
            get
            {
                return ItemFaktury.DataPlatnosci;
            }
            set
            {
                if (ItemFaktury.DataPlatnosci != value)
                {
                    ItemFaktury.DataPlatnosci = value;
                }
            }
        }  
        
        public DateTime? FakturaDataWystawienia
        {
            get
            {
                return ItemFaktury.DataWystawienia;
            }
            set
            {
                if (ItemFaktury.DataWystawienia != value)
                {
                    ItemFaktury.DataWystawienia = value;
                }
            }
        }
                
        public string FakturyAdnotacje
        {
            get
            {
                return ItemFaktury.Adnotacje;
            }
            set
            {
                if (ItemFaktury.Adnotacje != value)
                {
                    ItemFaktury.Adnotacje = value;
                }
            }
        }
                        
        public int? FakturaNumerFaktury
        {
            get
            {
                return ItemFaktury.NumerFaktury;
            }
            set
            {
                if (ItemFaktury.NumerFaktury != value)
                {
                    ItemFaktury.NumerFaktury = value;
                }
            }
        }

        //********************************** KONIEC NOWA FAKTURA ****************************

        #endregion //Properties



        #region Helpers

        public override void Save()
        {
            item.IdAdresuKontrahenta = item.IdKontrahenta;
            komisEntities.AdresyKontrahentow.Add(itemAdresKontrahenta);
            komisEntities.Kontrahenci.Add(item);
            Messenger.Default.Send<Kontrahenci>(item);
            Messenger.Default.Send<AdresyKontrahentow>(itemAdresKontrahenta);
            ItemFaktury.IdNabywca = item.IdKontrahenta;
            komisEntities.PozycjeFaktury.Add(ItemPozycjeFaktury);
            ItemFaktury.IdPozycjeFaktury = ItemPozycjeFaktury.IdPozycjiFaktury;
            komisEntities.Faktury.Add(ItemFaktury);

            komisEntities.SaveChanges();
        }

        public void OznaczJakoSprzedane()
        {

            //p = komisEntities.Pojazdy.Find(p.CzyPozycjaAktualna);
            //p.CzyPozycjaAktualna = false;

            //Uzytkownicy uzytkownik = pcmarketEntities.Uzytkownicy.Find(Wybrany.IdUzytkownika);
            //uzytkownik.CzyAktywny = false;
            //pcmarketEntities.SaveChanges();
            //load();
        }

        private void zapiszKlienta()
        {
            Messenger.Default.Send("Pojazd KlientAuto");
        }

        private void getPojazdDoUmowy(PojazdyForAllView obj)
        {

            PokazAutoDlaKlienta = obj.PojazdMarka + " " + obj.PojazdModel + ", rok:" + obj.RokProdukcji.ToString().Remove(4) + ", VIM: " + obj.NrVIN;
            PokazAutoDlaKlientaFoto = obj.PojazdUrl;
            PokazAutoDlaKlientaCena = obj.PojazdCena;
            PozycjeFakturyCena = obj.PojazdCena;
            PozycjeFakturyIdPojazdu = obj.IdPojazdu;
            PozycjeFakturyNazwa = PokazAutoDlaKlienta;

        }

        #endregion Helpers


        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        //tutaj decydujemy ktore pola walidowac czyli przy ktorych polach jak zle cos wpiszemy
        //wyrzucac blad
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "FakturaMiejscowosc")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.FakturaMiejscowosc);
                }
                if (name == "PESEL")
                {
                    komunikat = BusinessValidator.isValidEmail(this.PESEL);
                }
                return komunikat;
            }
        }
        //w tej funkcji okreslamy ktore pola musza byc poprawnie wprowadzone 
        //zeby dalo sie zapisac towar
        public override bool IsValid()
        {
            if (this["StawkaVatSprzedazy"] == null
                && this["StawkaVatZakupu"] == null)
                return true;
            return false;
        }
        #endregion Validation

    }
}