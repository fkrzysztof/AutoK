using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    class DodajKontaktViewModel : WorkspaceViewModel
    {
        

        #region Fields 
        //tworzym
        protected KomisEntities komisEntities;

        //tworzymy obiekt ktory bedziemy dodawac do  bazy
        //typ T to jest dowolny typ obiektu ktory bedzie dodawany za pomoca tej klasy, czym jest T zdecydujemy w klasie dziedziczacej.
        //w przypadku dodawania towarow T bedzie typu Towary.
        protected Kontrahenci item;
        //to jest komenda ktora zostanie podpieta do przycisku zapisz
        private BaseCommand _SaveCommand;
        #endregion Fields

        #region Constructor

        public DodajKontaktViewModel()
        {
            this.komisEntities = new KomisEntities();
            this.item = new Kontrahenci();
        }
        #endregion Constructor

        #region Commands
        //to jest komenda ktora zostanie podpieta pod przycisk zapisu
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => saveAndClose()); //ta komenda wywola metode save and close ktora zapisze rekord i zamknie zakladke
                return _SaveCommand;
            }
        }
        #endregion commends


        #region Properties
        //dla kazdego pola na interfejsie edytowalnego tworzymy propertisa standardowym kodem 

        public String Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie); //to jest funkcja ktora odpowiada za odswiezenie okna po zmianie pola Kod
                }
            }
        }
        public String Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko); 
                }
            }
        }

        public String Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa); 
                }
            }
        }

        public String OsobaKontaktowa
        {
            get
            {
                return item.OsobaKontaktowa;
            }
            set
            {
                if (item.OsobaKontaktowa != value)
                {
                    item.OsobaKontaktowa = value;
                    OnPropertyChanged(() => OsobaKontaktowa); 
                }
            }
        }

        public String PESEL
        {
            get
            {
                return item.PESEL;
            }
            set
            {
                if (item.PESEL != value)
                {
                    item.PESEL = value;
                    OnPropertyChanged(() => PESEL); 
                }
            }
        }
        
        public String NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (item.NIP != value)
                {
                    item.NIP = value;
                    OnPropertyChanged(() => NIP); 
                }
            }
        }
                
        public String REGON
        {
            get
            {
                return item.REGON;
            }
            set
            {
                if (item.REGON != value)
                {
                    item.REGON = value;
                    OnPropertyChanged(() => REGON); 
                }
            }
        }
                        
        public int? IdAdresuKontrahenta
        {
            get
            {
                return item.IdAdresuKontrahenta;
            }
            set
            {
                if (item.IdAdresuKontrahenta != value)
                {
                    item.IdAdresuKontrahenta = value;
                    OnPropertyChanged(() => IdAdresuKontrahenta); 
                }
            }
        }

        public String Telefon1
        {
            get
            {
                return item.Telefon1;
            }
            set
            {
                if (item.Telefon1 != value)
                {
                    item.Telefon1 = value;
                    OnPropertyChanged(() => Telefon1);
                }
            }
        }
        
        public String Telefon2
        {
            get
            {
                return item.Telefon2;
            }
            set
            {
                if (item.Telefon2 != value)
                {
                    item.Telefon2 = value;
                    OnPropertyChanged(() => Telefon2);
                }
            }
        }
                
        public String Email1
        {
            get
            {
                return item.Email1;
            }
            set
            {
                if (item.Email1 != value)
                {
                    item.Email1 = value;
                    OnPropertyChanged(() => Email1);
                }
            }
        }
                        
        public String Email2
        {
            get
            {
                return item.Email2;
            }
            set
            {
                if (item.Email2 != value)
                {
                    item.Email2 = value;
                    OnPropertyChanged(() => Email2);
                }
            }
        }
                                
        public String RachunekBankowy
        {
            get
            {
                return item.RachunekBankowy;
            }
            set
            {
                if (item.RachunekBankowy != value)
                {
                    item.RachunekBankowy = value;
                    OnPropertyChanged(() => RachunekBankowy);
                }
            }
        }

        public bool? Dostawca = false;

        //public bool? Dostawca
        //{
        //    get
        //    {
        //        return item.Dostawca;
        //    }
        //    set
        //    {
        //        if (item.Dostawca != value)
        //        {
        //            item.Dostawca = value;
        //            OnPropertyChanged(() => Dostawca);
        //        }
        //    }
        //}

        public String Adnotacje
        {
            get
            {
                return item.Adnotacje;
            }
            set
            {
                if (item.Adnotacje != value)
                {
                    item.Adnotacje = value;
                    OnPropertyChanged(() => Adnotacje);
                }
            }
        }

        




        #endregion Properties

        #region Helpers
        //to jest metoda ktora zapisuje rekord - metoda publicza
        public void Save()
        {
            // najpierw dodajemy nowy rekord do lokalnej kolekcji
            komisEntities.Kontrahenci.Add(item);
            //nastepnie zapisujemy zmiany w bazie danych
            komisEntities.SaveChanges();
        }
        private void saveAndClose()
        {
            //najpierw zapisujemy rekord nastepnie zamykamy zakladke
            this.Save();
            onRequestClose();
        }


        #endregion Helpers
       

    }
}
