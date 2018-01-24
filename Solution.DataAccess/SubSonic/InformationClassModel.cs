 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// InformationClass表实体类
    /// </summary>
    public partial class InformationClass
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

		string _Name = "";
		/// <summary>
		/// 信息名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		string _Content = "";
		/// <summary>
		/// 描述
		/// </summary>
		public string Content
		{
			get { return _Content; }
			set { _Content = value; }
		}

		byte _IsSys = 0;
		/// <summary>
		/// 1=系统分类（不能删除，不能添加文章，但可以添加子分类）
		/// </summary>
		public byte IsSys
		{
			get { return _IsSys; }
			set { _IsSys = value; }
		}

		string _BigPicImg = "";
		/// <summary>
		/// 分类大图
		/// </summary>
		public string BigPicImg
		{
			get { return _BigPicImg; }
			set { _BigPicImg = value; }
		}

		string _SmallPicImg = "";
		/// <summary>
		/// 分类小图
		/// </summary>
		public string SmallPicImg
		{
			get { return _SmallPicImg; }
			set { _SmallPicImg = value; }
		}

		byte _IsShow = 0;
		/// <summary>
		/// 是否显示, 0=False,1=True,
		/// </summary>
		public byte IsShow
		{
			get { return _IsShow; }
			set { _IsShow = value; }
		}

		byte _IsPage = 0;
		/// <summary>
		/// 是否为单页,单页，没有文章封面，没有发表者，也不能评论
		/// </summary>
		public byte IsPage
		{
			get { return _IsPage; }
			set { _IsPage = value; }
		}

		int _RootId = 0;
		/// <summary>
		/// 分类顶层id
		/// </summary>
		public int RootId
		{
			get { return _RootId; }
			set { _RootId = value; }
		}

		int _ParentId = 0;
		/// <summary>
		/// 父id
		/// </summary>
		public int ParentId
		{
			get { return _ParentId; }
			set { _ParentId = value; }
		}

		int _Depth = 0;
		/// <summary>
		/// 层数
		/// </summary>
		public int Depth
		{
			get { return _Depth; }
			set { _Depth = value; }
		}

		int _Sort = 0;
		/// <summary>
		/// 排序
		/// </summary>
		public int Sort
		{
			get { return _Sort; }
			set { _Sort = value; }
		}

		string _SeoTitle = "";
		/// <summary>
		/// Seo标题
		/// </summary>
		public string SeoTitle
		{
			get { return _SeoTitle; }
			set { _SeoTitle = value; }
		}

		string _SeoKey = "";
		/// <summary>
		/// Seo关键字(搜索文章)
		/// </summary>
		public string SeoKey
		{
			get { return _SeoKey; }
			set { _SeoKey = value; }
		}

		string _SeoDesc = "";
		/// <summary>
		/// Seo描述
		/// </summary>
		public string SeoDesc
		{
			get { return _SeoDesc; }
			set { _SeoDesc = value; }
		}

		DateTime _AddDate = new DateTime(1900,1,1);
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime AddDate
		{
			get { return _AddDate; }
			set { _AddDate = value; }
		}

		int _Manager_Id = 0;
		/// <summary>
		/// 修改人员id
		/// </summary>
		public int Manager_Id
		{
			get { return _Manager_Id; }
			set { _Manager_Id = value; }
		}

		string _Manager_CName = "";
		/// <summary>
		/// 修改人员姓名
		/// </summary>
		public string Manager_CName
		{
			get { return _Manager_CName; }
			set { _Manager_CName = value; }
		}

		DateTime _UpdateDate = new DateTime(1900,1,1);
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime UpdateDate
		{
			get { return _UpdateDate; }
			set { _UpdateDate = value; }
		}
    } 

}


