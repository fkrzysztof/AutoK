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
    
    public partial class DokladnyTypPojazdu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DokladnyTypPojazdu()
        {
            this.Pojazdy = new HashSet<Pojazdy>();
        }
    
        public int IdDokladnegoTypuPojazdu { get; set; }
        public Nullable<int> IdOgolnegoTypu { get; set; }
        public string NazwaDokladnegoTypu { get; set; }
        public Nullable<bool> CzyAktywne { get; set; }
        public Nullable<int> IdRaportu { get; set; }
    
        public virtual OgolnyTypPojazdu OgolnyTypPojazdu { get; set; }
        public virtual Raport Raport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pojazdy> Pojazdy { get; set; }
    }
}
