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
	/// V_STOCK01_PRODUCT01表逻辑类
	/// </summary>
	public partial class V_STOCK01_PRODUCT01Bll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函数                                                        *
		 ***********************************************************************/
		#region 模版生成函数
				
		private const string const_CacheKey = "Cache_V_STOCK01_PRODUCT01";
        private const string const_CacheKey_Date = "Cache_V_STOCK01_PRODUCT01_Date";

		#region 单例模式
		//定义单例实体
		private static V_STOCK01_PRODUCT01Bll _V_STOCK01_PRODUCT01Bll = null;

		/// <summary>
		/// 获取本逻辑类单例
		/// </summary>
		/// <returns></returns>
		public static V_STOCK01_PRODUCT01Bll GetInstence() {
			if (_V_STOCK01_PRODUCT01Bll == null) {
				_V_STOCK01_PRODUCT01Bll = new V_STOCK01_PRODUCT01Bll();
			}
			return _V_STOCK01_PRODUCT01Bll;
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
		
		#region 从IIS缓存中获取V_STOCK01_PRODUCT01表记录
		/// <summary>
        /// 从IIS缓存中获取V_STOCK01_PRODUCT01表记录
        /// </summary>
	    /// <param name="isCache">是否从缓存中读取</param>
        public IList<DataAccess.Model.V_STOCK01_PRODUCT01> GetList(bool isCache = true)
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
						return (IList<DataAccess.Model.V_STOCK01_PRODUCT01>)obj;
					}
				}
				else
				{
					//定义临时实体集
					IList<DataAccess.Model.V_STOCK01_PRODUCT01> list = null;

					//获取全表缓存加载条件表达式
					var exp = GetExpression<V_STOCK01_PRODUCT01>();
                    //如果条件为空，则查询全表所有记录
					if (exp == null)
					{
						//从数据库中获取所有记录
						var all = V_STOCK01_PRODUCT01.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //从数据库中查询出指定条件的记录，并转换为指定实体集
						var all = V_STOCK01_PRODUCT01.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //记录日志
                CommonBll.WriteLog("从IIS缓存中获取V_STOCK01_PRODUCT01表记录时出现异常", e);
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
		/// <returns>DataAccess.Model.V_STOCK01_PRODUCT01</returns>
        public DataAccess.Model.V_STOCK01_PRODUCT01 GetModel(long id, bool isCache = true)
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
                var model = V_STOCK01_PRODUCT01.SingleOrDefault(x => x.Id == id);
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
		/// <returns>DataAccess.Model.V_STOCK01_PRODUCT01</returns>
        public DataAccess.Model.V_STOCK01_PRODUCT01 GetModelForCache(long id)
        {
			try
			{
				//从缓存中读取指定Id记录
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//从数据库中读取
					var tem = V_STOCK01_PRODUCT01.SingleOrDefault(x => x.Id == id);
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
                CommonBll.WriteLog("从IIS缓存中获取V_STOCK01_PRODUCT01表记录时出现异常", e);

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
        /// <returns>DataAccess.Model.V_STOCK01_PRODUCT01</returns>
        public DataAccess.Model.V_STOCK01_PRODUCT01 GetModelForCache(string conditionColName, object value)
        {
		try
            {
                //从缓存中获取List
                var list = GetList();
                DataAccess.Model.V_STOCK01_PRODUCT01 model = null;
                Expression<Func<V_STOCK01_PRODUCT01, bool>> expression = null;

                //返回指定条件的实体
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (int)value);
                        expression = x => x.Id == (int)value;
                        break;
					case "STOCK_ID" :
						model = list.SingleOrDefault(x => x.STOCK_ID == (string)value);
                        expression = x => x.STOCK_ID == (string)value;
                        break;
					case "SHOP_ID" :
						model = list.SingleOrDefault(x => x.SHOP_ID == (string)value);
                        expression = x => x.SHOP_ID == (string)value;
                        break;
					case "SHOP_NAME1" :
						model = list.SingleOrDefault(x => x.SHOP_NAME1 == (string)value);
                        expression = x => x.SHOP_NAME1 == (string)value;
                        break;
					case "PRCAREA_ID" :
						model = list.SingleOrDefault(x => x.PRCAREA_ID == (string)value);
                        expression = x => x.PRCAREA_ID == (string)value;
                        break;
					case "PROD_ID" :
						model = list.SingleOrDefault(x => x.PROD_ID == (string)value);
                        expression = x => x.PROD_ID == (string)value;
                        break;
					case "PROD_NAME1" :
						model = list.SingleOrDefault(x => x.PROD_NAME1 == (string)value);
                        expression = x => x.PROD_NAME1 == (string)value;
                        break;
					case "PROD_NAME1_SPELLING" :
						model = list.SingleOrDefault(x => x.PROD_NAME1_SPELLING == (string)value);
                        expression = x => x.PROD_NAME1_SPELLING == (string)value;
                        break;
					case "PROD_KIND" :
						model = list.SingleOrDefault(x => x.PROD_KIND == (string)value);
                        expression = x => x.PROD_KIND == (string)value;
                        break;
					case "PROD_DEP" :
						model = list.SingleOrDefault(x => x.PROD_DEP == (string)value);
                        expression = x => x.PROD_DEP == (string)value;
                        break;
					case "PROD_CATE" :
						model = list.SingleOrDefault(x => x.PROD_CATE == (string)value);
                        expression = x => x.PROD_CATE == (string)value;
                        break;
					case "PROD_UNIT" :
						model = list.SingleOrDefault(x => x.PROD_UNIT == (string)value);
                        expression = x => x.PROD_UNIT == (string)value;
                        break;
					case "UNIT_NAME" :
						model = list.SingleOrDefault(x => x.UNIT_NAME == (string)value);
                        expression = x => x.UNIT_NAME == (string)value;
                        break;
					case "PROD_UNIT1" :
						model = list.SingleOrDefault(x => x.PROD_UNIT1 == (string)value);
                        expression = x => x.PROD_UNIT1 == (string)value;
                        break;
					case "UNIT_NAME1" :
						model = list.SingleOrDefault(x => x.UNIT_NAME1 == (string)value);
                        expression = x => x.UNIT_NAME1 == (string)value;
                        break;
					case "PROD_CONVERT1" :
						model = list.SingleOrDefault(x => x.PROD_CONVERT1 == (int)value);
                        expression = x => x.PROD_CONVERT1 == (int)value;
                        break;
					case "PROD_UNIT2" :
						model = list.SingleOrDefault(x => x.PROD_UNIT2 == (string)value);
                        expression = x => x.PROD_UNIT2 == (string)value;
                        break;
					case "UNIT_NAME2" :
						model = list.SingleOrDefault(x => x.UNIT_NAME2 == (string)value);
                        expression = x => x.UNIT_NAME2 == (string)value;
                        break;
					case "PROD_CONVERT2" :
						model = list.SingleOrDefault(x => x.PROD_CONVERT2 == (int)value);
                        expression = x => x.PROD_CONVERT2 == (int)value;
                        break;
					case "SUP_ID" :
						model = list.SingleOrDefault(x => x.SUP_ID == (string)value);
                        expression = x => x.SUP_ID == (string)value;
                        break;
					case "SUP_NAME" :
						model = list.SingleOrDefault(x => x.SUP_NAME == (string)value);
                        expression = x => x.SUP_NAME == (string)value;
                        break;
					case "SEND_TYPE" :
						model = list.SingleOrDefault(x => x.SEND_TYPE == (byte)value);
                        expression = x => x.SEND_TYPE == (byte)value;
                        break;
					case "TAX_TYPE" :
						model = list.SingleOrDefault(x => x.TAX_TYPE == (byte)value);
                        expression = x => x.TAX_TYPE == (byte)value;
                        break;
					case "Tax" :
						model = list.SingleOrDefault(x => x.Tax == (int)value);
                        expression = x => x.Tax == (int)value;
                        break;
					case "SUP_COST" :
						model = list.SingleOrDefault(x => x.SUP_COST == (decimal)value);
                        expression = x => x.SUP_COST == (decimal)value;
                        break;
					case "SUP_COST1" :
						model = list.SingleOrDefault(x => x.SUP_COST1 == (decimal)value);
                        expression = x => x.SUP_COST1 == (decimal)value;
                        break;
					case "SUP_COST2" :
						model = list.SingleOrDefault(x => x.SUP_COST2 == (decimal)value);
                        expression = x => x.SUP_COST2 == (decimal)value;
                        break;
					case "S_Cost" :
						model = list.SingleOrDefault(x => x.S_Cost == (decimal)value);
                        expression = x => x.S_Cost == (decimal)value;
                        break;
					case "S_Cost1" :
						model = list.SingleOrDefault(x => x.S_Cost1 == (decimal)value);
                        expression = x => x.S_Cost1 == (decimal)value;
                        break;
					case "S_Cost2" :
						model = list.SingleOrDefault(x => x.S_Cost2 == (decimal)value);
                        expression = x => x.S_Cost2 == (decimal)value;
                        break;
					case "S_Ret_Cost" :
						model = list.SingleOrDefault(x => x.S_Ret_Cost == (decimal)value);
                        expression = x => x.S_Ret_Cost == (decimal)value;
                        break;
					case "S_Ret_Cost1" :
						model = list.SingleOrDefault(x => x.S_Ret_Cost1 == (decimal)value);
                        expression = x => x.S_Ret_Cost1 == (decimal)value;
                        break;
					case "S_Ret_Cost2" :
						model = list.SingleOrDefault(x => x.S_Ret_Cost2 == (decimal)value);
                        expression = x => x.S_Ret_Cost2 == (decimal)value;
                        break;
					case "COST" :
						model = list.SingleOrDefault(x => x.COST == (decimal)value);
                        expression = x => x.COST == (decimal)value;
                        break;
					case "COST1" :
						model = list.SingleOrDefault(x => x.COST1 == (decimal)value);
                        expression = x => x.COST1 == (decimal)value;
                        break;
					case "COST2" :
						model = list.SingleOrDefault(x => x.COST2 == (decimal)value);
                        expression = x => x.COST2 == (decimal)value;
                        break;
					case "ORDER_UNIT" :
						model = list.SingleOrDefault(x => x.ORDER_UNIT == (int)value);
                        expression = x => x.ORDER_UNIT == (int)value;
                        break;
					case "ORDER_NAME" :
						model = list.SingleOrDefault(x => x.ORDER_NAME == (string)value);
                        expression = x => x.ORDER_NAME == (string)value;
                        break;
					case "ORDER_QUAN" :
						model = list.SingleOrDefault(x => x.ORDER_QUAN == (int)value);
                        expression = x => x.ORDER_QUAN == (int)value;
                        break;
					case "Purchase_UNIT" :
						model = list.SingleOrDefault(x => x.Purchase_UNIT == (int)value);
                        expression = x => x.Purchase_UNIT == (int)value;
                        break;
					case "Purchase_UNIT_NAME" :
						model = list.SingleOrDefault(x => x.Purchase_UNIT_NAME == (string)value);
                        expression = x => x.Purchase_UNIT_NAME == (string)value;
                        break;
					case "Purchase_QUAN" :
						model = list.SingleOrDefault(x => x.Purchase_QUAN == (int)value);
                        expression = x => x.Purchase_QUAN == (int)value;
                        break;
					case "SAFE_QUAN" :
						model = list.SingleOrDefault(x => x.SAFE_QUAN == (int)value);
                        expression = x => x.SAFE_QUAN == (int)value;
                        break;
					case "PROD_PRICE" :
						model = list.SingleOrDefault(x => x.PROD_PRICE == (decimal)value);
                        expression = x => x.PROD_PRICE == (decimal)value;
                        break;
					case "ENABLE" :
						model = list.SingleOrDefault(x => x.ENABLE == (byte)value);
                        expression = x => x.ENABLE == (byte)value;
                        break;
					case "VISIBLE" :
						model = list.SingleOrDefault(x => x.VISIBLE == (byte)value);
                        expression = x => x.VISIBLE == (byte)value;
                        break;
					case "BOM_ID" :
						model = list.SingleOrDefault(x => x.BOM_ID == (string)value);
                        expression = x => x.BOM_ID == (string)value;
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

                    default :
                        return null;
                }

                if (model == null)
                {
                    //从数据库中读取
                    var tem = V_STOCK01_PRODUCT01.SingleOrDefault(expression);
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
                CommonBll.WriteLog("从IIS缓存中获取V_STOCK01_PRODUCT01表记录时出现异常", e);

                return null;
            }
        }
        #endregion

		#region 从IIS缓存中获取指定条件的记录
        /// <summary>
        /// 从IIS缓存中获取指定条件的记录
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns>DataAccess.Model.V_STOCK01_PRODUCT01</returns>
        public DataAccess.Model.V_STOCK01_PRODUCT01 GetModelForCache(Expression<Func<DataAccess.Model.V_STOCK01_PRODUCT01, bool>> expression)
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
        public void SetModelForCache(DataAccess.Model.V_STOCK01_PRODUCT01 model)
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
        public void SetModelForCache(V_STOCK01_PRODUCT01 model)
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
        /// 按条件删除IIS缓存中V_STOCK01_PRODUCT01表的指定记录
        /// </summary>
        /// <param name="expression">条件，值为null时删除全有记录</param>
		public void DelCache(Expression<Func<DataAccess.Model.V_STOCK01_PRODUCT01, bool>> expression)
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
		/// 将V_STOCK01_PRODUCT01记录实体（SubSonic实体）转换为普通的实体（DataAccess.Model.V_STOCK01_PRODUCT01）
		/// </summary>
        /// <param name="model">SubSonic插件生成的实体</param>
		/// <returns>DataAccess.Model.V_STOCK01_PRODUCT01</returns>
		public DataAccess.Model.V_STOCK01_PRODUCT01 Transform(V_STOCK01_PRODUCT01 model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.V_STOCK01_PRODUCT01
            {
                Id = model.Id,
                STOCK_ID = model.STOCK_ID,
                SHOP_ID = model.SHOP_ID,
                SHOP_NAME1 = model.SHOP_NAME1,
                PRCAREA_ID = model.PRCAREA_ID,
                PROD_ID = model.PROD_ID,
                PROD_NAME1 = model.PROD_NAME1,
                PROD_NAME1_SPELLING = model.PROD_NAME1_SPELLING,
                PROD_KIND = model.PROD_KIND,
                PROD_DEP = model.PROD_DEP,
                PROD_CATE = model.PROD_CATE,
                PROD_UNIT = model.PROD_UNIT,
                UNIT_NAME = model.UNIT_NAME,
                PROD_UNIT1 = model.PROD_UNIT1,
                UNIT_NAME1 = model.UNIT_NAME1,
                PROD_CONVERT1 = model.PROD_CONVERT1,
                PROD_UNIT2 = model.PROD_UNIT2,
                UNIT_NAME2 = model.UNIT_NAME2,
                PROD_CONVERT2 = model.PROD_CONVERT2,
                SUP_ID = model.SUP_ID,
                SUP_NAME = model.SUP_NAME,
                SEND_TYPE = model.SEND_TYPE,
                TAX_TYPE = model.TAX_TYPE,
                Tax = model.Tax,
                SUP_COST = model.SUP_COST,
                SUP_COST1 = model.SUP_COST1,
                SUP_COST2 = model.SUP_COST2,
                S_Cost = model.S_Cost,
                S_Cost1 = model.S_Cost1,
                S_Cost2 = model.S_Cost2,
                S_Ret_Cost = model.S_Ret_Cost,
                S_Ret_Cost1 = model.S_Ret_Cost1,
                S_Ret_Cost2 = model.S_Ret_Cost2,
                COST = model.COST,
                COST1 = model.COST1,
                COST2 = model.COST2,
                ORDER_UNIT = model.ORDER_UNIT,
                ORDER_NAME = model.ORDER_NAME,
                ORDER_QUAN = model.ORDER_QUAN,
                Purchase_UNIT = model.Purchase_UNIT,
                Purchase_UNIT_NAME = model.Purchase_UNIT_NAME,
                Purchase_QUAN = model.Purchase_QUAN,
                SAFE_QUAN = model.SAFE_QUAN,
                PROD_PRICE = model.PROD_PRICE,
                ENABLE = model.ENABLE,
                VISIBLE = model.VISIBLE,
                BOM_ID = model.BOM_ID,
                CRT_DATETIME = model.CRT_DATETIME,
                CRT_USER_ID = model.CRT_USER_ID,
                MOD_DATETIME = model.MOD_DATETIME,
                MOD_USER_ID = model.MOD_USER_ID,
                LAST_UPDATE = model.LAST_UPDATE,
            };
        }

		/// <summary>
		/// 将V_STOCK01_PRODUCT01记录实体集（SubSonic实体）转换为普通的实体集（DataAccess.Model.V_STOCK01_PRODUCT01）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的实体集</param>
        public IList<DataAccess.Model.V_STOCK01_PRODUCT01> Transform(IList<V_STOCK01_PRODUCT01> sourceList)
        {
			//创建List容器
            var list = new List<DataAccess.Model.V_STOCK01_PRODUCT01>();
			//将SubSonic插件生成的实体集转换后存储到刚创建的List容器中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 将V_STOCK01_PRODUCT01记录实体由普通的实体（DataAccess.Model.V_STOCK01_PRODUCT01）转换为SubSonic插件生成的实体
		/// </summary>
        /// <param name="model">普通的实体（DataAccess.Model.V_STOCK01_PRODUCT01）</param>
		/// <returns>V_STOCK01_PRODUCT01</returns>
		public V_STOCK01_PRODUCT01 Transform(DataAccess.Model.V_STOCK01_PRODUCT01 model)
        {
			if (model == null) 
				return null;

            return new V_STOCK01_PRODUCT01
            {
                Id = model.Id,
                STOCK_ID = model.STOCK_ID,
                SHOP_ID = model.SHOP_ID,
                SHOP_NAME1 = model.SHOP_NAME1,
                PRCAREA_ID = model.PRCAREA_ID,
                PROD_ID = model.PROD_ID,
                PROD_NAME1 = model.PROD_NAME1,
                PROD_NAME1_SPELLING = model.PROD_NAME1_SPELLING,
                PROD_KIND = model.PROD_KIND,
                PROD_DEP = model.PROD_DEP,
                PROD_CATE = model.PROD_CATE,
                PROD_UNIT = model.PROD_UNIT,
                UNIT_NAME = model.UNIT_NAME,
                PROD_UNIT1 = model.PROD_UNIT1,
                UNIT_NAME1 = model.UNIT_NAME1,
                PROD_CONVERT1 = model.PROD_CONVERT1,
                PROD_UNIT2 = model.PROD_UNIT2,
                UNIT_NAME2 = model.UNIT_NAME2,
                PROD_CONVERT2 = model.PROD_CONVERT2,
                SUP_ID = model.SUP_ID,
                SUP_NAME = model.SUP_NAME,
                SEND_TYPE = model.SEND_TYPE,
                TAX_TYPE = model.TAX_TYPE,
                Tax = model.Tax,
                SUP_COST = model.SUP_COST,
                SUP_COST1 = model.SUP_COST1,
                SUP_COST2 = model.SUP_COST2,
                S_Cost = model.S_Cost,
                S_Cost1 = model.S_Cost1,
                S_Cost2 = model.S_Cost2,
                S_Ret_Cost = model.S_Ret_Cost,
                S_Ret_Cost1 = model.S_Ret_Cost1,
                S_Ret_Cost2 = model.S_Ret_Cost2,
                COST = model.COST,
                COST1 = model.COST1,
                COST2 = model.COST2,
                ORDER_UNIT = model.ORDER_UNIT,
                ORDER_NAME = model.ORDER_NAME,
                ORDER_QUAN = model.ORDER_QUAN,
                Purchase_UNIT = model.Purchase_UNIT,
                Purchase_UNIT_NAME = model.Purchase_UNIT_NAME,
                Purchase_QUAN = model.Purchase_QUAN,
                SAFE_QUAN = model.SAFE_QUAN,
                PROD_PRICE = model.PROD_PRICE,
                ENABLE = model.ENABLE,
                VISIBLE = model.VISIBLE,
                BOM_ID = model.BOM_ID,
                CRT_DATETIME = model.CRT_DATETIME,
                CRT_USER_ID = model.CRT_USER_ID,
                MOD_DATETIME = model.MOD_DATETIME,
                MOD_USER_ID = model.MOD_USER_ID,
                LAST_UPDATE = model.LAST_UPDATE,
            };
        }

		/// <summary>
		/// 将V_STOCK01_PRODUCT01记录实体由普通实体集（DataAccess.Model.V_STOCK01_PRODUCT01）转换为SubSonic插件生成的实体集
		/// </summary>
        /// <param name="sourceList">普通实体集（DataAccess.Model.V_STOCK01_PRODUCT01）</param>
        public IList<V_STOCK01_PRODUCT01> Transform(IList<DataAccess.Model.V_STOCK01_PRODUCT01> sourceList)
        {
			//创建List容器
            var list = new List<V_STOCK01_PRODUCT01>();
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
		public void SetModelValue(DataAccess.Model.V_STOCK01_PRODUCT01 model, Dictionary<string, object> dic)
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
		public void SetModelValue(DataAccess.Model.V_STOCK01_PRODUCT01 model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定条件的实体
            switch (colName)
            {
				case "Id" :
					model.Id = (int)value;
                    break;
				case "STOCK_ID" :
					model.STOCK_ID = (string)value;
                    break;
				case "SHOP_ID" :
					model.SHOP_ID = (string)value;
                    break;
				case "SHOP_NAME1" :
					model.SHOP_NAME1 = (string)value;
                    break;
				case "PRCAREA_ID" :
					model.PRCAREA_ID = (string)value;
                    break;
				case "PROD_ID" :
					model.PROD_ID = (string)value;
                    break;
				case "PROD_NAME1" :
					model.PROD_NAME1 = (string)value;
                    break;
				case "PROD_NAME1_SPELLING" :
					model.PROD_NAME1_SPELLING = (string)value;
                    break;
				case "PROD_KIND" :
					model.PROD_KIND = (string)value;
                    break;
				case "PROD_DEP" :
					model.PROD_DEP = (string)value;
                    break;
				case "PROD_CATE" :
					model.PROD_CATE = (string)value;
                    break;
				case "PROD_UNIT" :
					model.PROD_UNIT = (string)value;
                    break;
				case "UNIT_NAME" :
					model.UNIT_NAME = (string)value;
                    break;
				case "PROD_UNIT1" :
					model.PROD_UNIT1 = (string)value;
                    break;
				case "UNIT_NAME1" :
					model.UNIT_NAME1 = (string)value;
                    break;
				case "PROD_CONVERT1" :
					model.PROD_CONVERT1 = (int)value;
                    break;
				case "PROD_UNIT2" :
					model.PROD_UNIT2 = (string)value;
                    break;
				case "UNIT_NAME2" :
					model.UNIT_NAME2 = (string)value;
                    break;
				case "PROD_CONVERT2" :
					model.PROD_CONVERT2 = (int)value;
                    break;
				case "SUP_ID" :
					model.SUP_ID = (string)value;
                    break;
				case "SUP_NAME" :
					model.SUP_NAME = (string)value;
                    break;
				case "SEND_TYPE" :
					model.SEND_TYPE = ConvertHelper.Ctinyint(value);
                    break;
				case "TAX_TYPE" :
					model.TAX_TYPE = ConvertHelper.Ctinyint(value);
                    break;
				case "Tax" :
					model.Tax = (int)value;
                    break;
				case "SUP_COST" :
					model.SUP_COST = (decimal)value;
                    break;
				case "SUP_COST1" :
					model.SUP_COST1 = (decimal)value;
                    break;
				case "SUP_COST2" :
					model.SUP_COST2 = (decimal)value;
                    break;
				case "S_Cost" :
					model.S_Cost = (decimal)value;
                    break;
				case "S_Cost1" :
					model.S_Cost1 = (decimal)value;
                    break;
				case "S_Cost2" :
					model.S_Cost2 = (decimal)value;
                    break;
				case "S_Ret_Cost" :
					model.S_Ret_Cost = (decimal)value;
                    break;
				case "S_Ret_Cost1" :
					model.S_Ret_Cost1 = (decimal)value;
                    break;
				case "S_Ret_Cost2" :
					model.S_Ret_Cost2 = (decimal)value;
                    break;
				case "COST" :
					model.COST = (decimal)value;
                    break;
				case "COST1" :
					model.COST1 = (decimal)value;
                    break;
				case "COST2" :
					model.COST2 = (decimal)value;
                    break;
				case "ORDER_UNIT" :
					model.ORDER_UNIT = (int)value;
                    break;
				case "ORDER_NAME" :
					model.ORDER_NAME = (string)value;
                    break;
				case "ORDER_QUAN" :
					model.ORDER_QUAN = (int)value;
                    break;
				case "Purchase_UNIT" :
					model.Purchase_UNIT = (int)value;
                    break;
				case "Purchase_UNIT_NAME" :
					model.Purchase_UNIT_NAME = (string)value;
                    break;
				case "Purchase_QUAN" :
					model.Purchase_QUAN = (int)value;
                    break;
				case "SAFE_QUAN" :
					model.SAFE_QUAN = (int)value;
                    break;
				case "PROD_PRICE" :
					model.PROD_PRICE = (decimal)value;
                    break;
				case "ENABLE" :
					model.ENABLE = ConvertHelper.Ctinyint(value);
                    break;
				case "VISIBLE" :
					model.VISIBLE = ConvertHelper.Ctinyint(value);
                    break;
				case "BOM_ID" :
					model.BOM_ID = (string)value;
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
            }
		}

        #endregion

		#endregion

		#region 获取V_STOCK01_PRODUCT01表记录总数
        /// <summary>
        /// 获取V_STOCK01_PRODUCT01表记录总数
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
		/// 获取V_STOCK01_PRODUCT01表记录总数——从数据库中查询
		/// </summary>
        /// <param name="wheres">条件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionFun.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<V_STOCK01_PRODUCT01>(wheres);

		}

		/// <summary>
		/// 获取V_STOCK01_PRODUCT01表指定条件的记录总数——从数据库中查询
		/// </summary>
        /// <param name="expression">条件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<V_STOCK01_PRODUCT01, bool>> expression) {
            return new Select().From<V_STOCK01_PRODUCT01>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定条件的记录集合
        /// <summary>
        /// 查找指定条件的记录集合——从IIS缓存中查找
        /// </summary>
        /// <param name="expression">条件语句</param>
        public IList<DataAccess.Model.V_STOCK01_PRODUCT01> Find(Expression<Func<DataAccess.Model.V_STOCK01_PRODUCT01, bool>> expression)
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
            return V_STOCK01_PRODUCT01.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判断指定条件的记录是否存在——默认在IIS缓存中查找，如果没开启缓存时，则直接在数据库中查询出列表后，再从列表中查询
        /// </summary>
        /// <param name="expression">条件语句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.V_STOCK01_PRODUCT01, bool>> expression)
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

		#region 获取V_STOCK01_PRODUCT01表记录
		/// <summary>
		/// 获取V_STOCK01_PRODUCT01表记录
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
                return select.SelectDataTable<V_STOCK01_PRODUCT01>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //记录日志
                CommonBll.WriteLog("获取V_STOCK01_PRODUCT01表记录时出现异常", e);

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

		#region 添加与编辑V_STOCK01_PRODUCT01表记录
		/// <summary>
		/// 添加与编辑V_STOCK01_PRODUCT01记录
		/// </summary>
	    /// <param name="page">当前页面指针</param>
		/// <param name="model">V_STOCK01_PRODUCT01表实体</param>
        /// <param name="content">更新说明</param>
        /// <param name="isCache">是否更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
        public void Save(Page page, V_STOCK01_PRODUCT01 model, string content = null, bool isCache = true, bool isAddUseLog = true)
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
						content = "{0}" + (model.Id == 0 ? "添加" : "编辑") + "V_STOCK01_PRODUCT01记录成功，ID为【" + model.Id + "】";
					}

					//添加用户访问记录
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "执行V_STOCK01_PRODUCT01Bll.Save()函数出错！";

				//出现异常，保存出错日志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 删除V_STOCK01_PRODUCT01表记录
		/// <summary>
		/// 删除V_STOCK01_PRODUCT01表记录
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="id">记录的主键值</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//设置Sql语句
			var sql = string.Format("delete from {0} where {1} = {2}", V_STOCK01_PRODUCT01Table.TableName,  V_STOCK01_PRODUCT01Table.Id, id);

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
				UseLogBll.GetInstence().Save(page, "{0}删除了V_STOCK01_PRODUCT01表id为【" + id + "】的记录！");
			}
		}

		/// <summary>
		/// 删除V_STOCK01_PRODUCT01表记录
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
			var sql = string.Format("delete from {0} where {1} in ({2})", V_STOCK01_PRODUCT01Table.TableName,  V_STOCK01_PRODUCT01Table.Id, str);

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
				UseLogBll.GetInstence().Save(page, "{0}删除了V_STOCK01_PRODUCT01表id为【" + str + "】的记录！");
			}
		}

		/// <summary>
        /// 获取数据表中的某个值——从数据库中查询，如果使用了缓存，删除成功后会清空本表的所有缓存记录，然后重新加载进缓存
        /// </summary>
        /// <param name="page">当前页面指针</param>
        /// <param name="expression">条件语句</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
        public void Delete(Page page, Expression<Func<V_STOCK01_PRODUCT01, bool>> expression, bool isAddUseLog = true)
        {
			//执行删除
			V_STOCK01_PRODUCT01.Delete(expression);

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
				UseLogBll.GetInstence().Save(page, "{0}删除了V_STOCK01_PRODUCT01表记录！");
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
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "V_STOCK01_PRODUCT01", sortName, "Id"))
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
				UseLogBll.GetInstence().Save(page, "{0}更新了V_STOCK01_PRODUCT01表排序！");

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
			if (CommonBll.AutoSort("Id", "V_STOCK01_PRODUCT01", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
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
				UseLogBll.GetInstence().Save(page, "{0}对V_STOCK01_PRODUCT01表进行了自动排序操作！");

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
                conditionColName = V_STOCK01_PRODUCT01Table.Id;

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
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.V_STOCK01_PRODUCT01, bool>> expression)
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
            return select.GetColumnsValue<V_STOCK01_PRODUCT01>(colName, wheres);
        }

		/// <summary>
        /// 返回实体中指定字段名的值
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="colName">获取的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.V_STOCK01_PRODUCT01 model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "STOCK_ID" :
					return model.STOCK_ID;
				case "SHOP_ID" :
					return model.SHOP_ID;
				case "SHOP_NAME1" :
					return model.SHOP_NAME1;
				case "PRCAREA_ID" :
					return model.PRCAREA_ID;
				case "PROD_ID" :
					return model.PROD_ID;
				case "PROD_NAME1" :
					return model.PROD_NAME1;
				case "PROD_NAME1_SPELLING" :
					return model.PROD_NAME1_SPELLING;
				case "PROD_KIND" :
					return model.PROD_KIND;
				case "PROD_DEP" :
					return model.PROD_DEP;
				case "PROD_CATE" :
					return model.PROD_CATE;
				case "PROD_UNIT" :
					return model.PROD_UNIT;
				case "UNIT_NAME" :
					return model.UNIT_NAME;
				case "PROD_UNIT1" :
					return model.PROD_UNIT1;
				case "UNIT_NAME1" :
					return model.UNIT_NAME1;
				case "PROD_CONVERT1" :
					return model.PROD_CONVERT1;
				case "PROD_UNIT2" :
					return model.PROD_UNIT2;
				case "UNIT_NAME2" :
					return model.UNIT_NAME2;
				case "PROD_CONVERT2" :
					return model.PROD_CONVERT2;
				case "SUP_ID" :
					return model.SUP_ID;
				case "SUP_NAME" :
					return model.SUP_NAME;
				case "SEND_TYPE" :
					return model.SEND_TYPE;
				case "TAX_TYPE" :
					return model.TAX_TYPE;
				case "Tax" :
					return model.Tax;
				case "SUP_COST" :
					return model.SUP_COST;
				case "SUP_COST1" :
					return model.SUP_COST1;
				case "SUP_COST2" :
					return model.SUP_COST2;
				case "S_Cost" :
					return model.S_Cost;
				case "S_Cost1" :
					return model.S_Cost1;
				case "S_Cost2" :
					return model.S_Cost2;
				case "S_Ret_Cost" :
					return model.S_Ret_Cost;
				case "S_Ret_Cost1" :
					return model.S_Ret_Cost1;
				case "S_Ret_Cost2" :
					return model.S_Ret_Cost2;
				case "COST" :
					return model.COST;
				case "COST1" :
					return model.COST1;
				case "COST2" :
					return model.COST2;
				case "ORDER_UNIT" :
					return model.ORDER_UNIT;
				case "ORDER_NAME" :
					return model.ORDER_NAME;
				case "ORDER_QUAN" :
					return model.ORDER_QUAN;
				case "Purchase_UNIT" :
					return model.Purchase_UNIT;
				case "Purchase_UNIT_NAME" :
					return model.Purchase_UNIT_NAME;
				case "Purchase_QUAN" :
					return model.Purchase_QUAN;
				case "SAFE_QUAN" :
					return model.SAFE_QUAN;
				case "PROD_PRICE" :
					return model.PROD_PRICE;
				case "ENABLE" :
					return model.ENABLE;
				case "VISIBLE" :
					return model.VISIBLE;
				case "BOM_ID" :
					return model.BOM_ID;
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
			}

			return null;
		}

		#endregion
		
		#region 更新V_STOCK01_PRODUCT01表指定字段值
		/// <summary>更新V_STOCK01_PRODUCT01表记录指定字段值，如果使用了缓存，保存成功后会清空本表的所有缓存记录，然后重新加载进缓存</summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="dic">需要更新的字段与值</param>
		/// <param name="wheres">条件</param>
		/// <param name="content">更新说明</param>
		/// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionFun.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<V_STOCK01_PRODUCT01>(dic, wheres);

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
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}修改了V_STOCK01_PRODUCT01表记录。");				
				}
				else
				{
					//添加用户操作记录
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新V_STOCK01_PRODUCT01表指定主键Id的字段值
		/// <summary>更新V_STOCK01_PRODUCT01表记录指定字段值</summary>
        /// <param name="page">当前页面指针</param>
        /// <param name="id">主键Id，当小于等于0时，则更新所有记录</param>
	    /// <param name="dic">需要更新的字段与值</param>
	    /// <param name="content">更新说明</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
	    public void UpdateValue(Page page, int id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}修改了V_STOCK01_PRODUCT01表主键Id值为" + id + "的记录。";
			
            //条件
		    List<ConditionFun.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionFun.SqlqueryCondition>();
                wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.Id, Comparison.Equals, id));
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

        /// <summary>更新V_STOCK01_PRODUCT01表记录指定字段值（更新一个字段值）</summary>
        /// <param name="page">当前页面指针</param>
        /// <param name="id">主键Id，当小于等于0时，则更新所有记录</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新说明</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
        public void UpdateValue(Page page, int id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}修改了V_STOCK01_PRODUCT01表主键Id值为" + id + "的记录，将" + columnName + "字段值修改为" + columnValue;
            //设置更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//执行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新V_STOCK01_PRODUCT01表记录指定字段值（更新两个字段值）</summary>
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
            content = content != "" ? content : "{0}修改了V_STOCK01_PRODUCT01表主键Id值为" + id + "的记录，将" + columnName1 + "字段值修改为" + columnValue1 + "，" + columnName2 + "字段值修改为" + columnValue2;
            //设置更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//执行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 更新SEND_TYPE字段值
		/// <summary>
		/// 更新SEND_TYPE字段值
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="pkValue">主键Id，当等于0时，则更新所有记录</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateSEND_TYPE(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//设置更新值
			var setValue = new Dictionary<string, object>();
			setValue[V_STOCK01_PRODUCT01Table.SEND_TYPE] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了V_STOCK01_PRODUCT01表id为【" + pkValue + "】的记录，更新内容为将SEND_TYPE字段值修改为" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新TAX_TYPE字段值
		/// <summary>
		/// 更新TAX_TYPE字段值
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="pkValue">主键Id，当等于0时，则更新所有记录</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateTAX_TYPE(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//设置更新值
			var setValue = new Dictionary<string, object>();
			setValue[V_STOCK01_PRODUCT01Table.TAX_TYPE] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了V_STOCK01_PRODUCT01表id为【" + pkValue + "】的记录，更新内容为将TAX_TYPE字段值修改为" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新ENABLE字段值
		/// <summary>
		/// 更新ENABLE字段值
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="pkValue">主键Id，当等于0时，则更新所有记录</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateENABLE(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//设置更新值
			var setValue = new Dictionary<string, object>();
			setValue[V_STOCK01_PRODUCT01Table.ENABLE] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了V_STOCK01_PRODUCT01表id为【" + pkValue + "】的记录，更新内容为将ENABLE字段值修改为" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新VISIBLE字段值
		/// <summary>
		/// 更新VISIBLE字段值
		/// </summary>
		/// <param name="page">当前页面指针</param>
		/// <param name="pkValue">主键Id，当等于0时，则更新所有记录</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否同步更新缓存</param>
		/// <param name="isAddUseLog">是否添加用户操作日志</param>
		public void UpdateVISIBLE(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//设置更新值
			var setValue = new Dictionary<string, object>();
			setValue[V_STOCK01_PRODUCT01Table.VISIBLE] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了V_STOCK01_PRODUCT01表id为【" + pkValue + "】的记录，更新内容为将VISIBLE字段值修改为" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
    
		#endregion 模版生成函数

    } 
}
