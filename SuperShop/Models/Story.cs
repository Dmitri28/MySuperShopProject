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
    
    public partial class Story
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public Nullable<double> DataOfPuchase { get; set; }
        public Nullable<double> TimeOfPurchase { get; set; }
        public string ListOfPurchase { get; set; }
        public double CommodityPrices { get; set; }
        public Nullable<double> TheTotalValueOfTheCheck { get; set; }
    }
}
