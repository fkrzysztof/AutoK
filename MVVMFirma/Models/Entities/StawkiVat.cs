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
    
    public partial class StawkiVat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StawkiVat()
        {
            this.PozycjeFaktury = new HashSet<PozycjeFaktury>();
        }
    
        public int IdStawkiVat { get; set; }
        public Nullable<decimal> StawkaVat { get; set; }
        public string Opis { get; set; }
        public Nullable<bool> CzyAktywne { get; set; }
        public Nullable<int> IdRaportu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozycjeFaktury> PozycjeFaktury { get; set; }
        public virtual Raport Raport { get; set; }
    }
}
