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
    
    public partial class QR
    {
        public int ID { get; set; }
        public string QR1 { get; set; }
        public Nullable<int> MenuID { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        public virtual Menuler Menuler { get; set; }
    }
}