using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    class KomisyForAllView
    {
        public int IdKomisu { get; set; }
        public int IdAdresuKomisu { get; set; }
        public string OsobaKontaktowa { get; set; }
        public string NrKomisu { get; set; }
        public string NazwaKomisu { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public DateTime? DataDodania { get; set; }
        public string Adnotacje { get; set; }
        //klucze obce
        public string KomisKraj { get; set; }
        public string KomisMiasto { get; set; }
        public string KomisUlica { get; set; }
        public string KomisNrDomu { get; set; }
        public string KomisNrLokalu { get; set; }
        public string KomisKodPocztowy { get; set; }

    }
}
