//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class client_info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client_info()
        {
            this.Transiction_history = new HashSet<Transiction_history>();
            this.Transiction_history1 = new HashSet<Transiction_history>();
            this.Transiction_history2 = new HashSet<Transiction_history>();
        }
    
        public int account_Num { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public Nullable<decimal> phone { get; set; }
        public string countryNegative { get; set; }
        public string card_type { get; set; }
        public string gender { get; set; }
        public string Nationality { get; set; }
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public Nullable<double> Balance { get; set; }
        public byte[] picture { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transiction_history> Transiction_history { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transiction_history> Transiction_history1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transiction_history> Transiction_history2 { get; set; }
    }
}
