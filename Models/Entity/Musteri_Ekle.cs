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
    
    public partial class Musteri_Ekle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri_Ekle()
        {
            this.Sozlesme_Ekle = new HashSet<Sozlesme_Ekle>();
        }
    
        public int Musteri_ID { get; set; }
        public string TC { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public System.DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string EhliyetNo { get; set; }
        public System.DateTime AlisTarihi { get; set; }
        public string AlisYeri { get; set; }
        public System.DateTime EhGecerlilikTarihi { get; set; }
        public string KrediKartNo { get; set; }
        public System.DateTime GecerlilikTarihi { get; set; }
        public string CVV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sozlesme_Ekle> Sozlesme_Ekle { get; set; }
    }
}
