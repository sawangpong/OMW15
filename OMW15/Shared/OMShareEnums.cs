namespace OMW15.Shared
{
	public enum PrintDocumentType
	{
		None,
		JobOrder,
		JobOrders,
		JobQC,
		JobSummary,
		JobProgress,
		SaleOrderWithVAT,
		SaleOrderNoVAT,
		SaleMaterialWithVAT,
		SaleMaterialNoVAT,
		SaleOfferEN,
		SaleOfferTH,
		SalePI,
		SaleInvoiceTH,
		SaleInvoiceEN,
		BillingSaleOrder,
		BillingSaleMaterial,
		WaxTreeWeight,
		WaxTrssWeightLoss,
		CastingMonthlyReportByCustomerAndMaterial,
		CastingMonthlyReportByCustomerGroup,
		CastingMonthlyReportByDocNo,
		CastingMonthlySaleMaterialReport,
		CastingDeliveryReport,
		CastingSaleMaterialReport,
		CastingMonthlyReportByMaterial,
		SIReport,
		MaterialCard,
		WorkSummary
	}

	//public enum ControlActionEnum
	//{
	//	ButtonAction,
	//	LabelAction
	//}

	public enum MachineHistoryDisplayStyle
	{
		DisplayNone,
		DisplayByCustomer,
		DisplayByProduct,
		DisplayOrderForm,
		DisplayHistory,
		DisplayHistories,
		DisplayHistoryByOrderNo,
		DisplayHistoryByMachine
	}

	//public enum QutationStatus
	//{
	//	Hold = 0,
	//	Active = 1,
	//	Complete = 2,
	//	Cancel = 3,
	//	All = 4
	//}

	public enum ActionMode
	{
		None = 0,
		Add = 1,
		Edit = 2,
		Delete = 3,
		Cancel = 4,
		View = 5,
		Selection = 6,
		Recording = 7
	}

	//public enum MasterStockSearchTypeEnum
	//{
	//	ITEMNO,
	//	DESCRIPTION
	//}

	//public enum ControlRenderStyle
	//{
	//	Custom,
	//	Office2003,
	//	Office2007,
	//	Draw3D
	//}

	//public enum ControlState
	//{
	//	Passive,
	//	Hovering,
	//	Selected
	//}

	//public enum MachineStatusEnum
	//{
	//	UsedMachine = 0,
	//	NewMachine = 1
	//}

	//public enum AppWorkenum
	//{
	//	NoWorkSelected,
	//	AfterSaleAndService,
	//	PreventiveMaintenance,
	//	Services,
	//	WarrantyService,
	//	Production
	//}

	//public enum ShowErrorStyle
	//{
	//	Debug,
	//	Error,
	//	Information,
	//	Message,
	//	Alert,
	//	None
	//}

	public enum SelectTypeOption
	{
		None,
		Country,
		Currency,
		Customer,
		Department,
		District,
		Province,
		ProductStyle,
		ItemNo,
		ItemImage,
		UnitCount,
		Material,
		VatRate,
		SaleMan,
		SaleType,
		CastingCode,
		WorkerByCode,
		WorkerById,
		Sex,
		FamilyStatus,
		JobStatus,
		ProductionProcess
	}

	public enum InputBoxTypeValue
	{
		Text,
		Number
	}

	public enum SexEN
	{
		Male = 1,
		FeeMale = 2
	}

	public enum SexTH
	{
		ชาย = 1,
		หญิง = 2
	}

	public enum PersonTitleTH
	{
		นาย = 1,
		นางสาว = 2,
		นาง = 3
	}

	public enum MonthList
	{
		January = 1,
		Febuary = 2,
		March = 3,
		April = 4,
		May = 5,
		June = 6,
		July = 7,
		August = 8,
		September = 9,
		October = 10,
		November = 11,
		December = 12
	}

	public enum EmployeeStatus
	{
		All = 0,
		Active = 1,
		Resigned =2
	}
}