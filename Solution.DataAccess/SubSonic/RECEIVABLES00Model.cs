 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// RECEIVABLES00表实体类
    /// </summary>
    public partial class RECEIVABLES00
    {

		long _Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _SHOP_ID = "";
		/// <summary>
		/// 总店编号
		/// </summary>
		public string SHOP_ID
		{
			get { return _SHOP_ID; }
			set { _SHOP_ID = value; }
		}

		string _OUT_ID = "";
		/// <summary>
		/// 出货单编号
		/// </summary>
		public string OUT_ID
		{
			get { return _OUT_ID; }
			set { _OUT_ID = value; }
		}

		byte _STATUS = 0;
		/// <summary>
		/// 账单状态
		/// </summary>
		public byte STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}

		DateTime _INPUT_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 出货单日期
		/// </summary>
		public DateTime INPUT_DATE
		{
			get { return _INPUT_DATE; }
			set { _INPUT_DATE = value; }
		}

		string _IN_SHOP = "";
		/// <summary>
		/// 分店编号
		/// </summary>
		public string IN_SHOP
		{
			get { return _IN_SHOP; }
			set { _IN_SHOP = value; }
		}

		string _USER_ID = "";
		/// <summary>
		/// 出货单制单人
		/// </summary>
		public string USER_ID
		{
			get { return _USER_ID; }
			set { _USER_ID = value; }
		}

		string _APP_USER = "";
		/// <summary>
		/// 出货单审核人
		/// </summary>
		public string APP_USER
		{
			get { return _APP_USER; }
			set { _APP_USER = value; }
		}

		DateTime _APP_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 出货单审核时间
		/// </summary>
		public DateTime APP_DATETIME
		{
			get { return _APP_DATETIME; }
			set { _APP_DATETIME = value; }
		}

		string _MEMO = "";
		/// <summary>
		/// 备注
		/// </summary>
		public string MEMO
		{
			get { return _MEMO; }
			set { _MEMO = value; }
		}

		DateTime _CRT_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 建档时间
		/// </summary>
		public DateTime CRT_DATETIME
		{
			get { return _CRT_DATETIME; }
			set { _CRT_DATETIME = value; }
		}

		string _CRT_USER_ID = "";
		/// <summary>
		/// 建档人
		/// </summary>
		public string CRT_USER_ID
		{
			get { return _CRT_USER_ID; }
			set { _CRT_USER_ID = value; }
		}

		DateTime _MOD_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime MOD_DATETIME
		{
			get { return _MOD_DATETIME; }
			set { _MOD_DATETIME = value; }
		}

		string _MOD_USER_ID = "";
		/// <summary>
		/// 修改人
		/// </summary>
		public string MOD_USER_ID
		{
			get { return _MOD_USER_ID; }
			set { _MOD_USER_ID = value; }
		}

		DateTime _LAST_UPDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime LAST_UPDATE
		{
			get { return _LAST_UPDATE; }
			set { _LAST_UPDATE = value; }
		}

		decimal _BILL_AMOUNT = 0;
		/// <summary>
		/// 账单金额
		/// </summary>
		public decimal BILL_AMOUNT
		{
			get { return _BILL_AMOUNT; }
			set { _BILL_AMOUNT = value; }
		}

		decimal _BILL_COST = 0;
		/// <summary>
		/// 出货成本
		/// </summary>
		public decimal BILL_COST
		{
			get { return _BILL_COST; }
			set { _BILL_COST = value; }
		}
    } 

}


