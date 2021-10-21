//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pracownicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pracownicy()
        {
            this.Faktury = new HashSet<Faktury>();
            this.Faktury1 = new HashSet<Faktury>();
        }
    
        public int IdPracownika { get; set; }
        public Nullable<int> IdKomisu { get; set; }
        public Nullable<int> IdAdresuPracownika { get; set; }
        public string Stanowisko { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Nullable<System.DateTime> DataUrodzenia { get; set; }
        public string PESEL { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DataRozpoczeciaPracy { get; set; }
        public Nullable<System.DateTime> DataZakonczenia { get; set; }
        public string Adnotacje { get; set; }
        public Nullable<bool> CzyAktywny { get; set; }
        public Nullable<int> IdRaportu { get; set; }
    
        public virtual AdresyPracownikow AdresyPracownikow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faktury> Faktury { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faktury> Faktury1 { get; set; }
        public virtual Raport Raport { get; set; }
    }
}