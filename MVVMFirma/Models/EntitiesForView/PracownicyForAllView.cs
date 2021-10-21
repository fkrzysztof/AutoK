using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    class PracownicyForAllView
    {
        public int IdPracownika { get; set; }
        public int IdKomisu { get; set; }
        public int IdAdresuPracownika { get; set; }
        public string Stanowisko { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string PESEL { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Email { get; set; }
        public DateTime? DataRozpoczeciaPracy { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public string Adnotacje { get; set; }

        //klucze obce

        public string AdresyKraj { get; set; }
        public string AdresyMiasto { get; set; }
        public string AdresyUlica { get; set; }
        public string AdresyNrDomu { get; set; }
        public string AdresyNrLokalu { get; set; }
        public string AdresyKodPocztowy { get; set; }


    }
}
