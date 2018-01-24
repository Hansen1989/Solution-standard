 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// COL_ORDER01表实体类
    /// </summary>
    public partial class COL_ORDER01
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

		string _COL_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string COL_ID
		{
			get { return _COL_ID; }
			set { _COL_ID = value; }
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
    } 

}


