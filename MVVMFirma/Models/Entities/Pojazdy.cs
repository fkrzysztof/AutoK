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
    
    public partial class Pojazdy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pojazdy()
        {
            this.PozycjeFaktury = new HashSet<PozycjeFaktury>();
            this.Zdjecia1 = new HashSet<Zdjecia>();
        }
    
        public int IdPojazdu { get; set; }
        public Nullable<int> IdMarki { get; set; }
        public Nullable<int> IdModelu { get; set; }
        public Nullable<int> IdDostawcy { get; set; }
        public Nullable<System.DateTime> RokProdukcji { get; set; }
        public Nullable<System.DateTime> PierwszaRejestracja { get; set; }
        public Nullable<int> IdKomisu { get; set; }
        public Nullable<int> Pojemnosc { get; set; }
        public Nullable<int> IdWyposazenia { get; set; }
        public string OpisPojazdu { get; set; }
        public Nullable<int> IdDokladnegoTypu { get; set; }
        public Nullable<int> IdTypuSilnika { get; set; }
        public string Przebieg { get; set; }
        public Nullable<int> IdKoloru { get; set; }
        public string NrVIN { get; set; }
        public Nullable<bool> Wypadkowy { get; set; }
        public Nullable<System.DateTime> DataPrzyjecia { get; set; }
        public Nullable<System.DateTime> DataWydania { get; set; }
        public Nullable<bool> CzyZarezerowany { get; set; }
        public string NrRejestracyjny { get; set; }
        public string Pochodzenie { get; set; }
        public Nullable<int> IdZdjecia { get; set; }
        public Nullable<int> MocKM { get; set; }
        public string SkrzyniaBiegów { get; set; }
        public string Naped { get; set; }
        public Nullable<byte> LiczbaDrzwi { get; set; }
        public Nullable<byte> LiczbaMiejsc { get; set; }
        public Nullable<bool> ZarezerwowanyWPolsce { get; set; }
        public Nullable<bool> SerwisowanyWASO { get; set; }
        public Nullable<bool> CzyPozycjaAktualna { get; set; }
        public Nullable<int> IdRaportu { get; set; }
        public Nullable<int> IdZmianyCeny { get; set; }
        public Nullable<int> IdKlimatyzacji { get; set; }
    
        public virtual DokladnyTypPojazdu DokladnyTypPojazdu { get; set; }
        public virtual Klimatyzacja Klimatyzacja { get; set; }
        public virtual Kolory Kolory { get; set; }
        public virtual Kolory Kolory1 { get; set; }
        public virtual Komisy Komisy { get; set; }
        public virtual Kontrahenci Kontrahenci { get; set; }
        public virtual Marka Marka { get; set; }
        public virtual ModelPojazdu ModelPojazdu { get; set; }
        public virtual Raport Raport { get; set; }
        public virtual TypSilnika TypSilnika { get; set; }
        public virtual Wyposazenie Wyposazenie { get; set; }
        public virtual Zdjecia Zdjecia { get; set; }
        public virtual ZmianyCeny ZmianyCeny { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozycjeFaktury> PozycjeFaktury { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zdjecia> Zdjecia1 { get; set; }
    }
}
