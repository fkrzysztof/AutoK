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
    
    public partial class ModelPojazdu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModelPojazdu()
        {
            this.Pojazdy = new HashSet<Pojazdy>();
        }
    
        public int idModelu { get; set; }
        public Nullable<int> idMarki { get; set; }
        public string NazwaModelu { get; set; }
        public Nullable<bool> CzyAktywne { get; set; }
        public Nullable<int> IdRaportu { get; set; }
    
        public virtual Marka Marka { get; set; }
        public virtual Raport Raport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pojazdy> Pojazdy { get; set; }
    }
}