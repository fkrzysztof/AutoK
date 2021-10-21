using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    class KontrahenciForAllView
    {
        public int IdKontrahenta { get; set; }
        public int IdAdresuKontrahenta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nazwa { get; set; }
        public string OsobaKontaktowa { get; set; }
        public string PESEL { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string RachunekBankowy { get; set; }
        public bool? Dostawca { get; set; }
        public string Adnotacje { get; set; }

        //klucze obce
        public string KonKodPocztowy { get; set; }
        public string KonKraj { get; set; }
        public string KonMiasto { get; set; }
        public string KonUlica { get; set; }
        public string KonNrDomu { get; set; }
        public string KonNrLokalu { get; set; }

    }
}
