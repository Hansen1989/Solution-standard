 
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
		/// 
		/// </summary>
		public string SHOP_ID
		{
			get { return _SHOP_ID; }
			set { _SHOP_ID = value; }
		}

		string _BILL_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string BILL_ID
		{
			get { return _BILL_ID; }
			set { _BILL_ID = value; }
		}

		int _STATUS = 0;
		/// <summary>
		/// 
		/// </summary>
		public int STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}

		DateTime _INPUT_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime INPUT_DATE
		{
			get { return _INPUT_DATE; }
			set { _INPUT_DATE = value; }
		}

		string _IN_SHOP = "";
		/// <summary>
		/// 
		/// </summary>
		public string IN_SHOP
		{
			get { return _IN_SHOP; }
			set { _IN_SHOP = value; }
		}

		string _USER_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string USER_ID
		{
			get { return _USER_ID; }
			set { _USER_ID = value; }
		}

		string _APP_USER = "";
		/// <summary>
		/// 
		/// </summary>
		public string APP_USER
		{
			get { return _APP_USER; }
			set { _APP_USER = value; }
		}

		DateTime _APP_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime APP_DATETIME
		{
			get { return _APP_DATETIME; }
			set { _APP_DATETIME = value; }
		}

		string _MEMO = "";
		/// <summary>
		/// 
		/// </summary>
		public string MEMO
		{
			get { return _MEMO; }
			set { _MEMO = value; }
		}

		DateTime _CRT_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime CRT_DATETIME
		{
			get { return _CRT_DATETIME; }
			set { _CRT_DATETIME = value; }
		}

		string _CRT_USER_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string CRT_USER_ID
		{
			get { return _CRT_USER_ID; }
			set { _CRT_USER_ID = value; }
		}

		DateTime _MOD_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime MOD_DATETIME
		{
			get { return _MOD_DATETIME; }
			set { _MOD_DATETIME = value; }
		}

		string _MOD_USER_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string MOD_USER_ID
		{
			get { return _MOD_USER_ID; }
			set { _MOD_USER_ID = value; }
		}

		DateTime _LAST_UPDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime LAST_UPDATE
		{
			get { return _LAST_UPDATE; }
			set { _LAST_UPDATE = value; }
		}

		decimal _BILL_AMOUNT = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal BILL_AMOUNT
		{
			get { return _BILL_AMOUNT; }
			set { _BILL_AMOUNT = value; }
		}

		decimal _BILL_COST = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal BILL_COST
		{
			get { return _BILL_COST; }
			set { _BILL_COST = value; }
		}

		int _BILL_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int BILL_TYPE
		{
			get { return _BILL_TYPE; }
			set { _BILL_TYPE = value; }
		}
    } 

}


