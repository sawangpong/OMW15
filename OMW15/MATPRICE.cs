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
    
    public partial class MATPRICE
    {
        public int SEQ { get; set; }
        public int MATID { get; set; }
        public Nullable<decimal> PRICEDATE { get; set; }
        public Nullable<int> FISCYEAR { get; set; }
        public Nullable<int> FISCPERIOD { get; set; }
        public Nullable<decimal> ORGPRICEUSD { get; set; }
        public Nullable<decimal> EXCHANGERATE { get; set; }
        public Nullable<decimal> EXCHDATE { get; set; }
        public Nullable<decimal> COSTTHBGRAM { get; set; }
        public Nullable<decimal> PRICETHBGRAM { get; set; }
        public string AUDITUSER { get; set; }
        public Nullable<decimal> AUDITDATE { get; set; }
        public string MODIUSER { get; set; }
        public Nullable<decimal> MODIDATE { get; set; }
    }
}
