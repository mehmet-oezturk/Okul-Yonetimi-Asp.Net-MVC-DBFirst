//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcAdmingirisli.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dersler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dersler()
        {
            this.Notlar = new HashSet<Notlar>();
        }
    
        public int DersNo { get; set; }
        public string DersAdi { get; set; }
        public Nullable<int> Kredi { get; set; }
        public Nullable<int> Hoca { get; set; }
    
        public virtual Hocalar Hocalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notlar> Notlar { get; set; }
    }
}
