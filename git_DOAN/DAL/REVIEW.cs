//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DA_CNPM.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class REVIEW
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REVIEW()
        {
            this.USER_REVIEW = new HashSet<USER_REVIEW>();
        }
    
        public int ID_REVIEW { get; set; }
        public Nullable<int> ID_BOOK { get; set; }
        public string COMMENT { get; set; }
        public string RATING { get; set; }
    
        public virtual BOOK BOOK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_REVIEW> USER_REVIEW { get; set; }
    }
}