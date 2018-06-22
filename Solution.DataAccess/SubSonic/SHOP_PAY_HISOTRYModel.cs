 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// SHOP_PAY_HISOTRY表实体类
    /// </summary>
    public partial class SHOP_PAY_HISOTRY
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

		string _Head_SHOP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string Head_SHOP_ID
		{
			get { return _Head_SHOP_ID; }
			set { _Head_SHOP_ID = value; }
		}

		long _BILL_ID = 0;
		/// <summary>
		/// 
		/// </summary>
		public long BILL_ID
		{
			get { return _BILL_ID; }
			set { _BILL_ID = value; }
		}

		string _AMOUNT = "";
		/// <summary>
		/// 
		/// </summary>
		public string AMOUNT
		{
			get { return _AMOUNT; }
			set { _AMOUNT = value; }
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

		string _PAYER = "";
		/// <summary>
		/// 
		/// </summary>
		public string PAYER
		{
			get { return _PAYER; }
			set { _PAYER = value; }
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


