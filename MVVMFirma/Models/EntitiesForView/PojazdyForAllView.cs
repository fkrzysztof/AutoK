using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    class PojazdyForAllView
    {
        public int IdPojazdu { get; set; }
        public int IdMarki { get; set; }
        public int IdModelu { get; set; }
        public int IdDostawcy { get; set; }
        public DateTime? RokProdukcji { get; set; }
        public DateTime? PierwszaRejestracja { get; set; }
        public int IdKomisu { get; set; }
        public int? Pojemnosc { get; set; }
        public int? PojazdIdNabywca { get; set; } // dodane do kup auto gdzie jest nabywca? ??? --> Faktura 
     //   public int IdWyposazenia { get; set; }
        public string OpisPojazdu { get; set; }
        public int IdDokladnegoTypu { get; set; }
        public int IdTypuSilnika { get; set; }
        public string Przebieg { get; set; }
        public int IdKoloru { get; set; }
        public string NrVIN { get; set; }
        public bool? Wypadkowy { get; set; }
        public DateTime? DataPrzyjecia { get; set; }
        public DateTime? DataWydania { get; set; }
        public bool? CzyZarezerowany { get; set; }
        public string NrRejestracyjny { get; set; }
        public string Pochodzenie { get; set; }
     //   public int IdZdjecia { get; set; }
        public int? MocKM { get; set; }
        public string SkrzyniaBiegów { get; set; }
        public string Naped { get; set; }
        public byte? LiczbaDrzwi { get; set; }
        public byte? LiczbaMiejsc { get; set; }
        public bool? ZarezerwowanyWPolsce { get; set; }
        public bool? SerwisowanyWASO { get; set; }
        public int IdZmianyCeny { get; set; }
        public int IdKlimatyzacji { get; set; }

        //klucze obce
        //rozne
        public string PojazdMarka { get; set; }
        public string PojazdModel { get; set; }


        public string PojazdDokladnytyp { get; set; }
        public string PojazdTypSilnika { get; set; }
        public string PojazdKolor { get; set; }
        public decimal? PojazdCena { get; set; }
        public string PojazdKlimatyzacja { get; set; }
        
        //wyposazenie
        public bool? PojazdAbs { get; set; }
        public bool? PojazdESzP { get; set; }
        public bool? PojazdESzT { get; set; }
        public bool? PojazdAux { get; set; }
        public bool? PojazdISOFix { get; set; }
        public bool? PojazdCD { get; set; }
        public bool? PojazdSD { get; set; }
        public bool? PojazdUSB { get; set; }
        public bool? PojazdTempomat { get; set; }

        //foto
        public string PojazdUrl { get; set; }

        //   public string PojazdDostawca { get; set; }
        //Komis i adres komisu
        public string PojazdNazwaKomisu { get; set; }
        public string PojazdMiastoKomisu { get; set; }
        public string PojazdUlicaKomisu { get; set; } //nowe
        public string PojazdKodKomisu { get; set; }   //nowe
        public string PojazNrDomuKomisu { get; set; }     //nowe
        public string PojazNIPKomisu { get; set; }     //nowe

        


    }
}
