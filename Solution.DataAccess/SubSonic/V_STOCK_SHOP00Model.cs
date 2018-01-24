 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// V_STOCK_SHOP00表实体类
    /// </summary>
    public partial class V_STOCK_SHOP00
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

		string _SHOP_NAME1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_NAME1
		{
			get { return _SHOP_NAME1; }
			set { _SHOP_NAME1 = value; }
		}

		string _STOCK_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string STOCK_ID
		{
			get { return _STOCK_ID; }
			set { _STOCK_ID = value; }
		}

		string _STOCK_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string STOCK_NAME
		{
			get { return _STOCK_NAME; }
			set { _STOCK_NAME = value; }
		}

		byte _IsDefBill = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsDefBill
		{
			get { return _IsDefBill; }
			set { _IsDefBill = value; }
		}

		byte _IsBool = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsBool
		{
			get { return _IsBool; }
			set { _IsBool = value; }
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

		int _Stock_Kind = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Stock_Kind
		{
			get { return _Stock_Kind; }
			set { _Stock_Kind = value; }
		}

		string _Stock_Kind_Name = "";
		/// <summary>
		/// 
		/// </summary>
		public string Stock_Kind_Name
		{
			get { return _Stock_Kind_Name; }
			set { _Stock_Kind_Name = value; }
		}
    } 

}


