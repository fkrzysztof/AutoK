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
    
    public partial class Zdjecia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zdjecia()
        {
            this.Pojazdy = new HashSet<Pojazdy>();
        }
    
        public int idZdjecia { get; set; }
        public Nullable<int> IdPojazdu { get; set; }
        public string URL { get; set; }
        public Nullable<bool> CzyAktywne { get; set; }
        public Nullable<int> IdRaportu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pojazdy> Pojazdy { get; set; }
        public virtual Pojazdy Pojazdy1 { get; set; }
        public virtual Raport Raport { get; set; }
    }
}
