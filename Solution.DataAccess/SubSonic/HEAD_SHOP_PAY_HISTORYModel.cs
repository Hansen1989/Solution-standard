 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// HEAD_SHOP_PAY_HISTORY表实体类
    /// </summary>
    public partial class HEAD_SHOP_PAY_HISTORY
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
		/// 
		/// </summary>
		public string SHOP_ID
		{
			get { return _SHOP_ID; }
			set { _SHOP_ID = value; }
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

		string _SUP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_ID
		{
			get { return _SUP_ID; }
			set { _SUP_ID = value; }
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

		decimal _PAY_AMOUNT = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal PAY_AMOUNT
		{
			get { return _PAY_AMOUNT; }
			set { _PAY_AMOUNT = value; }
		}

		byte _PAY_METHOD = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte PAY_METHOD
		{
			get { return _PAY_METHOD; }
			set { _PAY_METHOD = value; }
		}

		DateTime _BILL_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime BILL_DATE
		{
			get { return _BILL_DATE; }
			set { _BILL_DATE = value; }
		}

		DateTime _PAY_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime PAY_DATE
		{
			get { return _PAY_DATE; }
			set { _PAY_DATE = value; }
		}

		string _Memo = "";
		/// <summary>
		/// 
		/// </summary>
		public string Memo
		{
			get { return _Memo; }
			set { _Memo = value; }
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
    } 

}


