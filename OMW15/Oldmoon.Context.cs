﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OLDMOONEF1 : DbContext
    {
        public OLDMOONEF1()
            : base("name=OLDMOONEF1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BANKINFO> BANKINFOes { get; set; }
        public virtual DbSet<BANK> BANKS { get; set; }
        public virtual DbSet<BILLLINE> BILLLINES { get; set; }
        public virtual DbSet<BILL> BILLS { get; set; }
        public virtual DbSet<COMPANY_PROFILES> COMPANY_PROFILES { get; set; }
        public virtual DbSet<CONTACT> CONTACTS { get; set; }
        public virtual DbSet<CRCODE> CRCODEs { get; set; }
        public virtual DbSet<CURRENCY> CURRENCies { get; set; }
        public virtual DbSet<CUSTMATRETURN> CUSTMATRETURNs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERS { get; set; }
        public virtual DbSet<CUSTPRICEITEMPIC> CUSTPRICEITEMPICs { get; set; }
        public virtual DbSet<CUSTPRICELIST> CUSTPRICELISTs { get; set; }
        public virtual DbSet<CUSTTASK> CUSTTASKs { get; set; }
        public virtual DbSet<CUSTTASKIMG> CUSTTASKIMGs { get; set; }
        public virtual DbSet<CUSTTASKLINE> CUSTTASKLINES { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<DISTRICT> DISTRICTS { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<EMPLOYPIC> EMPLOYPICs { get; set; }
        public virtual DbSet<EMPSTATU> EMPSTATUS { get; set; }
        public virtual DbSet<ENGINEER> ENGINEERs { get; set; }
        public virtual DbSet<ERRORCATEGORY> ERRORCATEGORies { get; set; }
        public virtual DbSet<EXCHCURR> EXCHCURRs { get; set; }
        public virtual DbSet<FGLogInfo> FGLogInfoes { get; set; }
        public virtual DbSet<FGSTOCK> FGSTOCKs { get; set; }
        public virtual DbSet<ITEMCODE> ITEMCODEs { get; set; }
        public virtual DbSet<ITEMMASTERIMG> ITEMMASTERIMGs { get; set; }
        public virtual DbSet<ITEMSPRICELIST> ITEMSPRICELISTs { get; set; }
        public virtual DbSet<ITEMSTYLE> ITEMSTYLEs { get; set; }
        public virtual DbSet<JOBINFO> JOBINFOS { get; set; }
        public virtual DbSet<JOBORDER> JOBORDERS { get; set; }
        public virtual DbSet<MATERIAL> MATERIALs { get; set; }
        public virtual DbSet<MATOPENBALANCE> MATOPENBALANCEs { get; set; }
        public virtual DbSet<MATPRICE> MATPRICES { get; set; }
        public virtual DbSet<MATRECEIVE> MATRECEIVEs { get; set; }
        public virtual DbSet<MATSALE> MATSALEs { get; set; }
        public virtual DbSet<MCBOM> MCBOMs { get; set; }
        public virtual DbSet<MemberTimeRecord> MemberTimeRecords { get; set; }
        public virtual DbSet<MIX> MIXes { get; set; }
        public virtual DbSet<ORDERFIXED> ORDERFIXEDs { get; set; }
        public virtual DbSet<ORDERMAINTENANCE> ORDERMAINTENANCEs { get; set; }
        public virtual DbSet<ORDERPIORITY> ORDERPIORITies { get; set; }
        public virtual DbSet<ORDERSPAREPART> ORDERSPAREPARTS { get; set; }
        public virtual DbSet<ORDERTYPE> ORDERTYPEs { get; set; }
        public virtual DbSet<PDITEMPROCESS> PDITEMPROCESSes { get; set; }
        public virtual DbSet<PERMISSION> PERMISSIONs { get; set; }
        public virtual DbSet<PI_INVOICE> PI_INVOICE { get; set; }
        public virtual DbSet<PI_ITEMS> PI_ITEMS { get; set; }
        public virtual DbSet<PMCONTRACT> PMCONTRACTs { get; set; }
        public virtual DbSet<PMMC> PMMCs { get; set; }
        public virtual DbSet<PMSCHEDULE> PMSCHEDULEs { get; set; }
        public virtual DbSet<PRINTLOG> PRINTLOGS { get; set; }
        public virtual DbSet<PRODUCTGROUP> PRODUCTGROUPS { get; set; }
        public virtual DbSet<PRODUCTIONSTDITEM> PRODUCTIONSTDITEMS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<QUOTATIONLL> QUOTATIONLLs { get; set; }
        public virtual DbSet<RUBBERBASE> RUBBERBASEs { get; set; }
        public virtual DbSet<SALE_CONTACTS> SALE_CONTACTS { get; set; }
        public virtual DbSet<SALE_PERSON_PROFILE> SALE_PERSON_PROFILE { get; set; }
        public virtual DbSet<SALEORDER> SALEORDERS { get; set; }
        public virtual DbSet<USERLOG> USERLOGs { get; set; }
        public virtual DbSet<WARRANTy> WARRANTIES { get; set; }
        public virtual DbSet<WAXTREE> WAXTREES { get; set; }
        public virtual DbSet<OM_VALID_TIME_RECORDS> OM_VALID_TIME_RECORDS { get; set; }
        public virtual DbSet<Maintenace1> Maintenace1 { get; set; }
        public virtual DbSet<OM_CASTING_AGING> OM_CASTING_AGING { get; set; }
        public virtual DbSet<OM_CASTING_BILLING> OM_CASTING_BILLING { get; set; }
        public virtual DbSet<OM_CASTING_COMU_LABOUR> OM_CASTING_COMU_LABOUR { get; set; }
        public virtual DbSet<OM_CASTING_COMU_SELL_MAT> OM_CASTING_COMU_SELL_MAT { get; set; }
        public virtual DbSet<OM_CASTING_DELIVERY_MAT_SUMMARY> OM_CASTING_DELIVERY_MAT_SUMMARY { get; set; }
        public virtual DbSet<OM_CASTING_GRV_INFO> OM_CASTING_GRV_INFO { get; set; }
        public virtual DbSet<OM_CASTING_GRV_SUMMARY> OM_CASTING_GRV_SUMMARY { get; set; }
        public virtual DbSet<OM_CASTING_INV_COLLECTED> OM_CASTING_INV_COLLECTED { get; set; }
        public virtual DbSet<OM_CASTING_ITEMPRICE> OM_CASTING_ITEMPRICE { get; set; }
        public virtual DbSet<OM_CASTING_JOB> OM_CASTING_JOB { get; set; }
        public virtual DbSet<OM_CASTING_LABOUR> OM_CASTING_LABOUR { get; set; }
        public virtual DbSet<OM_CASTING_PENDING_BILL> OM_CASTING_PENDING_BILL { get; set; }
        public virtual DbSet<OM_CASTING_SALES> OM_CASTING_SALES { get; set; }
        public virtual DbSet<OM_CASTING_SELL_MAT> OM_CASTING_SELL_MAT { get; set; }
        public virtual DbSet<OM_CASTING_SO> OM_CASTING_SO { get; set; }
        public virtual DbSet<OM_CASTING_SUM_AGING> OM_CASTING_SUM_AGING { get; set; }
        public virtual DbSet<OM_CASTING_SUMMARY> OM_CASTING_SUMMARY { get; set; }
        public virtual DbSet<OM_DELIVERY_CASTING_ITEM_R> OM_DELIVERY_CASTING_ITEM_R { get; set; }
        public virtual DbSet<OM_ERP_CUSTOMER> OM_ERP_CUSTOMER { get; set; }
        public virtual DbSet<OM_ERP_DOCINFO> OM_ERP_DOCINFO { get; set; }
        public virtual DbSet<OM_ERP_PRODUCTION_DOCYEAR> OM_ERP_PRODUCTION_DOCYEAR { get; set; }
        public virtual DbSet<OM_ERP_PRODUCTION_ISSUE_REQ> OM_ERP_PRODUCTION_ISSUE_REQ { get; set; }
        public virtual DbSet<OM_ERP_PRODUCTION_PROJECT> OM_ERP_PRODUCTION_PROJECT { get; set; }
        public virtual DbSet<OM_ERP_PRODUCTION_REQLIST> OM_ERP_PRODUCTION_REQLIST { get; set; }
        public virtual DbSet<OM_ERP_SKU_BALANCE> OM_ERP_SKU_BALANCE { get; set; }
        public virtual DbSet<OM_ERP_STOCK_MOVE> OM_ERP_STOCK_MOVE { get; set; }
        public virtual DbSet<OM_ERP_TRH_TRD> OM_ERP_TRH_TRD { get; set; }
        public virtual DbSet<OM_ERP_WH_ISSUE_ITEMS> OM_ERP_WH_ISSUE_ITEMS { get; set; }
        public virtual DbSet<OM_ERP_WH_STOCK_ITEM_INFO> OM_ERP_WH_STOCK_ITEM_INFO { get; set; }
        public virtual DbSet<OM_FS_VALIDTIME_RECORDS> OM_FS_VALIDTIME_RECORDS { get; set; }
        public virtual DbSet<OM_JOB_ITEM_R> OM_JOB_ITEM_R { get; set; }
        public virtual DbSet<OM_PRODUCTION_MISS_REPORT> OM_PRODUCTION_MISS_REPORT { get; set; }
        public virtual DbSet<OM_PRODUCTION_WORKINGTIMES> OM_PRODUCTION_WORKINGTIMES { get; set; }
        public virtual DbSet<OM_SALE_MC_RECORD> OM_SALE_MC_RECORD { get; set; }
        public virtual DbSet<OM_SRV_MACHINE_SERVICE> OM_SRV_MACHINE_SERVICE { get; set; }
        public virtual DbSet<OM_SRV_SERVICE_INCOME> OM_SRV_SERVICE_INCOME { get; set; }
        public virtual DbSet<OM_SRV_SPAREPART_INCOME> OM_SRV_SPAREPART_INCOME { get; set; }
        public virtual DbSet<OM_SUM_DEL_CASTING_R> OM_SUM_DEL_CASTING_R { get; set; }
        public virtual DbSet<OM_VSERVICEJOBLIST> OM_VSERVICEJOBLIST { get; set; }
        public virtual DbSet<TVIEW_JOBORDERS> TVIEW_JOBORDERS { get; set; }
        public virtual DbSet<LOGIN> LOGINs { get; set; }
        public virtual DbSet<EMPSAL> EMPSALs { get; set; }
        public virtual DbSet<PRODUCTION_OUTSOURCE> PRODUCTION_OUTSOURCE { get; set; }
        public virtual DbSet<OM_ERP_PRODUCTION_TRANSFER_REQUEST> OM_ERP_PRODUCTION_TRANSFER_REQUEST { get; set; }
        public virtual DbSet<OM_ERP_PRODUCTION_REQUEST_TRANSFER_LIST> OM_ERP_PRODUCTION_REQUEST_TRANSFER_LIST { get; set; }
        public virtual DbSet<SYSDATA> SYSDATAs { get; set; }
        public virtual DbSet<CUSTPRICETAB> CUSTPRICETABs { get; set; }
        public virtual DbSet<SOLINE> SOLINES { get; set; }
        public virtual DbSet<PRODUCTION_WH_RECEIVE> PRODUCTION_WH_RECEIVE { get; set; }
        public virtual DbSet<PRODUCTION_MACHINEGROUP> PRODUCTION_MACHINEGROUP { get; set; }
        public virtual DbSet<PRODUCTION_MC_MEMBER> PRODUCTION_MC_MEMBER { get; set; }
        public virtual DbSet<PRDPROCESS> PRDPROCESSes { get; set; }
        public virtual DbSet<PRODUCTIONJOBINFO> PRODUCTIONJOBINFOes { get; set; }
        public virtual DbSet<PRODUCTIONJOB> PRODUCTIONJOBS { get; set; }
        public virtual DbSet<QUOTATIONHH> QUOTATIONHHs { get; set; }
    
        public virtual ObjectResult<usp_GetServiceJobList_Result> usp_GetServiceJobList(Nullable<int> selectedYear, string jobcode, string orderstatus)
        {
            var selectedYearParameter = selectedYear.HasValue ?
                new ObjectParameter("selectedYear", selectedYear) :
                new ObjectParameter("selectedYear", typeof(int));
    
            var jobcodeParameter = jobcode != null ?
                new ObjectParameter("jobcode", jobcode) :
                new ObjectParameter("jobcode", typeof(string));
    
            var orderstatusParameter = orderstatus != null ?
                new ObjectParameter("orderstatus", orderstatus) :
                new ObjectParameter("orderstatus", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetServiceJobList_Result>("usp_GetServiceJobList", selectedYearParameter, jobcodeParameter, orderstatusParameter);
        }
    
        public virtual ObjectResult<usp_ValidTimeRecord_Result> usp_ValidTimeRecord(string empCode, Nullable<int> y, Nullable<int> m, Nullable<int> d)
        {
            var empCodeParameter = empCode != null ?
                new ObjectParameter("EmpCode", empCode) :
                new ObjectParameter("EmpCode", typeof(string));
    
            var yParameter = y.HasValue ?
                new ObjectParameter("Y", y) :
                new ObjectParameter("Y", typeof(int));
    
            var mParameter = m.HasValue ?
                new ObjectParameter("M", m) :
                new ObjectParameter("M", typeof(int));
    
            var dParameter = d.HasValue ?
                new ObjectParameter("D", d) :
                new ObjectParameter("D", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_ValidTimeRecord_Result>("usp_ValidTimeRecord", empCodeParameter, yParameter, mParameter, dParameter);
        }
    }
}
