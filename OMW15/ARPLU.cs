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
    
    public partial class ARPLU
    {
        public int ARPLU_KEY { get; set; }
        public int ARPLU_ARPRB { get; set; }
        public int ARPLU_GOODS { get; set; }
        public string ARPLU_ARPRBCODE { get; set; }
        public string ARPLU_GOODSCODE { get; set; }
        public decimal ARPLU_U_PRC { get; set; }
        public string ARPLU_U_DSC { get; set; }
        public int ARPLU_TAG { get; set; }
        public string ARPLU_AUTO { get; set; }
        public Nullable<decimal> ARPLU_AUTO_GP { get; set; }
        public Nullable<int> ARPLU_AUTO_ROUND { get; set; }
        public string ARPLU_LASTUPD { get; set; }
    
        public virtual ARPRICETAB ARPRICETAB { get; set; }
        public virtual GOODSMASTER GOODSMASTER { get; set; }
    }
}
