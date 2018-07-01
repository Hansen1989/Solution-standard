 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// DUE00表实体类
    /// </summary>
    public partial class DUE00
    {

		int _Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _SHOP_ID = "";
		/// <summary>
		/// 店铺编号
		/// </summary>
		public string SHOP_ID
		{
			get { return _SHOP_ID; }
			set { _SHOP_ID = value; }
		}

		string _TAKEIN_ID = "";
		/// <summary>
		/// 进货单
		/// </summary>
		public string TAKEIN_ID
		{
			get { return _TAKEIN_ID; }
			set { _TAKEIN_ID = value; }
		}

		byte _STATUS = 0;
		/// <summary>
		/// 应付账单状态
		/// </summary>
		public byte STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}

		DateTime _INPUT_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 进货单日期
		/// </summary>
		public DateTime INPUT_DATE
		{
			get { return _INPUT_DATE; }
			set { _INPUT_DATE = value; }
		}

		string _SUP_ID = "";
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string SUP_ID
		{
			get { return _SUP_ID; }
			set { _SUP_ID = value; }
		}

		string _USER_ID = "";
		/// <summary>
		/// 进货单制单人
		/// </summary>
		public string USER_ID
		{
			get { return _USER_ID; }
			set { _USER_ID = value; }
		}

		string _APP_USER = "";
		/// <summary>
		/// 进货单审核人
		/// </summary>
		public string APP_USER
		{
			get { return _APP_USER; }
			set { _APP_USER = value; }
		}

		DateTime _APP_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime APP_DATETIME
		{
			get { return _APP_DATETIME; }
			set { _APP_DATETIME = value; }
		}

		decimal _TOT_AMOUNT = 0;
		/// <summary>
		/// 进货单金额
		/// </summary>
		public decimal TOT_AMOUNT
		{
			get { return _TOT_AMOUNT; }
			set { _TOT_AMOUNT = value; }
		}

		decimal _TOT_TAX = 0;
		/// <summary>
		/// 采购总税额
		/// </summary>
		public decimal TOT_TAX
		{
			get { return _TOT_TAX; }
			set { _TOT_TAX = value; }
		}

		decimal _TOT_QTY = 0;
		/// <summary>
		/// 采购总数量
		/// </summary>
		public decimal TOT_QTY
		{
			get { return _TOT_QTY; }
			set { _TOT_QTY = value; }
		}

		decimal _PRE_PAY = 0;
		/// <summary>
		/// 采购预付款
		/// </summary>
		public decimal PRE_PAY
		{
			get { return _PRE_PAY; }
			set { _PRE_PAY = value; }
		}

		string _PRE_PAY_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string PRE_PAY_ID
		{
			get { return _PRE_PAY_ID; }
			set { _PRE_PAY_ID = value; }
		}

		string _RELATE_ID = "";
		/// <summary>
		/// 关联单号
		/// </summary>
		public string RELATE_ID
		{
			get { return _RELATE_ID; }
			set { _RELATE_ID = value; }
		}

		string _INVOICE_ID = "";
		/// <summary>
		/// 发票号码
		/// </summary>
		public string INVOICE_ID
		{
			get { return _INVOICE_ID; }
			set { _INVOICE_ID = value; }
		}

		int _TAKEIN_TYPE = 0;
		/// <summary>
		/// 进货类型
		/// </summary>
		public int TAKEIN_TYPE
		{
			get { return _TAKEIN_TYPE; }
			set { _TAKEIN_TYPE = value; }
		}

		string _Memo = "";
		/// <summary>
		/// 备注
		/// </summary>
		public string Memo
		{
			get { return _Memo; }
			set { _Memo = value; }
		}

		DateTime _CRT_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 建档日期
		/// </summary>
		public DateTime CRT_DATETIME
		{
			get { return _CRT_DATETIME; }
			set { _CRT_DATETIME = value; }
		}

		string _CRT_USER_ID = "";
		/// <summary>
		/// 建档人员
		/// </summary>
		public string CRT_USER_ID
		{
			get { return _CRT_USER_ID; }
			set { _CRT_USER_ID = value; }
		}

		DateTime _MOD_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 修改日期
		/// </summary>
		public DateTime MOD_DATETIME
		{
			get { return _MOD_DATETIME; }
			set { _MOD_DATETIME = value; }
		}

		string _MOD_USER_ID = "";
		/// <summary>
		/// 修改人员
		/// </summary>
		public string MOD_USER_ID
		{
			get { return _MOD_USER_ID; }
			set { _MOD_USER_ID = value; }
		}

		DateTime _LAST_UPDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 最后异动时间
		/// </summary>
		public DateTime LAST_UPDATE
		{
			get { return _LAST_UPDATE; }
			set { _LAST_UPDATE = value; }
		}
    } 

}


