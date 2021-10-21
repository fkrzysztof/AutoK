using Microsoft.Win32;
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
    class NowyPojazdViewModel :JedenViewModel<Pojazdy>
    {
        #region Constructor
        public NowyPojazdViewModel()
        : base()
        {
            base.DisplayName = "Nowy Pojazd";
            item = new Pojazdy();
            itemZmianaCeny = new ZmianyCeny();
            itemWyposazenie = new Wyposazenie();
            //public ICommand FotoUploadCommand;
        }
        #endregion Constructor


        #region Command
        //public ICommand Upload
        //{
        //    get
        //    {
        //        if (_Update == null)
        //            _Update = new BaseCommand(() => loadUp());
        //        return _Update;
        //    }
        //}

        //FotoUploadCommand = new BaseCommand(FotoPatientUpload);
        #endregion Command

        #region Fields
        ZmianyCeny itemZmianaCeny;
        Wyposazenie itemWyposazenie;
        #endregion Fields

        #region Properties

        //public int IdPojazdu
        //{
        //    get
        //    {
        //        return item.IdPojazdu;
        //    }
        //    set
        //    {
        //        if (value == item.IdPojazdu)
        //            return;
        //        item.IdPojazdu = value;
        //        //base.OnPropertyChanged(() => IdPojazdu);
        //    }
        //}

        public int? IdMarki
        {
            get
            {
                return item.IdMarki;
            }
            set
            {
                if (value == item.IdMarki)
                    return;
                item.IdMarki = value;
                base.OnPropertyChanged(() => IdMarki);
            }
        }

        //public int? IdZmianyCeny
        //{
        //    get
        //    {
        //        return item.IdZmianyCeny;
        //    }
        //    set
        //    {
        //        if (value == item.IdZmianyCeny)
        //            return;
        //        item.IdZmianyCeny = value;
        //        //    base.OnPropertyChanged(() => IdMarki);
        //    }
        //}

        public int? IdModelu
        {
            get
            {
                return item.IdModelu;
            }
            set
            {
                if (value == item.IdModelu)
                    return;
                item.IdModelu = value;
                base.OnPropertyChanged(() => IdModelu);
            }
        }
                
        public DateTime? RokProdukcji
        {
            get
            {
                return item.RokProdukcji;
            }
            set
            {
                if (value == item.RokProdukcji)
                    return;
                item.RokProdukcji = value;
                base.OnPropertyChanged(() => RokProdukcji);
            }
        }
                        
        public DateTime? PierwszaRejestracja
        {
            get
            {
                return item.PierwszaRejestracja;
            }
            set
            {
                if (value == item.PierwszaRejestracja)
                    return;
                item.PierwszaRejestracja = value;
                base.OnPropertyChanged(() => PierwszaRejestracja);
            }
        }
                                
        public int? IdKomisu
        {
            get
            {
                return item.IdKomisu;
            }
            set
            {
                if (value == item.IdKomisu)
                    return;
                item.IdKomisu = value;
                base.OnPropertyChanged(() => IdKomisu);
            }
        }
                                         
        public int? IdDostawcy
        {
            get
            {
                return item.IdDostawcy;
            }
            set
            {
                if (value == item.IdDostawcy)
                    return;
                item.IdDostawcy = value;
                base.OnPropertyChanged(() => IdDostawcy);
            }
        }
                                        
        public int? Pojemnosc
        {
            get
            {
                return item.Pojemnosc;
            }
            set
            {
                if (value == item.Pojemnosc)
                    return;
                item.Pojemnosc = value;
                base.OnPropertyChanged(() => Pojemnosc);
            }
        }
                                                
        public string OpisPojazdu
        {
            get
            {
                return item.OpisPojazdu;
            }
            set
            {
                if (value == item.OpisPojazdu)
                    return;
                item.OpisPojazdu = value;
                base.OnPropertyChanged(() => OpisPojazdu);
            }
        }
                                                        
        public int? IdDokladnegoTypu
        {
            get
            {
                return item.IdDokladnegoTypu;
            }
            set
            {
                if (value == item.IdDokladnegoTypu)
                    return;
                item.IdDokladnegoTypu = value;
                base.OnPropertyChanged(() => IdDokladnegoTypu);
            }
        }
                                                                
        public int? IdTypuSilnika
        {
            get
            {
                return item.IdTypuSilnika;
            }
            set
            {
                if (value == item.IdTypuSilnika)
                    return;
                item.IdTypuSilnika = value;
                base.OnPropertyChanged(() => IdTypuSilnika);
            }
        }
                                                                        
        public string Przebieg
        {
            get
            {
                return item.Przebieg;
            }
            set
            {
                if (value == item.Przebieg)
                    return;
                item.Przebieg = value;
                base.OnPropertyChanged(() => Przebieg);
            }
        }
                                                                                
        public int? IdKoloru
        {
            get
            {
                return item.IdKoloru;
            }
            set
            {
                if (value == item.IdKoloru)
                    return;
                item.IdKoloru = value;
                base.OnPropertyChanged(() => IdKoloru);
            }
        }
                                                                                          
        //public int? IdDostawcy
        //{
        //    get
        //    {
        //        return item.IdDostawcy;
        //    }
        //    set
        //    {
        //        if (value == item.IdDostawcy)
        //            return;
        //        item.IdDostawcy = value;
        //        base.OnPropertyChanged(() => IdDostawcy);
        //    }
        //}
                                                                                        
        public string NrVIN
        {
            get
            {
                return item.NrVIN;
            }
            set
            {
                if (value == item.NrVIN)
                    return;
                item.NrVIN = value;
                base.OnPropertyChanged(() => NrVIN);
            }
        }
                                                                                                
        public bool? Wypadkowy
        {
            get
            {
                return item.Wypadkowy;
            }
            set
            {
                if (value == item.Wypadkowy)
                    return;
                item.Wypadkowy = value;
                base.OnPropertyChanged(() => Wypadkowy);
            }
        }
                                                                                                        
        public DateTime? DataPrzyjecia
        {
            get
            {
                return item.DataPrzyjecia;
            }
            set
            {
                if (value == item.DataPrzyjecia)
                    return;
                item.DataPrzyjecia = value;
                base.OnPropertyChanged(() => DataPrzyjecia);
            }
        }  
        
        public DateTime? DataWydania
        {
            get
            {
                return item.DataWydania;
            }
            set
            {
                if (value == item.DataWydania)
                    return;
                item.DataWydania = value;
                base.OnPropertyChanged(() => DataWydania);
            }
        }
                
        public bool? CzyZarezerowany
        {
            get
            {
                return item.CzyZarezerowany;
            }
            set
            {
                if (value == item.CzyZarezerowany)
                    return;
                item.CzyZarezerowany = value;
                base.OnPropertyChanged(() => CzyZarezerowany);
            }
        }
                        
        public string NrRejestracyjny
        {
            get
            {
                return item.NrRejestracyjny;
            }
            set
            {
                if (value == item.NrRejestracyjny)
                    return;
                item.NrRejestracyjny = value;
                base.OnPropertyChanged(() => NrRejestracyjny);
            }
        }
                                
        public string Pochodzenie
        {
            get
            {
                return item.Pochodzenie;
            }
            set
            {
                if (value == item.Pochodzenie)
                    return;
                item.Pochodzenie = value;
                base.OnPropertyChanged(() => Pochodzenie);
            }
        }
                                        
        public int? MocKM
        {
            get
            {
                return item.MocKM;
            }
            set
            {
                if (value == item.MocKM)
                    return;
                item.MocKM = value;
                base.OnPropertyChanged(() => MocKM);
            }
        }
                                                
        public string Naped
        {
            get
            {
                return item.Naped;
            }
            set
            {
                if (value == item.Naped)
                    return;
                item.Naped = value;
                base.OnPropertyChanged(() => Naped);
            }
        }
                                                
        public byte? LiczbaDrzwi
        {
            get
            {
                return item.LiczbaDrzwi;
            }
            set
            {
                if (value == item.LiczbaDrzwi)
                    return;
                item.LiczbaDrzwi = value;
                base.OnPropertyChanged(() => LiczbaDrzwi);
            }
        }
                                                        
        public byte? LiczbaMiejsc
        {
            get
            {
                return item.LiczbaMiejsc;
            }
            set
            {
                if (value == item.LiczbaMiejsc)
                    return;
                item.LiczbaMiejsc = value;
                base.OnPropertyChanged(() => LiczbaMiejsc);
            }
        }

        public bool? ZarezerwowanyWPolsce
        {
            get
            {
                return item.ZarezerwowanyWPolsce;
            }
            set
            {
                if (value == item.ZarezerwowanyWPolsce)
                    return;
                item.ZarezerwowanyWPolsce = value;
                base.OnPropertyChanged(() => ZarezerwowanyWPolsce);
            }
        }
        
        public bool? SerwisowanyWASO
        {
            get
            {
                return item.SerwisowanyWASO;
            }
            set
            {
                if (value == item.SerwisowanyWASO)
                    return;
                item.SerwisowanyWASO = value;
                base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }

        //ZMIANA CENY KLUCZ OBCY

        public decimal? ZmianaCenyCena
        {
            get
            {
                return itemZmianaCeny.Cena;
            }
            set
            {
                if (value == itemZmianaCeny.Cena)
                    return;
                itemZmianaCeny.Cena = value;
                base.OnPropertyChanged(() => ZmianaCenyCena);
            }
        }

        public int? ZmianaCenyIdPojazdu
        {
            get
            {
                return itemZmianaCeny.IdPojazdu;
            }
            set
            {
                if (value == itemZmianaCeny.IdPojazdu)
                    return;
                itemZmianaCeny.IdPojazdu = value;
                base.OnPropertyChanged(() => ZmianaCenyIdPojazdu);
            }
        }

        //public int IdZmianyCeny
        //{
        //    get
        //    {
        //        return itemZmianaCeny.IdZmianyCeny;
        //    }
        //    set
        //    {
        //        if (value == itemZmianaCeny.IdZmianyCeny)
        //            return;
        //        itemZmianaCeny.IdZmianyCeny = value;
        //     //   base.OnPropertyChanged(() => ZmianaCenyIdPojazdu);
        //    }
        //}

        //***********************************Wyposazenie**************************************

        public bool? ABS
        {
            get
            {
                return itemWyposazenie.ABS;
            }
            set
            {
                if (value == itemWyposazenie.ABS)
                    return;
                itemWyposazenie.ABS = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }
        
        public bool? ESzP
        {
            get
            {
                return itemWyposazenie.ElektryczneSzybyPrzenie;
            }
            set
            {
                if (value == itemWyposazenie.ElektryczneSzybyPrzenie)
                    return;
                itemWyposazenie.ElektryczneSzybyPrzenie = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }
                
        public bool? ESzT
        {
            get
            {
                return itemWyposazenie.ElektryczneSzybyTylnie;
            }
            set
            {
                if (value == itemWyposazenie.ElektryczneSzybyTylnie)
                    return;
                itemWyposazenie.ElektryczneSzybyTylnie = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }
                        
        public bool? Aux
        {
            get
            {
                return itemWyposazenie.GniazdoAUX;
            }
            set
            {
                if (value == itemWyposazenie.GniazdoAUX)
                    return;
                itemWyposazenie.GniazdoAUX = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }

        public bool? ISOFix
        {
            get
            {
                return itemWyposazenie.ISOFIX;
            }
            set
            {
                if (value == itemWyposazenie.ISOFIX)
                    return;
                itemWyposazenie.ISOFIX = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }
        
        public bool? CD
        {
            get
            {
                return itemWyposazenie.CD;
            }
            set
            {
                if (value == itemWyposazenie.CD)
                    return;
                itemWyposazenie.CD = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }
                
        public bool? SD
        {
            get
            {
                return itemWyposazenie.GniazdoSD;
            }
            set
            {
                if (value == itemWyposazenie.GniazdoSD)
                    return;
                itemWyposazenie.GniazdoSD = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }
                        
        public bool? USB
        {
            get
            {
                return itemWyposazenie.USB;
            }
            set
            {
                if (value == itemWyposazenie.USB)
                    return;
                itemWyposazenie.USB = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }
                                
        public bool? Tempomat
        {
            get
            {
                return itemWyposazenie.Tempomat;
            }
            set
            {
                if (value == itemWyposazenie.Tempomat)
                    return;
                itemWyposazenie.Tempomat = value;
              //  base.OnPropertyChanged(() => SerwisowanyWASO);
            }
        }

        //********************Koniec Wyposazenia ********************************


        public int? IdKlimatyzacji
        {
            get
            {
                return item.IdKlimatyzacji;
            }
            set
            {
                if (value == item.IdKlimatyzacji)
                    return;
                item.IdKlimatyzacji = value;
                base.OnPropertyChanged(() => IdKlimatyzacji);
            }
        }

        // klucze obce

        public IQueryable<Marka> MarkaComboBoxItems
        {
            get
            {
                return
                (
                from Marka in komisEntities.Marka
                select Marka
                ).ToList().AsQueryable();
            }
        }

        public IQueryable<ModelPojazdu> ModelComboBoxItems
        {
            get
            {
                return
                (
                from ModelPojazdu in komisEntities.ModelPojazdu
               // where ModelPojazdu.idMarki == IdMarki
                select ModelPojazdu

                ).ToList().AsQueryable();
            }
        }

        public IQueryable<DokladnyTypPojazdu> DokladnyTypPojazduComboBoxItems
        {
            get
            {
                return
                (
                from DokladnyTypPojazdu in komisEntities.DokladnyTypPojazdu
             //   where IdOgolnegoTypu = 1
                select DokladnyTypPojazdu

                ).ToList().AsQueryable();
            }
        }
        
        public IQueryable<TypSilnika> TypSilnikaComboBoxItems
        {
            get
            {
                return
                (
                from TypSilnika in komisEntities.TypSilnika
                select TypSilnika
                ).ToList().AsQueryable();
            }
        }
                
        public IQueryable<Kolory> KolorComboBoxItems
        {
            get
            {
                return
                (
                from Kolory in komisEntities.Kolory
                select Kolory
                ).ToList().AsQueryable();
            }
        }
                        
        public IQueryable<Klimatyzacja> KlimatyzacjaComboBoxItems
        {
            get
            {
                return
                (
                from Klimatyzacja in komisEntities.Klimatyzacja
                select Klimatyzacja
                ).ToList().AsQueryable();
            }
        }

        public IQueryable<ComboBoxKeyAndValue> KomisyComboBoxItems
        {
            get
            {
                return
                    (
                        from Komisy in komisEntities.Komisy //Dla kazdego kontrahenta z bazy danych Kontrahentow                  
                        select new ComboBoxKeyAndValue  //Tworzymy ComboboxKeyAndValue
                        {
                            Key = Komisy.IdKomisu,
                            Value = Komisy.NazwaKomisu  + " " + Komisy.AdresyKomisow.KodPocztowy + " " + Komisy.AdresyKomisow.Miasto
                        }
                    ).ToList().AsQueryable();
            }
        }
        
        //public IQueryable<ComboBoxKeyAndValue> DostawcyComboBoxItems
        //{
        //    get
        //    {
        //        return
        //            (
        //                from kontrahenci in komisEntities.Kontrahenci //Dla kazdego kontrahenta z bazy danych Kontrahentow                  
        //                where kontrahenci.Dostawca == true
        //                select new ComboBoxKeyAndValue  //Tworzymy ComboboxKeyAndValue
        //                {
        //                    Key = kontrahenci.IdKontrahenta,
        //                    Value = kontrahenci.Nazwa  + " - " + kontrahenci.AdresyKontrahentow1.Miasto
        //                }
        //            ).ToList().AsQueryable();
        //    }
        //}



        #endregion Propertis


        #region Helpers

        public override void Save()
        {

            item.IdZmianyCeny = itemZmianaCeny.IdZmianyCeny;
            item.IdWyposazenia = itemWyposazenie.IdWyposazenia;
            komisEntities.Pojazdy.Add(item);
            itemZmianaCeny.IdPojazdu = item.IdPojazdu;
            komisEntities.ZmianyCeny.Add(itemZmianaCeny);
            komisEntities.Wyposazenie.Add(itemWyposazenie);
            

            komisEntities.SaveChanges();
        }

        //private void loadUp()
        //{
        //    OpenFileDialog dialog = new OpenFileDialog();
                

        //}

        #endregion Helpers

    }
}
