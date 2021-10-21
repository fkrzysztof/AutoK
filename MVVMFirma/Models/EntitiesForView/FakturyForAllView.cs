using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MVVMFirma.Model.EntitiesForView
{
    public class FakturyForAllView
    {


        #region Properties

        public int IdFaktury { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public string Miejscowosc { get; set; }
        public DateTime? DataSprzedazy { get; set; }
        public int? NumerFaktury { get; set; }
        public string Adnotacje { get; set; } 
        public string NumerRachunkuBankowego { get; set; }
        

        // to jest do klucza obceg - wyswietla tylko intyIdNabywca       // public int IdPracownikaWystawiajacego { get; set; }
        // public int IdPracownikaSprawdzajace { get; set; }

        //nie wiem czy to jest konieczne !!
        public int IdNabywca { get; set; }
        public int IdPracownikaSprawdzajacego { get; set; }
        public int IdPracownikaWystawiajacego { get; set; }
        public int IdRodzajPlatnosci { get; set; }

        // public int IdSprzedawca { get; set; }
        // public int IdPlatnika { get; set; }

        public DateTime? DataPlatnosci { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        // klucz obcy
        // konttrahent czyli idnaby
        public String KontrahentKodPocztowy { get; set; }
        public String KontrahentKraj { get; set; }
        public String KontrahentMiasto { get; set; }
        //kontrahent nazwa, imie, nazwisko 
        public String KontrahentNazwa { get; set; }
        public String KontrahentImie { get; set; }
        public String KontrahentNazwisko { get; set; }
        public bool? KontrahentDostawca { get; set; }  //nowe
        
     //   public int IdPracownikaSprawdzajacego { get; set; }
        public String PracownikWystawiajacyImie { get; set; }
        public String PracownikWystawiajacyNazwisko { get; set; }
        public String PracownikWystawiajacyStanowisko { get; set; }

        public String PracownikZatwierdzajacyImie { get; set; }
        public String PracownikZatwierdzajacyNazwisko { get; set; }
        public String PracownikZatwierdzajacyStanowisko { get; set; }
        public string RodzajPlatnosciNazwa { get; set; }
    
        #endregion //Properties

    }
}