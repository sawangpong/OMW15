//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMW15
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        public string id { get; set; }
        public string type { get; set; }
        public bool isdelete { get; set; }
        public Nullable<int> productGroupID { get; set; }
        public string products { get; set; }
        public bool hasAfterSaleService { get; set; }
        public bool isOwnProduct { get; set; }
        public bool isOffProduction { get; set; }
        public bool isSpecialProduct { get; set; }
        public bool isBuyForTread { get; set; }
        public byte[] productpic { get; set; }
    }
}