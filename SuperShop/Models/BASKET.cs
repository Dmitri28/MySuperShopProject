//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BASKET
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Store Store { get; set; }
        public virtual Users Users { get; set; }
    }
}
