using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

namespace Solution.Logic.Managers {
	/// <summary>
	/// V_Purchase00_SHOP00表逻辑类
	/// </summary>
	public partial class V_Purchase00_SHOP00Bll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函数                                                        *
		 ***********************************************************************/
		#region 模版生成函数
				
		private const string const_CacheKey = "Cache_V_Purchase00_SHOP00";
        private const string const_CacheKey_Date = "Cache_V_Purchase00_SHOP00_Date";

		#region 单例模式
		//定义单例实体
		private static V_Purchase00_SHOP00Bll _V_Purchase00_SHOP00Bll = null;

		/// <summary>
		/// 获取本逻辑类单例
		/// </summary>
		/// <returns></returns>
		public static V_Purchase00_SHOP00Bll GetInstence() {
			if (_V_Purchase00_SHOP00Bll == null) {
				_V_Purchase00_SHOP00Bll = new V_Purchase00_SHOP00Bll();
			}
			return _V_Purchase00_SHOP00Bll;
		}
		#endregion
		
		#region 清空缓存
        /// <summary>清空缓存</summary>
        private void DelAllCache()
        {
            //清除模板缓存
            CacheHelper.RemoveOneCache(const_CacheKey);
			CacheHelper.RemoveOneCache(const_CacheKey_Date);

			//清除前台缓存
			CommonBll.RemoveCache(const_CacheKey);
			//运行自定义缓存清理程序
            DelCache();
        }
		#endregion

		#region IIS缓存函数
		
