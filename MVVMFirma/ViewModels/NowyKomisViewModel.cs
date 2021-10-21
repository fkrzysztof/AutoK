using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    class NowyKomisViewModel : JedenViewModel<Komisy>
    {
        #region Constructor
        public NowyKomisViewModel()
        : base()
        {
            base.DisplayName = "Nowy Komis";
            item = new Komisy();
        }
        #endregion // Constructor

        #region Properties

    
        public int? IdAdresuKomisu
        {
            get
            {
                return item.IdAdresuKomisu;
            }
            set
            {
                if (value == item.IdAdresuKomisu)
                    return;
                item.IdAdresuKomisu = value;
                base.OnPropertyChanged(() => IdAdresuKomisu);
            }
        }
        
        public string OsobaKontaktowa
        {
            get
            {
                return item.OsobaKontaktowa;
            }
            set
            {
                if (value == item.OsobaKontaktowa)
                    return;
                item.OsobaKontaktowa = value;
                base.OnPropertyChanged(() => OsobaKontaktowa);
            }
        }
                
        public string NrKomisu
        {
            get
            {
                return item.NrKomisu;
            }
            set
            {
                if (value == item.NrKomisu)
                    return;
                item.NrKomisu = value;
                base.OnPropertyChanged(() => NrKomisu);
            }
        }
                        
        public string NazwaKomisu
        {
            get
            {
                return item.NazwaKomisu;
            }
            set
            {
                if (value == item.NazwaKomisu)
                    return;
                item.NazwaKomisu = value;
                base.OnPropertyChanged(() => NazwaKomisu);
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
                                
        public string Telefon2
        {
            get
            {
                return item.Telefon2;
            }
            set
            {
                if (value == item.Telefon2)
                    return;
                item.Telefon2 = value;
                base.OnPropertyChanged(() => Telefon2);
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
                                                
        public string Email2
        {
            get
            {
                return item.Email2;
            }
            set
            {
                if (value == item.Email2)
                    return;
                item.Email2 = value;
                base.OnPropertyChanged(() => Email2);
            }
        }
                                                        
        public DateTime? DataDodania
        {
            get
            {
                return item.DataDodania;
            }
            set
            {
                if (value == item.DataDodania)
                    return;
                item.DataDodania = value;
                base.OnPropertyChanged(() => DataDodania);
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

        // klucze obce                                                              
        //public string KomisKraj
        //{
        //    get
        //    {
        //        return item.AdresyKomisow.Kraj;
        //    }
        //    set
        //    {
        //        if (value == item.AdresyKomisow.Kraj)
        //            return;
        //        item.AdresyKomisow.Kraj = value;
        //        base.OnPropertyChanged(() => KomisKraj);
        //    }
        //}



        //   public string KomisKraj { get; set; }
        //   public string KomisMiasto { get; set; }
        //    public string KomisUlica { get; set; }
        //    public string KomisNrDomu { get; set; }
        //     public string KomisNrLokalu { get; set; }
        //    public string KomisKodPocztowy { get; set; }

        //combo nie potrzebne
        /*
        public IQueryable<ComboBoxKeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return
                (
                from kontrahent in fakturyEntities.Kontrahenci
                select new ComboBoxKeyAndValue
                {
                    Key = kontrahent.id,
                    Value = kontrahent.kod + " " + kontrahent.nazwa + " " + kontrahent.nip
                }).ToList().AsQueryable();
            }
        }
        */
        #endregion //Properties
        #region Helpers
        //to jest metoda ktora zapisuje rekod
        public override void Save()
        {
            //najpierw dodajemy nowy rekord do lokalnej kolekcji
            komisEntities.Komisy.Add(item);
            //nastepnie zapisujemy zmiany w bazie danych
            komisEntities.SaveChanges();
        }

        #endregion Helpers

    }
}