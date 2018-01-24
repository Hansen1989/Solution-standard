 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// V_ORDERDEP02_PRODDEP表实体类
    /// </summary>
    public partial class V_ORDERDEP02_PRODDEP
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

		string _ORDDEP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string ORDDEP_ID
		{
			get { return _ORDDEP_ID; }
			set { _ORDDEP_ID = value; }
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

		string _DEP_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEP_NAME
		{
			get { return _DEP_NAME; }
			set { _DEP_NAME = value; }
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
    } 

}