		#region 从IIS缓存中获取V_Purchase00_SHOP00表记录
		/// <summary>
        /// 从IIS缓存中获取V_Purchase00_SHOP00表记录
        /// </summary>
	    /// <param name="isCache">是否从缓存中读取</param>
        public IList<DataAccess.Model.V_Purchase00_SHOP00> GetList(bool isCache = true)
        {
			try
			{
				//判断是否使用缓存
				if (CommonBll.IsUseCache() && isCache){
					//检查指定缓存是否过期——缓存当天有效，第二天自动清空
					if (CommonBll.CheckCacheIsExpired(const_CacheKey_Date)){		        
						//删除缓存
						DelAllCache();
					}

					//从缓存中获取DataTable
					var obj = CacheHelper.GetCache(const_CacheKey);
					//如果缓存为null，则查询数据库
					if (obj == null)
					{
						var list = GetList(false);

						//将查询出来的数据存储到缓存中
                        CacheHelper.SetCache(const_CacheKey, list);
						//存储当前时间
						CacheHelper.SetCache(const_CacheKey_Date, DateTime.Now);

                        return list;
					}
					//缓存中存在数据，则直接返回
					else
					{
						return (IList<DataAccess.Model.V_Purchase00_SHOP00>)obj;
					}
				}
				else
				{
					//定义临时实体集
					IList<DataAccess.Model.V_Purchase00_SHOP00> list = null;

					//获取全表缓存加载条件表达式
					var exp = GetExpression<V_Purchase00_SHOP00>();
                    //如果条件为空，则查询全表所有记录
					if (exp == null)
					{
						//从数据库中获取所有记录
						var all = V_Purchase00_SHOP00.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //从数据库中查询出指定条件的记录，并转换为指定实体集
						var all = V_Purchase00_SHOP00.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //记录日志
                CommonBll.WriteLog("从IIS缓存中获取V_Purchase00_SHOP00表记录时出现异常", e);
			}
            
            return null;
        }
		#endregion

		#region 获取指定Id记录
		/// <summary>
        /// 获取指定Id记录
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="isCache">是否从缓存中读取</param>
		/// <returns>DataAccess.Model.V_Purchase00_SHOP00</returns>
        public DataAccess.Model.V_Purchase00_SHOP00 GetModel(long id, bool isCache = true)
        {
            //判断是否使用缓存
		    if (CommonBll.IsUseCache() && isCache)
		    {
                //从缓存中获取List
		        var list = GetList();
		        if (list == null)
		        {
		            return null;
		        }
		        else
		        {
                    //在List查询指定主键Id的记录
		            return list.SingleOrDefault(x => x.Id == id);
		        }
		    }
		    else
		    {
                //从数据库中直接读取
                var model = V_Purchase00_SHOP00.SingleOrDefault(x => x.Id == id);
                if (model == null)
                {
                    return null;
                }
                else
                {
                    //对查询出来的实体进行转换
                    return Transform(model);
                }
		    }
        }
		#endregion

		#region 从IIS缓存中获取指定Id记录
		/// <summary>
        /// 从IIS缓存中获取指定Id记录
        /// </summary>
        /// <param name="id">主键Id</param>
		/// <returns>DataAccess.Model.V_Purchase00_SHOP00</returns>
        public DataAccess.Model.V_Purchase00_SHOP00 GetModelForCache(long id)
        {
			try
			{
				//从缓存中读取指定Id记录
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//从数据库中读取
					var tem = V_Purchase00_SHOP00.SingleOrDefault(x => x.Id == id);
					if (tem == null)
					{
						return null;
					}
					else
					{
						//对查询出来的实体进行转换
						model = Transform(tem);
						return model;
					}
				}
				else
				{
					return model;
				}
			}
            catch (Exception e)
            {
                //记录日志
                CommonBll.WriteLog("从IIS缓存中获取V_Purchase00_SHOP00表记录时出现异常", e);

                return null;
            }
        }
		#endregion

		#region 从IIS缓存中获取指定条件的记录
        /// <summary>
        /// 从IIS缓存中获取指定Id记录
        /// </summary>
        /// <param name="conditionColName">条件列名</param>
        /// <param name="value">条件值</param>
        /// <returns>DataAccess.Model.V_Purchase00_SHOP00</returns>
        public DataAccess.Model.V_Purchase00_SHOP00 GetModelForCache(string conditionColName, object value)
        {
		try
            {
                //从缓存中获取List
                var list = GetList();
                DataAccess.Model.V_Purchase00_SHOP00 model = null;
                Expression<Func<V_Purchase00_SHOP00, bool>> expression = null;

                //返回指定条件的实体
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (int)value);
                        expression = x => x.Id == (int)value;
                        break;
					case "SHOP_ID" :
						model = list.SingleOrDefault(x => x.SHOP_ID == (string)value);
                        expression = x => x.SHOP_ID == (string)value;
                        break;
					case "Purchase_ID" :
						model = list.SingleOrDefault(x => x.Purchase_ID == (string)value);
                        expression = x => x.Purchase_ID == (string)value;
                        break;
					case "STATUS" :
						model = list.SingleOrDefault(x => x.STATUS == (int)value);
                        expression = x => x.STATUS == (int)value;
                        break;
					case "PAY_STATUS" :
						model = list.SingleOrDefault(x => x.PAY_STATUS == (int)value);
                        expression = x => x.PAY_STATUS == (int)value;
                        break;
					case "INPUT_DATE" :
						model = list.SingleOrDefault(x => x.INPUT_DATE == (DateTime)value);
                        expression = x => x.INPUT_DATE == (DateTime)value;
                        break;
					case "SUP_ID" :
						model = list.SingleOrDefault(x => x.SUP_ID == (string)value);
                        expression = x => x.SUP_ID == (string)value;
                        break;
					case "EXPECT_DATE" :
						model = list.SingleOrDefault(x => x.EXPECT_DATE == (DateTime)value);
                        expression = x => x.EXPECT_DATE == (DateTime)value;
                        break;
					case "USER_ID" :
						model = list.SingleOrDefault(x => x.USER_ID == (string)value);
                        expression = x => x.USER_ID == (string)value;
                        break;
					case "APP_USER" :
						model = list.SingleOrDefault(x => x.APP_USER == (string)value);
                        expression = x => x.APP_USER == (string)value;
                        break;
					case "APP_DATETIME" :
						model = list.SingleOrDefault(x => x.APP_DATETIME == (DateTime)value);
                        expression = x => x.APP_DATETIME == (DateTime)value;
                        break;
					case "TOT_AMOUNT" :
						model = list.SingleOrDefault(x => x.TOT_AMOUNT == (decimal)value);
                        expression = x => x.TOT_AMOUNT == (decimal)value;
                        break;
					case "TOT_TAX" :
						model = list.SingleOrDefault(x => x.TOT_TAX == (decimal)value);
                        expression = x => x.TOT_TAX == (decimal)value;
                        break;
					case "TOT_QTY" :
						model = list.SingleOrDefault(x => x.TOT_QTY == (decimal)value);
                        expression = x => x.TOT_QTY == (decimal)value;
                        break;
					case "PRE_PAY" :
						model = list.SingleOrDefault(x => x.PRE_PAY == (decimal)value);
                        expression = x => x.PRE_PAY == (decimal)value;
                        break;
					case "PRE_PAY_ID" :
						model = list.SingleOrDefault(x => x.PRE_PAY_ID == (string)value);
                        expression = x => x.PRE_PAY_ID == (string)value;
                        break;
					case "EXPORTED" :
						model = list.SingleOrDefault(x => x.EXPORTED == (byte)value);
                        expression = x => x.EXPORTED == (byte)value;
                        break;
					case "EXPORTED_ID" :
						model = list.SingleOrDefault(x => x.EXPORTED_ID == (string)value);
                        expression = x => x.EXPORTED_ID == (string)value;
                        break;
					case "Memo" :
						model = list.SingleOrDefault(x => x.Memo == (string)value);
                        expression = x => x.Memo == (string)value;
                        break;
					case "LOCKED" :
						model = list.SingleOrDefault(x => x.LOCKED == (byte)value);
                        expression = x => x.LOCKED == (byte)value;
                        break;
					case "CRT_DATETIME" :
						model = list.SingleOrDefault(x => x.CRT_DATETIME == (DateTime)value);
                        expression = x => x.CRT_DATETIME == (DateTime)value;
                        break;
					case "CRT_USER_ID" :
						model = list.SingleOrDefault(x => x.CRT_USER_ID == (string)value);
                        expression = x => x.CRT_USER_ID == (string)value;
                        break;
					case "MOD_DATETIME" :
						model = list.SingleOrDefault(x => x.MOD_DATETIME == (DateTime)value);
                        expression = x => x.MOD_DATETIME == (DateTime)value;
                        break;
					case "MOD_USER_ID" :
						model = list.SingleOrDefault(x => x.MOD_USER_ID == (string)value);
                        expression = x => x.MOD_USER_ID == (string)value;
                        break;
					case "LAST_UPDATE" :
						model = list.SingleOrDefault(x => x.LAST_UPDATE == (DateTime)value);
                        expression = x => x.LAST_UPDATE == (DateTime)value;
                        break;
					case "Trans_STATUS" :
						model = list.SingleOrDefault(x => x.Trans_STATUS == (byte)value);
                        expression = x => x.Trans_STATUS == (byte)value;
                        break;
					case "SHOP_NAME1" :
						model = list.SingleOrDefault(x => x.SHOP_NAME1 == (string)value);
                        expression = x => x.SHOP_NAME1 == (string)value;
                        break;

                    default :
                        return null;
                }

                if (model == null)
                {
                    //从数据库中读取
                    var tem = V_Purchase00_SHOP00.SingleOrDefault(expression);
                    if (tem == null)
                    {
                        return null;
                    }
                    else
                    {
                        //对查询出来的实体进行转换
                        model = Transform(tem);

                        return model;
                    }
                }
                else
                {
                    return model;
                }
            }
            catch (Exception e)
            {
                //记录日志
                CommonBll.WriteLog("从IIS缓存中获取V_Purchase00_SHOP00表记录时出现异常", e);

                return null;
            }
        }
        #endregion

		#region 从IIS缓存中获取指定条件的记录
        /// <summary>
        /// 从IIS缓存中获取指定条件的记录
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns>DataAccess.Model.V_Purchase00_SHOP00</returns>
        public DataAccess.Model.V_Purchase00_SHOP00 GetModelForCache(Expression<Func<DataAccess.Model.V_Purchase00_SHOP00, bool>> expression)
        {
			//从缓存中读取记录列表
			var list = GetList();
            //如果条件为空，则查询全表所有记录
            if (expression == null)
            {
                //查找并返回记录实体
                return list == null ? null : list.First();
            }
            else
            {
                //查找并返回记录实体
                return list == null ? null : list.AsQueryable().First(expression);
            }
        }
        #endregion

		#region 更新IIS缓存中指定Id记录
		/// <summary>
        /// 更新IIS缓存中指定Id记录
        /// </summary>
        /// <param name="model">记录实体</param>
        public void SetModelForCache(DataAccess.Model.V_Purchase00_SHOP00 model)
        {
            //从缓存中读取记录列表
            var list = GetList();
            //从缓存中删除记录
            DelCache(model.Id);
            //添加记录
            list.Add(model);
        }

        /// <summary>
        /// 更新IIS缓存中指定Id记录
        /// </summary>
        /// <param name="model">记录实体</param>
        public void SetModelForCache(V_Purchase00_SHOP00 model)
        {
            SetModelForCache(Transform(model));
        }
		#endregion

		#region 删除IIS缓存中指定Id记录
        /// <summary>
        /// 删除IIS缓存中指定Id记录
        /// </summary>
        /// <param name="id">主键Id</param>
        public bool DelCache(long id)
        {
            //从缓存中获取List
            var list = GetList(true);
            if (list == null)
            {
                return false;
            }
            else
            {
                //找到指定主键Id的实体
                var model = list.SingleOrDefault(x => x.Id == id);
                //删除指定Id的记录
                return model != null && list.Remove(model);
            }
        }

		/// <summary>
        /// 批量删除IIS缓存中指定Id记录
        /// </summary>
        /// <param name="ids">主键Id</param>
        public void DelCache(IEnumerable ids)
        {
            //循环删除指定Id队列
		    foreach (var id in ids)
		    {
		        DelCache((int)id);
		    }
        }

		/// <summary>
        /// 按条件删除IIS缓存中V_Purchase00_SHOP00表的指定记录
        /// </summary>
        /// <param name="expression">条件，值为null时删除全有记录</param>
		public void DelCache(Expression<Func<DataAccess.Model.V_Purchase00_SHOP00, bool>> expression)
        {
            //从缓存中获取List
		    var list = GetList();
            //如果缓存为null，则不做任何处理
            if (list == null || list.Count == 0)
            {
                return;
            }

            //如果条件为空，则删除全部记录
            if (expression == null)
            {
                //删除所有记录
                DelAllCache();
            }
            else
            {
                var tem = list.AsQueryable().Where(expression);
                foreach (var model in tem)
                {
                    list.Remove(model);
                }
            }
        }
		#endregion

		#region 实体转换
		/// <summary>
		/// 将V_Purchase00_SHOP00记录实体（SubSonic实体）转换为普通的实体（DataAccess.Model.V_Purchase00_SHOP00）
		/// </summary>
        /// <param name="model">SubSonic插件生成的实体</param>
		/// <returns>DataAccess.Model.V_Purchase00_SHOP00</returns>
		public DataAccess.Model.V_Purchase00_SHOP00 Transform(V_Purchase00_SHOP00 model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.V_Purchase00_SHOP00
            {
                Id = model.Id,
                SHOP_ID = model.SHOP_ID,
                Purchase_ID = model.Purchase_ID,
                STATUS = model.STATUS,
                PAY_STATUS = model.PAY_STATUS,
                INPUT_DATE = model.INPUT_DATE,
                SUP_ID = model.SUP_ID,
                EXPECT_DATE = model.EXPECT_DATE,
                USER_ID = model.USER_ID,
                APP_USER = model.APP_USER,
                APP_DATETIME = model.APP_DATETIME,
                TOT_AMOUNT = model.TOT_AMOUNT,
                TOT_TAX = model.TOT_TAX,
                TOT_QTY = model.TOT_QTY,
                PRE_PAY = model.PRE_PAY,
                PRE_PAY_ID = model.PRE_PAY_ID,
                EXPORTED = model.EXPORTED,
                EXPORTED_ID = model.EXPORTED_ID,
                Memo = model.Memo,
                LOCKED = model.LOCKED,
                CRT_DATETIME = model.CRT_DATETIME,
                CRT_USER_ID = model.CRT_USER_ID,
                MOD_DATETIME = model.MOD_DATETIME,
                MOD_USER_ID = model.MOD_USER_ID,
                LAST_UPDATE = model.LAST_UPDATE,
                Trans_STATUS = model.Trans_STATUS,
                SHOP_NAME1 = model.SHOP_NAME1,
            };
        }

		/// <summary>
		/// 将V_Purchase00_SHOP00记录实体集（SubSonic实体）转换为普通的实体集（DataAccess.Model.V_Purchase00_SHOP00）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的实体集</param>
        public IList<DataAccess.Model.V_Purchase00_SHOP00> Transform(IList<V_Purchase00_SHOP00> sourceList)
        {
			//创建List容器
            var list = new List<DataAccess.Model.V_Purchase00_SHOP00>();
			//将SubSonic插件生成的实体集转换后存储到刚创建的List容器中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 将V_Purchase00_SHOP00记录实体由普通的实体（DataAccess.Model.V_Purchase00_SHOP00）转换为SubSonic插件生成的实体
		/// </summary>
        /// <param name="model">普通的实体（DataAccess.Model.V_Purchase00_SHOP00）</param>
		/// <returns>V_Purchase00_SHOP00</returns>
		public V_Purchase00_SHOP00 Transform(DataAccess.Model.V_Purchase00_SHOP00 model)
        {
			if (model == null) 
				return null;

            return new V_Purchase00_SHOP00
            {
                Id = model.Id,
                SHOP_ID = model.SHOP_ID,
                Purchase_ID = model.Purchase_ID,
                STATUS = model.STATUS,
                PAY_STATUS = model.PAY_STATUS,
                INPUT_DATE = model.INPUT_DATE,
                SUP_ID = model.SUP_ID,
                EXPECT_DATE = model.EXPECT_DATE,
                USER_ID = model.USER_ID,
                APP_USER = model.APP_USER,
                APP_DATETIME = model.APP_DATETIME,
                TOT_AMOUNT = model.TOT_AMOUNT,
                TOT_TAX = model.TOT_TAX,
                TOT_QTY = model.TOT_QTY,
                PRE_PAY = model.PRE_PAY,
                PRE_PAY_ID = model.PRE_PAY_ID,
                EXPORTED = model.EXPORTED,
                EXPORTED_ID = model.EXPORTED_ID,
                Memo = model.Memo,
                LOCKED = model.LOCKED,
                CRT_DATETIME = model.CRT_DATETIME,
                CRT_USER_ID = model.CRT_USER_ID,
                MOD_DATETIME = model.MOD_DATETIME,
                MOD_USER_ID = model.MOD_USER_ID,
                LAST_UPDATE = model.LAST_UPDATE,
                Trans_STATUS = model.Trans_STATUS,
                SHOP_NAME1 = model.SHOP_NAME1,
            };
        }

		/// <summary>
		/// 将V_Purchase00_SHOP00记录实体由普通实体集（DataAccess.Model.V_Purchase00_SHOP00）转换为SubSonic插件生成的实体集
		/// </summary>
        /// <param name="sourceList">普通实体集（DataAccess.Model.V_Purchase00_SHOP00）</param>
        public IList<V_Purchase00_SHOP00> Transform(IList<DataAccess.Model.V_Purchase00_SHOP00> sourceList)
        {
			//创建List容器
            var list = new List<V_Purchase00_SHOP00>();
			//将普通实体集转换后存储到刚创建的List容器中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }
		#endregion

		#region 给实体赋值
		/// <summary>
        /// 给实体赋值
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="dic">列名与值</param>
		public void SetModelValue(DataAccess.Model.V_Purchase00_SHOP00 model, Dictionary<string, object> dic)
		{
			if (model == null || dic == null) return;

            //遍历字典，逐个给字段赋值
            foreach (var d in dic)
            {
                SetModelValue(model, d.Key, d.Value);
            }
		}

        /// <summary>
        /// 给实体赋值
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="colName">列名</param>
        /// <param name="value">值</param>
		public void SetModelValue(DataAccess.Model.V_Purchase00_SHOP00 model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定条件的实体
            switch (colName)
            {
				case "Id" :
					model.Id = (int)value;
                    break;
				case "SHOP_ID" :
					model.SHOP_ID = (string)value;
                    break;
				case "Purchase_ID" :
					model.Purchase_ID = (string)value;
                    break;
				case "STATUS" :
					model.STATUS = (int)value;
                    break;
				case "PAY_STATUS" :
					model.PAY_STATUS = (int)value;
                    break;
				case "INPUT_DATE" :
					model.INPUT_DATE = (DateTime)value;
                    break;
				case "SUP_ID" :
					model.SUP_ID = (string)value;
                    break;
				case "EXPECT_DATE" :
					model.EXPECT_DATE = (DateTime)value;
                    break;
				case "USER_ID" :
					model.USER_ID = (string)value;
                    break;
				case "APP_USER" :
					model.APP_USER = (string)value;
                    break;
				case "APP_DATETIME" :
					model.APP_DATETIME = (DateTime)value;
                    break;
				case "TOT_AMOUNT" :
					model.TOT_AMOUNT = (decimal)value;
                    break;
				case "TOT_TAX" :
					model.TOT_TAX = (decimal)value;
                    break;
				case "TOT_QTY" :
					model.TOT_QTY = (decimal)value;
                    break;
				case "PRE_PAY" :
					model.PRE_PAY = (decimal)value;
                    break;
				case "PRE_PAY_ID" :
					model.PRE_PAY_ID = (string)value;
                    break;
				case "EXPORTED" :
					model.EXPORTED = ConvertHelper.Ctinyint(value);
                    break;
				case "EXPORTED_ID" :
					model.EXPORTED_ID = (string)value;
                    break;
				case "Memo" :
					model.Memo = (string)value;
                    break;
				case "LOCKED" :
					model.LOCKED = ConvertHelper.Ctinyint(value);
                    break;
				case "CRT_DATETIME" :
					model.CRT_DATETIME = (DateTime)value;
                    break;
				case "CRT_USER_ID" :
					model.CRT_USER_ID = (string)value;
                    break;
				case "MOD_DATETIME" :
					model.MOD_DATETIME = (DateTime)value;
                    break;
				case "MOD_USER_ID" :
					model.MOD_USER_ID = (string)value;
                    break;
				case "LAST_UPDATE" :
					model.LAST_UPDATE = (DateTime)value;
                    break;
				case "Trans_STATUS" :
					model.Trans_STATUS = ConvertHelper.Ctinyint(value);
                    break;
				case "SHOP_NAME1" :
					model.SHOP_NAME1 = (string)value;
                    break;
            }
		}

        #endregion

		#endregion

		#region 获取V_Purchase00_SHOP00表记录总数
        /// <summary>
        /// 获取V_Purchase00_SHOP00表记录总数
        /// </summary>
        /// <returns>记录总数</returns>
        public int GetRecordCount()
        {
            //判断是否启用缓存
            if (CommonBll.IsUseCache())
            {
				//从缓存中获取记录集
                var list = GetList();
                return list == null ? 0 : list.Count;
            }
			else
			{
				//从数据库中查询记录集数量
				var select = new SelectHelper();
				return select.GetRecordCount<Branch>();
			}
        }

		/// <summary>
		/// 获取V_Purchase00_SHOP00表记录总数——从数据库中查询
		/// </summary>
        /// <param name="wheres">条件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionFun.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<V_Purchase00_SHOP00>(wheres);

		}

		/// <summary>
		/// 获取V_Purchase00_SHOP00表指定条件的记录总数——从数据库中查询
		/// </summary>
        /// <param name="expression">条件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<V_Purchase00_SHOP00, bool>> expression) {
            return new Select().From<V_Purchase00_SHOP00>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定条件的记录集合
        /// <summary>
        /// 查找指定条件的记录集合——从IIS缓存中查找
        /// </summary>
        /// <param name="expression">条件语句</param>
        public IList<DataAccess.Model.V_Purchase00_SHOP00> Find(Expression<Func<DataAccess.Model.V_Purchase00_SHOP00, bool>> expression)
        {
			//从缓存中获取记录集
			var list = GetList();
            //判断获取记录集是否为null
            if (list == null)
            {
                return null;
            }
            else
            {
                //在返回的记录集中查询
                var result = list.AsQueryable().Where(expression);
                //不存在指定记录集
                if (!result.Any())
                    return null;
                else
                    return result.ToList();
            }
        }
		#endregion

		#region 判断指定条件的记录是否存在
        /// <summary>
        /// 判断指定主键Id的记录是否存在——在IIS缓存或数据库中查找
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public bool Exist(int id)
        {
            if (id <= 0)
                return false;

            //判断是否启用缓存
            if (CommonBll.IsUseCache())
            {
                return Exist(x => x.Id == id);
            }
            
            //从数据库中查找
            return V_Purchase00_SHOP00.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判断指定条件的记录是否存在——默认在IIS缓存中查找，如果没开启缓存时，则直接在数据库中查询出列表后，再从列表中查询
        /// </summary>
        /// <param name="expression">条件语句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.V_Purchase00_SHOP00, bool>> expression)
        {
            var list = GetList();
            if (list == null) 
                return false;
            else
            {
                return list.AsQueryable().Any(expression);
            }
        }
        #endregion

		#region 获取V_Purchase00_SHOP00表记录
		/// <summary>
		/// 获取V_Purchase00_SHOP00表记录
		/// </summary>
		/// <param name="norepeat">是否使用去重复</param>
		/// <param name="top">获取指定数量记录</param>
		/// <param name="columns">获取指定的列记录</param>
		/// <param name="pageIndex">当前分页页面索引</param>
		/// <param name="pageSize">每个页面记录数量</param>
		/// <param name="wheres">查询条件</param>
		/// <param name="sorts">排序方式</param>
        /// <returns>返回DataTable</returns>
		public DataTable GetDataTable(bool norepeat = false, int top = 0, List<string> columns = null, int pageIndex = 0, int pageSize = 0, List<ConditionFun.SqlqueryCondition> wheres = null, List<string> sorts = null) {
			try
            {
                //分页查询
                var select = new SelectHelper();
                return select.SelectDataTable<V_Purchase00_SHOP00>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //记录日志
                CommonBll.WriteLog("获取V_Purchase00_SHOP00表记录时出现异常", e);

                return null;
            }
		}
		#endregion

		#region 绑定Grid表格
		/// <summary>
		/// 绑定Grid表格，并实现分页
		/// </summary>
		/// <param name="grid">表格控件</param>
		/// <param name="pageIndex">第几页</param>
		/// <param name="pageSize">每页显示记录数量</param>
		/// <param name="wheres">查询条件</param>
		/// <param name="sorts">排序</param>
		public override void BindGrid(FineUI.Grid grid, int pageIndex = 0, int pageSize = 0, List<ConditionFun.SqlqueryCondition> wheres = null, List<string> sorts = null) {
			//用于统计执行时长(耗时)
			var swatch = new Stopwatch();
			swatch.Start();

			try {
				// 1.设置总项数
				grid.RecordCount = GetRecordCount(wheres);
				// 如果不存在记录，则清空Grid表格
				if (grid.RecordCount == 0) {
					grid.Rows.Clear();
					return;
				}

				// 2.查询并绑定到Grid
				grid.DataSource = GetDataTable(false, 0, null, pageIndex, pageSize, wheres, sorts);
				grid.DataBind();

			}
			catch (Exception e) {
				// 记录日志
				CommonBll.WriteLog("获取用户操作日志表记录时出现异常", e);

			}

			// 统计结束
			swatch.Stop();
			// 计算查询数据库使用时间，并存储到Session里，以便UI显示
			HttpContext.Current.Session["SpendingTime"] = (swatch.ElapsedMilliseconds / 1000.00).ToString();
		}
		#endregion

		#region 绑定Grid表格
		/// <summary>
		/// 绑定Grid表格，使用内存分页，显示有层次感
		/// </summary>
		/// <param name="grid">表格控件</param>
		/// <param name="parentValue">父Id值</param>
		/// <param name="wheres">查询条件</param>
		/// <param name="sorts">排序</param>
		/// <param name="parentId">父Id</param>
		public override void BindGrid(FineUI.Grid grid, int parentValue, List<ConditionFun.SqlqueryCondition> wheres = null, List<string> sorts = null, string parentId = "ParentId") {
			//用于统计执行时长(耗时)
			var swatch = new Stopwatch();
			swatch.Start();

			try
			{
				// 查询数据库
				var dt = GetDataTable(false, 0, null, 0, 0, wheres, sorts);

				// 对查询出来的记录进行层次处理
				grid.DataSource = DataTableHelper.DataTableTidyUp(dt, "Id", parentId, parentValue);
				// 查询并绑定到Grid
				grid.DataBind();

			}
			catch (Exception e) {
				// 记录日志
				CommonBll.WriteLog("绑定表格时出现异常", e);

			}

			//统计结束
			swatch.Stop();
			//计算查询数据库使用时间，并存储到Session里，以便UI显示
			HttpContext.Current.Session["SpendingTime"] = (swatch.ElapsedMilliseconds / 1000.00).ToString();
		}

		/// <summary>
		/// 绑定Grid表格，使用内存分页，显示有层次感
		/// </summary>
		/// <param name="grid">表格控件</param>
		/// <param name="parentValue">父Id值</param>
		/// <param name="sorts">排序</param>
		/// <param name="parentId">父Id</param>
		public override void BindGrid(FineUI.Grid grid, int parentValue, List<string> sorts = null, string parentId = "ParentId") {
			BindGrid(grid, parentValue, null, sorts, parentId);
		}
		#endregion

		#region 添加与编辑V_Purchase00_SHOP00表记录
		/// <summary>
		/// 添加与编辑V_Purchase00_SHOP00记录
		/// </summary>
	    /// <param name="page">当前页面指针</param>
		/// <param name="model">V_Purchase00_SHOP00表实体</param>
        /// <param name="content">更新说明</param>
        /// <param name="isCache">是否更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
        public void Save(Page page, V_Purchase00_SHOP00 model, string content = null, bool isCache = true, bool isAddUseLog = true)
        {
			try {
				//保存
				model.Save();
				
				//判断是否启用缓存
			    if (CommonBll.IsUseCache() && isCache)
			    {
                    SetModelForCache(model);
			    }
				
				if (isAddUseLog)
				{
					if (string.IsNullOrEmpty(content))
					{
						content = "{0}" + (model.Id == 0 ? "添加" : "编辑") + "V_Purchase00_SHOP00记录成功，ID为【" + model.Id + "】";
					}

					//添加用户访问记录
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "执行V_Purchase00_SHOP00Bll.Save()函数出错！";

				//出现异常，保存出错日志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 删除V_Purchase00_SHOP00表记录
		/// <summary>
		/// 删除V_Purchase00_SHOP00表记录
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="id">记录的主键值</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//设置Sql语句
			var sql = string.Format("delete from {0} where {1} = {2}", V_Purchase00_SHOP00Table.TableName,  V_Purchase00_SHOP00Table.Id, id);

			//删除
			var delete = new DeleteHelper();
		    delete.Delete(sql);
			
			//判断是否启用缓存
            if (CommonBll.IsUseCache())
            {
                //删除缓存
                DelCache(id);
            }
			
			if (isAddUseLog)
		    {
				//添加用户操作记录
				UseLogBll.GetInstence().Save(page, "{0}删除了V_Purchase00_SHOP00表id为【" + id + "】的记录！");
			}
		}

		/// <summary>
		/// 删除V_Purchase00_SHOP00表记录
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="id">记录的主键值</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public override void Delete(Page page, int[] id, bool isAddUseLog = true) 
		{
			if (id == null) return;
			//将数组转为逗号分隔的字串
			var str = string.Join(",", id);

			//设置Sql语句
			var sql = string.Format("delete from {0} where {1} in ({2})", V_Purchase00_SHOP00Table.TableName,  V_Purchase00_SHOP00Table.Id, str);

			//删除
			var delete = new DeleteHelper();
		    delete.Delete(sql);
			
			//判断是否启用缓存
            if (CommonBll.IsUseCache())
            {
                //删除缓存
                DelCache(id.ToList());
            }
			
			if (isAddUseLog)
		    {
				//添加用户操作记录
				UseLogBll.GetInstence().Save(page, "{0}删除了V_Purchase00_SHOP00表id为【" + str + "】的记录！");
			}
		}

		/// <summary>
        /// 获取数据表中的某个值——从数据库中查询，如果使用了缓存，删除成功后会清空本表的所有缓存记录，然后重新加载进缓存
        /// </summary>
        /// <param name="page">当前页面指针</param>
        /// <param name="expression">条件语句</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
        public void Delete(Page page, Expression<Func<V_Purchase00_SHOP00, bool>> expression, bool isAddUseLog = true)
        {
			//执行删除
			V_Purchase00_SHOP00.Delete(expression);

            //判断是否启用缓存
            if (CommonBll.IsUseCache())
            {
				//清空当前表所有缓存记录
				DelAllCache();
                //重新载入缓存
                GetList();
            }
			
			if (isAddUseLog)
		    {
				//添加用户操作记录
				UseLogBll.GetInstence().Save(page, "{0}删除了V_Purchase00_SHOP00表记录！");
			}
        }
		#endregion
		
		#region 保存列表排序
		/// <summary>
		/// 保存列表排序，如果使用了缓存，保存成功后会清空本表的所有缓存记录，然后重新加载进缓存
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="grid1">页面表格</param>
		/// <param name="tbxSort">表格中绑定排序的表单名</param>
		/// <param name="sortName">排序字段名</param>
		/// <returns>更新成功返回true，失败返回false</returns>
		public override bool UpdateSort(Page page, FineUI.Grid grid1, string tbxSort, string sortName = "Sort")
	    {
		     //更新排序
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "V_Purchase00_SHOP00", sortName, "Id"))
		    {
				//判断是否启用缓存
                if (CommonBll.IsUseCache())
                {
                    //删除所有缓存
                    DelAllCache();
                    //重新载入缓存
                    GetList();
                }
				
			    //添加用户操作记录
				UseLogBll.GetInstence().Save(page, "{0}更新了V_Purchase00_SHOP00表排序！");

			    return true;
		    }

			return false;
	    }
		#endregion

		#region 自动排序
		/// <summary>自动排序，如果使用了缓存，保存成功后会清空本表的所有缓存记录，然后重新加载进缓存</summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="strWhere">附加Where : " sid=1 "</param>
		/// <param name="isExistsMoreLv">是否存在多级分类,一级时,请使用false,多级使用true，(一级不包括ParentID字段)</param>
		/// <param name="pid">父级分类的ParentID</param>
		/// <param name="fieldName">字段名:"SortId"</param>
		/// <param name="fieldParentId">字段名:"ParentId"</param>
		/// <returns>更新成功返回true，失败返回false</returns>
		public override bool UpdateAutoSort(Page page, string strWhere = "", bool isExistsMoreLv = false, int pid = 0, string fieldName = "Sort", string fieldParentId = "ParentId")
	    {
		    //更新排序
			if (CommonBll.AutoSort("Id", "V_Purchase00_SHOP00", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
		    {
				//判断是否启用缓存
                if (CommonBll.IsUseCache())
                {
                    //删除所有缓存
                    DelAllCache();
                    //重新载入缓存
                    GetList();
                }

			    //添加用户操作记录
				UseLogBll.GetInstence().Save(page, "{0}对V_Purchase00_SHOP00表进行了自动排序操作！");

			    return true;
		    }

			return false;
	    }
		#endregion
		
		#region 获取数据表中的某个值
		/// <summary>
        /// 获取数据表中的某个值——主要用于内存查询，数据量大的表请将isCache设为false
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="colName">获取的列名</param>
        /// <param name="isCache">是否从缓存中读取</param>
        /// <returns>指定列的值</returns>
        public object GetFieldValue(int id, string colName, bool isCache = true)
	    {
			return GetFieldValue(colName, null, id, isCache);            
	    }

	    /// <summary>
        /// 获取数据表中的某个值——主要用于内存查询，数据量大的表请将isCache设为false
	    /// </summary>
	    /// <param name="colName">获取的列名</param>
	    /// <param name="conditionColName">条件列名，为null时默认为主键Id</param>
	    /// <param name="value">条件值</param>
	    /// <param name="isCache">是否从缓存中读取</param>
	    /// <returns></returns>
	    public object GetFieldValue(string colName, string conditionColName, object value, bool isCache = true)
	    {
            //如果条件列为空，则默认为主键列
            if (string.IsNullOrEmpty(conditionColName))
                conditionColName = V_Purchase00_SHOP00Table.Id;

            //在内存中查询
	        if (isCache)
	        {
                //判断是否启用缓存
                if (CommonBll.IsUseCache())
                {
                    //如果条件列为空，则默认为主键列
                    if (string.IsNullOrEmpty(conditionColName))
                    {
                        //获取实体
                        var model = GetModelForCache(ConvertHelper.Cint0(value));
                        //返回指定字段名的值
                        return GetFieldValue(model, conditionColName);
                    }
                    else
                    {
                        //获取实体
                        var model = GetModelForCache(conditionColName, ConvertHelper.Cint0(value));
                        //返回指定字段名的值
                        return GetFieldValue(model, colName);
                    }
                }

				//递归调用，从数据库中查询
	            return GetFieldValue(colName, conditionColName, value, false);
	        }
            //从数据库中查询
	        else
	        {
                //设置条件
                var wheres = new List<ConditionFun.SqlqueryCondition>();
                wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, conditionColName, Comparison.Equals, value));

                return GetFieldValue(colName, wheres);
	        }
	    }
		
	    /// <summary>
        /// 获取数据表中的某个值——使用IIS缓存查询
        /// </summary>
        /// <param name="colName">获取的列名</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.V_Purchase00_SHOP00, bool>> expression)
	    {
	        return GetFieldValue(GetModelForCache(expression), colName);
	    }

	    /// <summary>
        /// 获取数据表中的某个值——从数据库中查询
        /// </summary>
        /// <param name="colName">获取的列名</param>
        /// <param name="wheres">条件，例：Id=100 and xx=20</param>
        /// <returns></returns>
        public object GetFieldValue(string colName, string wheres)
        {
            try
            {
                return DataTableHelper.DataTable_Find_Value(GetDataTable(), wheres, colName);
			}
			catch (Exception e)
			{
                //记录日志
                CommonBll.WriteLog("查询数据出现异常", e);
			}

            return null;
        }

        /// <summary>
        /// 获取数据表中的某个值——从数据库中查询
        /// </summary>
        /// <param name="colName">获取的列名</param>
        /// <param name="wheres">条件</param>
        /// <returns></returns>
        public object GetFieldValue(string colName, List<ConditionFun.SqlqueryCondition> wheres)
        {
            var select = new SelectHelper();
            return select.GetColumnsValue<V_Purchase00_SHOP00>(colName, wheres);
        }

		/// <summary>
        /// 返回实体中指定字段名的值
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="colName">获取的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.V_Purchase00_SHOP00 model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "SHOP_ID" :
					return model.SHOP_ID;
				case "Purchase_ID" :
					return model.Purchase_ID;
				case "STATUS" :
					return model.STATUS;
				case "PAY_STATUS" :
					return model.PAY_STATUS;
				case "INPUT_DATE" :
					return model.INPUT_DATE;
				case "SUP_ID" :
					return model.SUP_ID;
				case "EXPECT_DATE" :
					return model.EXPECT_DATE;
				case "USER_ID" :
					return model.USER_ID;
				case "APP_USER" :
					return model.APP_USER;
				case "APP_DATETIME" :
					return model.APP_DATETIME;
				case "TOT_AMOUNT" :
					return model.TOT_AMOUNT;
				case "TOT_TAX" :
					return model.TOT_TAX;
				case "TOT_QTY" :
					return model.TOT_QTY;
				case "PRE_PAY" :
					return model.PRE_PAY;
				case "PRE_PAY_ID" :
					return model.PRE_PAY_ID;
				case "EXPORTED" :
					return model.EXPORTED;
				case "EXPORTED_ID" :
					return model.EXPORTED_ID;
				case "Memo" :
					return model.Memo;
				case "LOCKED" :
					return model.LOCKED;
				case "CRT_DATETIME" :
					return model.CRT_DATETIME;
				case "CRT_USER_ID" :
					return model.CRT_USER_ID;
				case "MOD_DATETIME" :
					return model.MOD_DATETIME;
				case "MOD_USER_ID" :
					return model.MOD_USER_ID;
				case "LAST_UPDATE" :
					return model.LAST_UPDATE;
				case "Trans_STATUS" :
					return model.Trans_STATUS;
				case "SHOP_NAME1" :
					return model.SHOP_NAME1;
			}

			return null;
		}

		#endregion
		
		#region 更新V_Purchase00_SHOP00表指定字段值
		/// <summary>更新V_Purchase00_SHOP00表记录指定字段值，如果使用了缓存，保存成功后会清空本表的所有缓存记录，然后重新加载进缓存</summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="dic">需要更新的字段与值</param>
		/// <param name="wheres">条件</param>
		/// <param name="content">更新说明</param>
		/// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionFun.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<V_Purchase00_SHOP00>(dic, wheres);

			//判断是否启用缓存
			if (isCache && CommonBll.IsUseCache())
			{
				//删除全部缓存	
				DelAllCache();
				//重新载入缓存
				GetList();
			}
			
			if (isAddUseLog){
				if (string.IsNullOrEmpty(content))
				{
					//添加用户操作记录
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}修改了V_Purchase00_SHOP00表记录。");				
				}
				else
				{
					//添加用户操作记录
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新V_Purchase00_SHOP00表指定主键Id的字段值
		/// <summary>更新V_Purchase00_SHOP00表记录指定字段值</summary>
        /// <param name="page">当前页面指针</param>
        /// <param name="id">主键Id，当小于等于0时，则更新所有记录</param>
	    /// <param name="dic">需要更新的字段与值</param>
	    /// <param name="content">更新说明</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
	    public void UpdateValue(Page page, int id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}修改了V_Purchase00_SHOP00表主键Id值为" + id + "的记录。";
			
            //条件
		    List<ConditionFun.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionFun.SqlqueryCondition>();
                wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_Purchase00_SHOP00Table.Id, Comparison.Equals, id));
            };

			//判断是否启用缓存——为了防止并发问题，所以先更新缓存再更新数据库
			if (isCache && CommonBll.IsUseCache())
			{
				//从缓存中获取实体
				var model = GetModelForCache(id);
				//给获取的实体赋值
				SetModelValue(model, dic);
				//更新缓存中的实体
				SetModelForCache(model);
			}

            //执行更新
            UpdateValue(page, dic, wheres, content, false, isAddUseLog);
        }

        /// <summary>更新V_Purchase00_SHOP00表记录指定字段值（更新一个字段值）</summary>
        /// <param name="page">当前页面指针</param>
        /// <param name="id">主键Id，当小于等于0时，则更新所有记录</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新说明</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
        public void UpdateValue(Page page, int id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}修改了V_Purchase00_SHOP00表主键Id值为" + id + "的记录，将" + columnName + "字段值修改为" + columnValue;
            //设置更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//执行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新V_Purchase00_SHOP00表记录指定字段值（更新两个字段值）</summary>
        /// <param name="page">当前页面指针</param>
        /// <param name="id">主键Id，当小于等于0时，则更新所有记录</param>
        /// <param name="columnName1">要更新的列名</param>
        /// <param name="columnValue1">要更新的列值</param>
        /// <param name="columnName2">要更新的列名</param>
        /// <param name="columnValue2">要更新的列值</param>
        /// <param name="content">更新说明</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
        public void UpdateValue(Page page, int id, string columnName1, object columnValue1, string columnName2, object columnValue2, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}修改了V_Purchase00_SHOP00表主键Id值为" + id + "的记录，将" + columnName1 + "字段值修改为" + columnValue1 + "，" + columnName2 + "字段值修改为" + columnValue2;
            //设置更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//执行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 更新EXPORTED字段值
		/// <summary>
		/// 更新EXPORTED字段值
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="pkValue">主键Id，当等于0时，则更新所有记录</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateEXPORTED(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//设置更新值
			var setValue = new Dictionary<string, object>();
			setValue[V_Purchase00_SHOP00Table.EXPORTED] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了V_Purchase00_SHOP00表id为【" + pkValue + "】的记录，更新内容为将EXPORTED字段值修改为" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新LOCKED字段值
		/// <summary>
		/// 更新LOCKED字段值
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="pkValue">主键Id，当等于0时，则更新所有记录</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateLOCKED(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//设置更新值
			var setValue = new Dictionary<string, object>();
			setValue[V_Purchase00_SHOP00Table.LOCKED] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了V_Purchase00_SHOP00表id为【" + pkValue + "】的记录，更新内容为将LOCKED字段值修改为" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新Trans_STATUS字段值
		/// <summary>
		/// 更新Trans_STATUS字段值
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="pkValue">主键Id，当等于0时，则更新所有记录</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateTrans_STATUS(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//设置更新值
			var setValue = new Dictionary<string, object>();
			setValue[V_Purchase00_SHOP00Table.Trans_STATUS] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了V_Purchase00_SHOP00表id为【" + pkValue + "】的记录，更新内容为将Trans_STATUS字段值修改为" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
    
		#endregion 模版生成函数

    } 
}
