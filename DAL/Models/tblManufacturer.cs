//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblManufacturer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblManufacturer()
        {
            this.tblDepartments = new HashSet<tblDepartment>();
            this.tblProducts = new HashSet<tblProduct>();
        }
    
        public int Manufacturer_ID { get; set; }
        public string Manufacturer_Name { get; set; }
        public string Manufacturer_Department { get; set; }
        public string Manufacturer_Web { get; set; }
        public Nullable<int> User_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDepartment> tblDepartments { get; set; }
        public virtual tblUser tblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }
    }
}
