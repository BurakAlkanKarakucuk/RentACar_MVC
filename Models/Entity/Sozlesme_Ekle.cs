//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AracKiralama_MVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sozlesme_Ekle
    {
        public int Sozlesme_ID { get; set; }
        public int Musteri_ID { get; set; }
        public int Arac_ID { get; set; }
        public decimal Odenecek_Fiyat { get; set; }
        public System.DateTime Alis_Tarihi { get; set; }
        public System.DateTime VerisTarihi { get; set; }
        public int Personel_ID { get; set; }
    
        public virtual Arac_Kayit Arac_Kayit { get; set; }
        public virtual Musteri_Ekle Musteri_Ekle { get; set; }
        public virtual Personel_Ekle Personel_Ekle { get; set; }
    }
}
