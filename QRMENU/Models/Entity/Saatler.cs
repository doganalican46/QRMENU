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
    
    public partial class Saatler
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Pazartesi { get; set; }
        public string Sali { get; set; }
        public string Carsamba { get; set; }
        public string Persembe { get; set; }
        public string Cuma { get; set; }
        public string Cumartesi { get; set; }
        public string Pazar { get; set; }
        public Nullable<int> CafeID { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        public virtual Cafeler Cafeler { get; set; }
    }
}
