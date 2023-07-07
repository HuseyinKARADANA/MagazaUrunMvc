//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazaUrunMvc.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblMusteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblMusteri()
        {
            this.TblSatislars = new HashSet<TblSatislar>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage ="Ad alan�n� bo� ge�emezsiniz...")]
        public string ad { get; set; }

        [Required(ErrorMessage = "Soyad alan�n� bo� ge�emezsiniz...")]
        [StringLength(50,ErrorMessage ="Soyad alan� 50 karakterden b�y�k olamaz...")]
        public string soyad { get; set; }

        public string sehir { get; set; }
        public Nullable<decimal> bakiye { get; set; }
        public Nullable<bool> durum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatislar> TblSatislars { get; set; }
    }
}
