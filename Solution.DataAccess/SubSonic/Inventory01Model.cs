 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Inventory01表实体类
    /// </summary>
    public partial class Inventory01
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

		string _INV_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string INV_ID
		{
			get { return _INV_ID; }
			set { _INV_ID = value; }
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

		double _QUANTITY = 0;
		/// <summary>
		/// 
		/// </summary>
		public double QUANTITY
		{
			get { return _QUANTITY; }
			set { _QUANTITY = value; }
		}

		double _QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public double QUAN
		{
			get { return _QUAN; }
			set { _QUAN = value; }
		}

		double _QUAN1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public double QUAN1
		{
			get { return _QUAN1; }
			set { _QUAN1 = value; }
		}

		double _QUAN2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public double QUAN2
		{
			get { return _QUAN2; }
			set { _QUAN2 = value; }
		}

		double _QUAN_B = 0;
		/// <summary>
		/// 
		/// </summary>
		public double QUAN_B
		{
			get { return _QUAN_B; }
			set { _QUAN_B = value; }
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
    } 

}


