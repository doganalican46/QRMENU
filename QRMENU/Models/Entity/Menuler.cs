//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QRMENU.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menuler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menuler()
        {
            this.Kategoriler = new HashSet<Kategoriler>();
            this.QR = new HashSet<QR>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
        public Nullable<int> CafeID { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        public virtual Cafeler Cafeler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kategoriler> Kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QR> QR { get; set; }
    }
}
