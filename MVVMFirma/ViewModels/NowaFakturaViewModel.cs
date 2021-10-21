using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;

namespace MVVMFirma.ViewModels
{
    class NowaFakturaViewModel : JedenViewModel<Faktury> //pod typ generyczny T podstawiono typ Faktury
    {
        #region Fields 
        private BaseCommand _ShowKontrahenci; 
        #endregion Fields

        #region Construktor
        public NowaFakturaViewModel()
            : base()
        {
            base.DisplayName = "Faktura";
            //tworzymy nowy pusty obiekt biznesowy
            this.item = new Faktury();
            Messenger.Default.Register<KontrahenciForAllView>(this, getWybranyKontrahent);
        }
        #endregion Constructor

        #region Command 
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                {
                    _ShowKontrahenci = new BaseCommand(() => Messenger.Default.Send("Kontrahenci Show"));
                }

            return _ShowKontrahenci; }
        }
        #endregion Command

        #region Properties
        //dla kazdego pola na interfejsie edytowalnego tworzymy propertisa z standardowym kodem


        private string _KontrahentDane;
        public string KontrahentDane
        {
            get
            {
                return _KontrahentDane;
            }
            set
            {
                if (value == _KontrahentDane)
                    return; _KontrahentDane = value;
                base.OnPropertyChanged(() => _KontrahentDane);
            }
        }

        public string Miejscowosc
        {
            get
            {
                return item.Miejscowosc;
            }
            set
            {
                if (value == item.Miejscowosc)
                    return;
                item.Miejscowosc = value;
                base.OnPropertyChanged(() => Miejscowosc);
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
      
        public string NumerRachunkuBankowego
        {
            get
            {
                return item.NumerRachunkuBankowego;
            }
            set
            {
                if (value == item.NumerRachunkuBankowego)
                    return;
                item.NumerRachunkuBankowego = value;
                base.OnPropertyChanged(() => NumerRachunkuBankowego);
            }
        }

        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
        
        public DateTime? DataPlatnosci
        {
            get
            {
                return item.DataPlatnosci;
            }
            set
            {
                if (item.DataPlatnosci != value)
                {
                    item.DataPlatnosci = value;
                    OnPropertyChanged(() => DataPlatnosci); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
        
        public DateTime? DataSprzedazy
        {
            get
            {
                return item.DataSprzedazy;
            }
            set
            {
                if (item.DataSprzedazy != value)
                {
                    item.DataSprzedazy = value;
                    OnPropertyChanged(() => DataSprzedazy); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }

        public int? IdNabywca
        {
            get
            {
                return item.IdNabywca;
            }
            set
            {
                if (value == item.IdNabywca)
                    return;
                item.IdNabywca = value;
                base.OnPropertyChanged(() => IdNabywca);
            }
        }
  
        public int? NumerFaktury
        {
            get
            {
                return item.NumerFaktury;
            }
            set
            {
                if (value == item.NumerFaktury)
                    return;
                item.NumerFaktury = value;
                base.OnPropertyChanged(() => NumerFaktury);
            }
        }
        
        public int? IdPracownikaSprawdzajacego
        {
            get
            {
                return item.IdPracownikaSprawdzajacego;
            }
            set
            {
                if (value == item.IdPracownikaSprawdzajacego)
                    return;
                item.IdPracownikaSprawdzajacego = value;
                base.OnPropertyChanged(() => IdPracownikaSprawdzajacego);
            }
        }
                
        public int? IdPracownikaWystawiajacego
        {
            get
            {
                return item.IdPracownikaWystawiajacego;
            }
            set
            {
                if (value == item.IdPracownikaWystawiajacego)
                    return;
                item.IdPracownikaWystawiajacego = value;
                base.OnPropertyChanged(() => IdPracownikaWystawiajacego);
            }
        }   
        
        public int? IdRodzajPlatnosci
        {
            get
            {
                return item.IdRodzajPlatnosci;
            }
            set
            {
                if (value == item.IdRodzajPlatnosci)
                    return;
                item.IdRodzajPlatnosci = value;
                base.OnPropertyChanged(() => IdRodzajPlatnosci);
            }
        }

        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
 

        //Kontrahenta bedziemy wybierac przez wybor w ComboBoxie
        //Tworzymy zatem standardowy kod ComboBoxa

        public IQueryable<ComboBoxKeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return
                    (
                        from kontrahent in komisEntities.Kontrahenci //Dla kazdego kontrahenta z bazy danych Kontrahentow                  
                        select new ComboBoxKeyAndValue  //Tworzymy ComboboxKeyAndValue
                        {
                            Key = kontrahent.IdKontrahenta,
                            Value = kontrahent.Nazwa // + " " + kontrahent.NIP + " " + kontrahent.Imie
                        }
                    ).ToList().AsQueryable();
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

        #endregion Properties

        #region Helpers
        //to jest metoda ktora zapisuje rekod
        public override void Save()
        {
            //najpierw dodajemy nowy rekord do lokalnej kolekcji
            komisEntities.Faktury.Add(item);
            //nastepnie zapisujemy zmiany w bazie danych
            komisEntities.SaveChanges();
        }

        private void getWybranyKontrahent(KontrahenciForAllView kontrahent)
        {
            IdNabywca = kontrahent.IdKontrahenta;
            KontrahentDane = kontrahent.Nazwa + " " + kontrahent.Nazwisko + " " + kontrahent.Imie;
        }

        #endregion Helpers
    }
}