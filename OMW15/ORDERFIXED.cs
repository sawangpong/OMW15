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
    
    public partial class ORDERFIXED
    {
        public int lineid { get; set; }
        public int orderid { get; set; }
        public string ordercode { get; set; }
        public string s_order { get; set; }
        public System.DateTime datefixed { get; set; }
        public string fixeddetail { get; set; }
        public string engcode1 { get; set; }
        public string engineer1 { get; set; }
        public string engcode2 { get; set; }
        public string engineer2 { get; set; }
        public string engcode3 { get; set; }
        public string engineer3 { get; set; }
        public string engcode4 { get; set; }
        public string engineer4 { get; set; }
        public bool isdelete { get; set; }
    
        public virtual ORDERMAINTENANCE ORDERMAINTENANCE { get; set; }
    }
}
