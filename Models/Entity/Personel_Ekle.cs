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
    
    public partial class Personel_Ekle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personel_Ekle()
        {
            this.Muhasebe = new HashSet<Muhasebe>();
            this.Sozlesme_Ekle = new HashSet<Sozlesme_Ekle>();
        }
    
        public int Personel_ID { get; set; }
        public string TC { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public System.DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string Yetki_Turu { get; set; }
        public int Kullanıcı_ID { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Muhasebe> Muhasebe { get; set; }
        public virtual Personel_Ekle Personel_Ekle1 { get; set; }
        public virtual Personel_Ekle Personel_Ekle2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sozlesme_Ekle> Sozlesme_Ekle { get; set; }
    }
}
