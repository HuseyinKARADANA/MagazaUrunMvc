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
    
    public partial class TblUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUrunler()
        {
            this.TblSatislars = new HashSet<TblSatislar>();
        }
    
        public int id { get; set; }
        public string ad { get; set; }
        public string marka { get; set; }
        public Nullable<int> stok { get; set; }
        public Nullable<decimal> alisFiyat { get; set; }
        public Nullable<decimal> satisFiyat { get; set; }
        public Nullable<int> kategori { get; set; }
    
        public virtual TblKategori TblKategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatislar> TblSatislars { get; set; }
    }
}