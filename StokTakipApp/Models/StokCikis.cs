//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokTakipApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StokCikis
    {
        public int Id { get; set; }
        public int MalzemeId { get; set; }
        public decimal BirimKatsayi { get; set; }
        public decimal Toplam { get; set; }
        public decimal DolapNo { get; set; }
        public Nullable<decimal> RafNo { get; set; }
        public int DepoNo { get; set; }
    
        public virtual Depo Depo { get; set; }
        public virtual Malzeme Malzeme { get; set; }
    }
}
