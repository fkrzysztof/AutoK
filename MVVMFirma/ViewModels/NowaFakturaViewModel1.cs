using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;

namespace MVVMFirma.ViewModels
{
    class NowaFakturaViewModel : JedenViewModel<Faktury> //pod typ generyczny T podstawiono typ Faktury
    {
        #region Construktor
        public NowaFakturaViewModel()
            : base()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Faktura";
            //tworzymy nowy pusty obiekt biznesowy
            this.item = new Faktury();
        }
        #endregion Constructor

        #region Properties
        //dla kazdego pola na interfejsie edytowalnego tworzymy propertisa z standardowym kodem

       

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
        public IQueryable<ComboBoxKeyAndValue> PracownikZatwierdzilComboBoxItems 
        {
            get
            {
                return
                    (
                        from pracownicy in komisEntities.pracownicy //Dla kazdego kontrahenta z bazy danych Kontrahentow                  
                        select new ComboBoxKeyAndValue  //Tworzymy ComboboxKeyAndValue
                        {
                            Key = Pracownicy.IdPracownika,
                            Value = Pracownicy.Imie// + " " + Pracownicy.Nazwisko + " " + Pracownicy.Stanowisko
                        }
                    ).ToList().AsQueryable();
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
        #endregion Helpers
    }
}