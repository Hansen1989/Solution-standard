 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// PROD_Cate表实体类
    /// </summary>
    public partial class PROD_Cate
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

		string _CATE_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string CATE_ID
		{
			get { return _CATE_ID; }
			set { _CATE_ID = value; }
		}

		string _CATE_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string CATE_NAME
		{
			get { return _CATE_NAME; }
			set { _CATE_NAME = value; }
		}

		byte _ENABLE = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte ENABLE
		{
			get { return _ENABLE; }
			set { _ENABLE = value; }
		}

		string _DEP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEP_ID
		{
			get { return _DEP_ID; }
			set { _DEP_ID = value; }
		}

		byte _IsBool1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsBool1
		{
			get { return _IsBool1; }
			set { _IsBool1 = value; }
		}

		byte _IsBool2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsBool2
		{
			get { return _IsBool2; }
			set { _IsBool2 = value; }
		}

		byte _IsBool3 = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsBool3
		{
			get { return _IsBool3; }
			set { _IsBool3 = value; }
		}

		string _CATE_MEMO = "";
		/// <summary>
		/// 
		/// </summary>
		public string CATE_MEMO
		{
			get { return _CATE_MEMO; }
			set { _CATE_MEMO = value; }
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

		bool _STATUS = true;
		/// <summary>
		/// 
		/// </summary>
		public bool STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}
    } 

}


