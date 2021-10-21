using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    class PozycjeAdresuForAllView
    {
        public int IdAdresuPracownika { get; set; }
        public int IdPracownika { get; set; }

        public int IdAdresuKontrahenta { get; set; }
        public int IdKontrahenta { get; set; }

        public int IdAdresuKomisu { get; set; }
        public int IdKomisu { get; set; }


        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string NrLokalu { get; set; }
        public string KodPocztowy { get; set; }

    }
}
