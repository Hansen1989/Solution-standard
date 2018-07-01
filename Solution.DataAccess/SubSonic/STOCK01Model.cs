 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// STOCK01表实体类
    /// </summary>
    public partial class STOCK01
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

		string _STOCK_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string STOCK_ID
		{
			get { return _STOCK_ID; }
			set { _STOCK_ID = value; }
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

		decimal _STOCK_UNIT_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal STOCK_UNIT_QUAN
		{
			get { return _STOCK_UNIT_QUAN; }
			set { _STOCK_UNIT_QUAN = value; }
		}

		decimal _STOCK_UNIT1_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal STOCK_UNIT1_QUAN
		{
			get { return _STOCK_UNIT1_QUAN; }
			set { _STOCK_UNIT1_QUAN = value; }
		}

		decimal _STOCK_UNIT2_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal STOCK_UNIT2_QUAN
		{
			get { return _STOCK_UNIT2_QUAN; }
			set { _STOCK_UNIT2_QUAN = value; }
		}

		byte _USABLE = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte USABLE
		{
			get { return _USABLE; }
			set { _USABLE = value; }
		}

		string _Meno = "";
		/// <summary>
		/// 
		/// </summary>
		public string Meno
		{
			get { return _Meno; }
			set { _Meno = value; }
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

		string _SHOP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_ID
		{
			get { return _SHOP_ID; }
			set { _SHOP_ID = value; }
		}
    } 

}


