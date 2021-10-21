using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
   internal class OsoboweViewModels : WszystkiePojazdyViewModel<PojazdyForAllView>
    {
        #region Constructor
        public OsoboweViewModels()
        : base()
        {
            base.DisplayName = "Wszystkie Osobowe";
        }
        #endregion // Constructor

        #region Fields 
        private BaseCommand _ShowPojazd;

        #endregion

        #region Command 
        public ICommand ShowPojazd
        {
            get
            {
                if (_ShowPojazd == null)
                {
                    _ShowPojazd = new BaseCommand(() => Messenger.Default.Send("Pojazd Show"));
                    
                }
                return _ShowPojazd;
            }
}
#endregion // Command

#region Properties

        private PojazdyForAllView _WybranyPojazd;
        public PojazdyForAllView WybranyPojazd
        {
            get { return _WybranyPojazd; }
            set
            {
                if (_WybranyPojazd != value)
                {
                    _WybranyPojazd = value;
                    //     ShowMessageBoxInformation("Kontrahent: " + _WybranyKontrahent.Nazwa + " " + _WybranyKontrahent.PESEL);

                    //  Messenger.Default.Send(_WybranyPojazd);
                    //  onRequestClose();
                    Messenger.Default.Send("Pojazd Show");
                    Messenger.Default.Send<PojazdyForAllView>(WybranyPojazd);
                  
                }

            }
        }

        #endregion Properties

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PojazdyForAllView>
            (
            from pojazdy in komisEntities.Pojazdy
            select new PojazdyForAllView
            {
                IdPojazdu = pojazdy.IdPojazdu,
                PojazdMarka = pojazdy.Marka.Nazwa,
                PojazdModel = pojazdy.ModelPojazdu.NazwaModelu,
                //  PojazdDostawca = pojazdy.dos
                RokProdukcji = pojazdy.RokProdukcji,
                PierwszaRejestracja = pojazdy.PierwszaRejestracja,
                //komisy
                PojazdNazwaKomisu = pojazdy.Komisy.NazwaKomisu,
                PojazdMiastoKomisu = pojazdy.Komisy.AdresyKomisow.Miasto, 
                PojazdKodKomisu = pojazdy.Komisy.AdresyKomisow.KodPocztowy,
                PojazdUlicaKomisu = pojazdy.Komisy.AdresyKomisow.Ulica,
                PojazNrDomuKomisu = pojazdy.Komisy.AdresyKomisow.NrDomu,
                OpisPojazdu = pojazdy.OpisPojazdu,  //dodane
                Pojemnosc = pojazdy.Pojemnosc,
                PojazdDokladnytyp = pojazdy.DokladnyTypPojazdu.NazwaDokladnegoTypu,
                PojazdTypSilnika = pojazdy.TypSilnika.NazwaTypu,
                Przebieg = pojazdy.Przebieg,
                PojazdKolor = pojazdy.Kolory.NazwaKoloru,
                NrVIN = pojazdy.NrVIN,
                Wypadkowy = pojazdy.Wypadkowy,
                DataPrzyjecia = pojazdy.DataPrzyjecia,
                DataWydania = pojazdy.DataWydania,
                CzyZarezerowany = pojazdy.CzyZarezerowany,
                NrRejestracyjny = pojazdy.NrRejestracyjny,
                Pochodzenie = pojazdy.Pochodzenie,
                MocKM = pojazdy.MocKM,
                SkrzyniaBiegów = pojazdy.SkrzyniaBiegów,
                Naped = pojazdy.Naped,
                LiczbaDrzwi = pojazdy.LiczbaDrzwi,
                LiczbaMiejsc = pojazdy.LiczbaMiejsc,
                ZarezerwowanyWPolsce = pojazdy.ZarezerwowanyWPolsce,
                SerwisowanyWASO = pojazdy.SerwisowanyWASO,
                PojazdCena = pojazdy.ZmianyCeny.Cena,
                PojazdKlimatyzacja = pojazdy.Klimatyzacja.Rodzaj,
                //wyposazenie
                PojazdAbs = pojazdy.Wyposazenie.ABS,
                PojazdESzP = pojazdy.Wyposazenie.ElektryczneSzybyPrzenie,
                PojazdESzT = pojazdy.Wyposazenie.ElektryczneSzybyTylnie,
                PojazdAux = pojazdy.Wyposazenie.GniazdoAUX,
                PojazdISOFix = pojazdy.Wyposazenie.ISOFIX,
                PojazdCD = pojazdy.Wyposazenie.CD,
                PojazdSD = pojazdy.Wyposazenie.GniazdoSD,
                PojazdUSB = pojazdy.Wyposazenie.USB,
                PojazdTempomat = pojazdy.Wyposazenie.Tempomat,
                //foto
                PojazdUrl = pojazdy.Zdjecia.URL,
                //kupno


            }
            );

        }

        public List<string> PokazMarki()
        {
            return new List<string>
            (
            from marka in komisEntities.Marka
            select marka.Nazwa
            ).ToList();
        }
        
        public List<string> PokazModele()
        {
                return new List<string>
                (
                from model in komisEntities.ModelPojazdu
                select model.NazwaModelu
                ).ToList();
        }
                
        public List<string> PokazRodzajePaliwa()
        {
                return new List<string>
                (
                from typ in komisEntities.TypSilnika
                select typ.NazwaTypu
                ).ToList();
        }
                        
        public List<string> PokazKlimatyzacje()
        {
                return new List<string>
                (
                from klima in komisEntities.Klimatyzacja
                select klima.Rodzaj
                ).ToList();
        }

        public List<string> PokazKomisy()
        {
            return new List<string>
            (
            from komis in komisEntities.Komisy
            select komis.AdresyKomisow.Miasto
            ).ToList();
        } 

        public List<string> PokazDokladnyTyp()
        {
            return new List<string>
            (
            from dokladnyTyp in komisEntities.DokladnyTypPojazdu
            select dokladnyTyp.NazwaDokladnegoTypu
            ).ToList();
        }    
        
        public List<int> PokazPrzebieg()
        {
            List<int> przebieg = new List<int>();
            for (int i = 25000; i <= 250000; i+=25000)
                przebieg.Add(i);
            return przebieg;
        }


        #endregion //Helpers

        #region SortAndFind
        //w tej funkcji decydujemy jak sortowac
        public override void Sort()
        {
            if (SelectMarka != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdMarka == SelectMarka));
            if (SelectModel != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdModel == SelectModel));
            if (SelectDataOd != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.RokProdukcji >= SelectDataOd));
            if (SelectDataDo != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.RokProdukcji <= SelectDataDo));
            if (SelectRodzajPaliwa != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdTypSilnika == SelectRodzajPaliwa));
            if (SelectKlimatyzacja != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdKlimatyzacja == SelectKlimatyzacja));
            if (SelectMocOd != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.MocKM >= Convert.ToInt32(SelectMocOd)));
            if (SelectCenaOd != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdCena >= SelectCenaOd));
            if (SelectCenaDo != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdCena <= SelectCenaDo));
            if (SelectKomis != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdMiastoKomisu == SelectKomis));
            if (SelectDokladnyTyp != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => item.PojazdDokladnytyp == SelectDokladnyTyp));
            if (SelectPrzebiegOd != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => Convert.ToInt32(item.Przebieg) >= SelectPrzebiegOd));
            if (SelectPrzebiegDo != null)
                List = new ObservableCollection<PojazdyForAllView>(List.Where(item => Convert.ToInt32(item.Przebieg) >= SelectPrzebiegDo));

        }



        //w tej funkcji decydujemy po jakich kolumnach sortowac
        public override List<string> GetComboboxSortList()
        {
            return new List<string>
            {
                "Nazwa","Kod","OsobaKontaktowa"
            };
        }
        public override List<string> GetComboboxMarka()
        {
           return PokazMarki();
        }
        public override List<string> GetComboboxModel()
        {
            return PokazModele();
        }
        public override List<string> GetComboboxRodzajPaliwa()
        {
            return PokazRodzajePaliwa();
        }
        public override List<string> GetComboboxKlimatyzacja()
        {
            return PokazKlimatyzacje();
        }
        public override List<string> GetComboboxKomis()
        {
            return PokazKomisy();
        }
        public override List<string> GetComboboxDokladnyTyp()
        {
            return PokazDokladnyTyp();
        }
        public override List<int> GetComboboxPrzebieg()
        {
            return PokazPrzebieg();
        }




        #endregion SortAndFind
    }
}