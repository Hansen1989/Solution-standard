 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// SHOP_SUPPLIER_RELATION表实体类
    /// </summary>
    public partial class SHOP_SUPPLIER_RELATION
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
		/// 分店编号
		/// </summary>
		public string SHOP_ID
		{
			get { return _SHOP_ID; }
			set { _SHOP_ID = value; }
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

		string _SUP_NAME = "";
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string SUP_NAME
		{
			get { return _SUP_NAME; }
			set { _SUP_NAME = value; }
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
		/// 创建时间
		/// </summary>
		public DateTime CRT_DATETIME
		{
			get { return _CRT_DATETIME; }
			set { _CRT_DATETIME = value; }
		}
    } 

}


