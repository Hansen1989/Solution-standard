 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// PagePowerSignPublic表实体类
    /// </summary>
    public partial class PagePowerSignPublic
    {

		int _Id = 0;
		/// <summary>
		/// 主键Id
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _Cname = "";
		/// <summary>
		/// 权限中文名称
		/// </summary>
		public string Cname
		{
			get { return _Cname; }
			set { _Cname = value; }
		}

		string _Ename = "";
		/// <summary>
		/// 权限英文名称
		/// </summary>
		public string Ename
		{
			get { return _Ename; }
			set { _Ename = value; }
		}
    } 

}


