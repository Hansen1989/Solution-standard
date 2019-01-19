 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// ORDER01表实体类
    /// </summary>
    public partial class ORDER01
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

		string _ORDER_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string ORDER_ID
		{
			get { return _ORDER_ID; }
			set { _ORDER_ID = value; }
		}

		int _SNo = 0;
		/// <summary>
		/// 
		/// </summary>
		public int SNo
		{
			get { return _SNo; }
			set { _SNo = value; }
		}

		string _PROD_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string PROD_ID
		{
			get { return _PROD_ID; }
			set { _PROD_ID = value; }
		}

		decimal _QUANTITY = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal QUANTITY
		{
			get { return _QUANTITY; }
			set { _QUANTITY = value; }
		}

		decimal _ON_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal ON_QUAN
		{
			get { return _ON_QUAN; }
			set { _ON_QUAN = value; }
		}

		decimal _QUAN1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal QUAN1
		{
			get { return _QUAN1; }
			set { _QUAN1 = value; }
		}

		decimal _QUAN2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal QUAN2
		{
			get { return _QUAN2; }
			set { _QUAN2 = value; }
		}

		decimal _COST_PRICE = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal COST_PRICE
		{
			get { return _COST_PRICE; }
			set { _COST_PRICE = value; }
		}

		string _STD_UNIT = "";
		/// <summary>
		/// 
		/// </summary>
		public string STD_UNIT
		{
			get { return _STD_UNIT; }
			set { _STD_UNIT = value; }
		}

		int _STD_CONVERT = 0;
		/// <summary>
		/// 
		/// </summary>
		public int STD_CONVERT
		{
			get { return _STD_CONVERT; }
			set { _STD_CONVERT = value; }
		}

		decimal _STD_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal STD_QUAN
		{
			get { return _STD_QUAN; }
			set { _STD_QUAN = value; }
		}

		decimal _STD_PRICE = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal STD_PRICE
		{
			get { return _STD_PRICE; }
			set { _STD_PRICE = value; }
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
    } 

}


