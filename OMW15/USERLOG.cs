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
    
    public partial class USERLOG
    {
        public int USERID { get; set; }
        public string USERNAME { get; set; }
        public string WORKSTATION { get; set; }
        public string APPNAME { get; set; }
        public string APPVERSION { get; set; }
        public string SERVERNAME { get; set; }
        public string DATABASENAME { get; set; }
        public string AUDITCLASS { get; set; }
        public System.DateTime LOGINDT { get; set; }
        public Nullable<System.DateTime> LOGOUTDT { get; set; }
    }
}
