//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LCardDiags
{
    using System;
    using System.Collections.Generic;
    
    public partial class listOrgans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public listOrgans()
        {
            this.listObservPlanDetails = new HashSet<listObservPlanDetails>();
        }
    
        public int OrganCode { get; set; }
        public Nullable<int> Parent { get; set; }
        public string OrganName { get; set; }
        public string Notes { get; set; }
        public byte[] Picture { get; set; }
        public Nullable<int> Sex { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<listObservPlanDetails> listObservPlanDetails { get; set; }
    }
}