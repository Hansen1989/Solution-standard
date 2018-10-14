


using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;

namespace Solution.DataAccess.DataModel
{
    public partial class SolutionDataBase_standardDB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        private static IDataProvider _idDataProvider;
        public static IDataProvider GetDataProvider()
        {
            if (_idDataProvider == null)
                _idDataProvider = ProviderFactory.GetProvider("conn");

            return _idDataProvider;
        }

        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public SolutionDataBase_standardDB() 
        {
            if (DataProvider == null) {
                DataProvider = GetDataProvider();
            }
            //else {
            //    DataProvider = DefaultDataProvider;
            //}
            Init();
        }

        public SolutionDataBase_standardDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public SolutionDataBase_standardDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			
        public Query<DataAccess.Model.Adjust00> Adjust00 { get; set; }
        public Query<DataAccess.Model.Adjust01> Adjust01 { get; set; }
        public Query<DataAccess.Model.Branch> Branch { get; set; }
        public Query<DataAccess.Model.Col_Order00> Col_Order00 { get; set; }
        public Query<DataAccess.Model.COL_ORDER01> COL_ORDER01 { get; set; }
        public Query<DataAccess.Model.COL_ORDER02> COL_ORDER02 { get; set; }
        public Query<DataAccess.Model.COMPONENT00> COMPONENT00 { get; set; }
        public Query<DataAccess.Model.COMPONENT01> COMPONENT01 { get; set; }
        public Query<DataAccess.Model.CONTRACT00> CONTRACT00 { get; set; }
        public Query<DataAccess.Model.CONTRACT01> CONTRACT01 { get; set; }
        public Query<DataAccess.Model.Dispose00> Dispose00 { get; set; }
        public Query<DataAccess.Model.Dispose01> Dispose01 { get; set; }
        public Query<DataAccess.Model.DIVISION> DIVISION { get; set; }
        public Query<DataAccess.Model.DUE00> DUE00 { get; set; }
        public Query<DataAccess.Model.DUE01> DUE01 { get; set; }
        public Query<DataAccess.Model.EmailSendHistory> EmailSendHistory { get; set; }
        public Query<DataAccess.Model.EMPLOYEE> EMPLOYEE { get; set; }
        public Query<DataAccess.Model.GROUPAREA> GROUPAREA { get; set; }
        public Query<DataAccess.Model.HEAD_SHOP_ACCOUNT> HEAD_SHOP_ACCOUNT { get; set; }
        public Query<DataAccess.Model.HEAD_SHOP_BILL> HEAD_SHOP_BILL { get; set; }
        public Query<DataAccess.Model.HEAD_SHOP_PAY_HISTORY> HEAD_SHOP_PAY_HISTORY { get; set; }
        public Query<DataAccess.Model.IN_BACK00> IN_BACK00 { get; set; }
        public Query<DataAccess.Model.IN_BACK01> IN_BACK01 { get; set; }
        public Query<DataAccess.Model.IN00> IN00 { get; set; }
        public Query<DataAccess.Model.IN01> IN01 { get; set; }
        public Query<DataAccess.Model.Information> Information { get; set; }
        public Query<DataAccess.Model.InformationClass> InformationClass { get; set; }
        public Query<DataAccess.Model.Inventory00> Inventory00 { get; set; }
        public Query<DataAccess.Model.Inventory01> Inventory01 { get; set; }
        public Query<DataAccess.Model.LoginLog> LoginLog { get; set; }
        public Query<DataAccess.Model.Manager> Manager { get; set; }
        public Query<DataAccess.Model.Material00> Material00 { get; set; }
        public Query<DataAccess.Model.Material01> Material01 { get; set; }
        public Query<DataAccess.Model.MenuInfo> MenuInfo { get; set; }
        public Query<DataAccess.Model.OnlineUsers> OnlineUsers { get; set; }
        public Query<DataAccess.Model.ORDER_DEP00> ORDER_DEP00 { get; set; }
        public Query<DataAccess.Model.ORDER_DEP01> ORDER_DEP01 { get; set; }
        public Query<DataAccess.Model.ORDER_DEP02> ORDER_DEP02 { get; set; }
        public Query<DataAccess.Model.ORDER00> ORDER00 { get; set; }
        public Query<DataAccess.Model.ORDER01> ORDER01 { get; set; }
        public Query<DataAccess.Model.OUT_BACK00> OUT_BACK00 { get; set; }
        public Query<DataAccess.Model.OUT_BACK01> OUT_BACK01 { get; set; }
        public Query<DataAccess.Model.OUT00> OUT00 { get; set; }
        public Query<DataAccess.Model.OUT01> OUT01 { get; set; }
        public Query<DataAccess.Model.PagePowerSign> PagePowerSign { get; set; }
        public Query<DataAccess.Model.PagePowerSignPublic> PagePowerSignPublic { get; set; }
        public Query<DataAccess.Model.PLAN00> PLAN00 { get; set; }
        public Query<DataAccess.Model.PLAN01> PLAN01 { get; set; }
        public Query<DataAccess.Model.PLAN02> PLAN02 { get; set; }
        public Query<DataAccess.Model.Position> Position { get; set; }
        public Query<DataAccess.Model.PREPARE00> PREPARE00 { get; set; }
        public Query<DataAccess.Model.PREPARE01> PREPARE01 { get; set; }
        public Query<DataAccess.Model.PROD_Cate> PROD_Cate { get; set; }
        public Query<DataAccess.Model.PROD_DEP> PROD_DEP { get; set; }
        public Query<DataAccess.Model.PROD_KIND> PROD_KIND { get; set; }
        public Query<DataAccess.Model.PROD_UNIT> PROD_UNIT { get; set; }
        public Query<DataAccess.Model.PRODUCT00> PRODUCT00 { get; set; }
        public Query<DataAccess.Model.PRODUCT01> PRODUCT01 { get; set; }
        public Query<DataAccess.Model.Purchase00> Purchase00 { get; set; }
        public Query<DataAccess.Model.Purchase01> Purchase01 { get; set; }
        public Query<DataAccess.Model.RECEIVABLES00> RECEIVABLES00 { get; set; }
        public Query<DataAccess.Model.RECEIVABLES01> RECEIVABLES01 { get; set; }
        public Query<DataAccess.Model.SHOP_ACCOUNT> SHOP_ACCOUNT { get; set; }
        public Query<DataAccess.Model.SHOP_BILL> SHOP_BILL { get; set; }
        public Query<DataAccess.Model.SHOP_PAY_HISOTRY> SHOP_PAY_HISOTRY { get; set; }
        public Query<DataAccess.Model.SHOP_PRICE_AREA> SHOP_PRICE_AREA { get; set; }
        public Query<DataAccess.Model.SHOP_SUPPLIER_RELATION> SHOP_SUPPLIER_RELATION { get; set; }
        public Query<DataAccess.Model.SHOP00> SHOP00 { get; set; }
        public Query<DataAccess.Model.STOCK> STOCK { get; set; }
        public Query<DataAccess.Model.STOCK_SHOP00> STOCK_SHOP00 { get; set; }
        public Query<DataAccess.Model.STOCK01> STOCK01 { get; set; }
        public Query<DataAccess.Model.STOCK02> STOCK02 { get; set; }
        public Query<DataAccess.Model.SUPPLIERS> SUPPLIERS { get; set; }
        public Query<DataAccess.Model.SYS_PARAMATERS> SYS_PARAMATERS { get; set; }
        public Query<DataAccess.Model.TABLE_SEED> TABLE_SEED { get; set; }
        public Query<DataAccess.Model.TAKEIN00> TAKEIN00 { get; set; }
        public Query<DataAccess.Model.TAKEIN01> TAKEIN01 { get; set; }
        public Query<DataAccess.Model.TAKEIN10> TAKEIN10 { get; set; }
        public Query<DataAccess.Model.TAKEIN11> TAKEIN11 { get; set; }
        public Query<DataAccess.Model.TEST> TEST { get; set; }
        public Query<DataAccess.Model.UploadConfig> UploadConfig { get; set; }
        public Query<DataAccess.Model.UploadFile> UploadFile { get; set; }
        public Query<DataAccess.Model.UploadType> UploadType { get; set; }
        public Query<DataAccess.Model.UseLog> UseLog { get; set; }
        public Query<DataAccess.Model.V_COMPONENT01_PRODUCT00> V_COMPONENT01_PRODUCT00 { get; set; }
        public Query<DataAccess.Model.V_IN01_PRODUCT01> V_IN01_PRODUCT01 { get; set; }
        public Query<DataAccess.Model.V_ORDER01_PRODUCT01> V_ORDER01_PRODUCT01 { get; set; }
        public Query<DataAccess.Model.V_ORDERDEP02_PRODDEP> V_ORDERDEP02_PRODDEP { get; set; }
        public Query<DataAccess.Model.V_OUT_BACK01_PRODUCT00> V_OUT_BACK01_PRODUCT00 { get; set; }
        public Query<DataAccess.Model.V_OUT01_PRODUCT00> V_OUT01_PRODUCT00 { get; set; }
        public Query<DataAccess.Model.V_Position_Branch> V_Position_Branch { get; set; }
        public Query<DataAccess.Model.V_PROD_CATE> V_PROD_CATE { get; set; }
        public Query<DataAccess.Model.V_PROD_DEP> V_PROD_DEP { get; set; }
        public Query<DataAccess.Model.V_PRODUCT_COMPONENT00> V_PRODUCT_COMPONENT00 { get; set; }
        public Query<DataAccess.Model.V_Product01_PRCAREA> V_Product01_PRCAREA { get; set; }
        public Query<DataAccess.Model.V_Purchase01_PRODUCT00> V_Purchase01_PRODUCT00 { get; set; }
        public Query<DataAccess.Model.V_STOCK_SHOP00> V_STOCK_SHOP00 { get; set; }
        public Query<DataAccess.Model.V_STOCK01_PRODUCT00> V_STOCK01_PRODUCT00 { get; set; }
        public Query<DataAccess.Model.V_STOCK01_PRODUCT01> V_STOCK01_PRODUCT01 { get; set; }
        public Query<DataAccess.Model.V_STOCK02_PRODUCT00> V_STOCK02_PRODUCT00 { get; set; }
        public Query<DataAccess.Model.WebConfig> WebConfig { get; set; }

			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);

            #region ' Query Defs '
            Adjust00 = new Query<DataAccess.Model.Adjust00>(provider);
            Adjust01 = new Query<DataAccess.Model.Adjust01>(provider);
            Branch = new Query<DataAccess.Model.Branch>(provider);
            Col_Order00 = new Query<DataAccess.Model.Col_Order00>(provider);
            COL_ORDER01 = new Query<DataAccess.Model.COL_ORDER01>(provider);
            COL_ORDER02 = new Query<DataAccess.Model.COL_ORDER02>(provider);
            COMPONENT00 = new Query<DataAccess.Model.COMPONENT00>(provider);
            COMPONENT01 = new Query<DataAccess.Model.COMPONENT01>(provider);
            CONTRACT00 = new Query<DataAccess.Model.CONTRACT00>(provider);
            CONTRACT01 = new Query<DataAccess.Model.CONTRACT01>(provider);
            Dispose00 = new Query<DataAccess.Model.Dispose00>(provider);
            Dispose01 = new Query<DataAccess.Model.Dispose01>(provider);
            DIVISION = new Query<DataAccess.Model.DIVISION>(provider);
            DUE00 = new Query<DataAccess.Model.DUE00>(provider);
            DUE01 = new Query<DataAccess.Model.DUE01>(provider);
            EmailSendHistory = new Query<DataAccess.Model.EmailSendHistory>(provider);
            EMPLOYEE = new Query<DataAccess.Model.EMPLOYEE>(provider);
            GROUPAREA = new Query<DataAccess.Model.GROUPAREA>(provider);
            HEAD_SHOP_ACCOUNT = new Query<DataAccess.Model.HEAD_SHOP_ACCOUNT>(provider);
            HEAD_SHOP_BILL = new Query<DataAccess.Model.HEAD_SHOP_BILL>(provider);
            HEAD_SHOP_PAY_HISTORY = new Query<DataAccess.Model.HEAD_SHOP_PAY_HISTORY>(provider);
            IN_BACK00 = new Query<DataAccess.Model.IN_BACK00>(provider);
            IN_BACK01 = new Query<DataAccess.Model.IN_BACK01>(provider);
            IN00 = new Query<DataAccess.Model.IN00>(provider);
            IN01 = new Query<DataAccess.Model.IN01>(provider);
            Information = new Query<DataAccess.Model.Information>(provider);
            InformationClass = new Query<DataAccess.Model.InformationClass>(provider);
            Inventory00 = new Query<DataAccess.Model.Inventory00>(provider);
            Inventory01 = new Query<DataAccess.Model.Inventory01>(provider);
            LoginLog = new Query<DataAccess.Model.LoginLog>(provider);
            Manager = new Query<DataAccess.Model.Manager>(provider);
            Material00 = new Query<DataAccess.Model.Material00>(provider);
            Material01 = new Query<DataAccess.Model.Material01>(provider);
            MenuInfo = new Query<DataAccess.Model.MenuInfo>(provider);
            OnlineUsers = new Query<DataAccess.Model.OnlineUsers>(provider);
            ORDER_DEP00 = new Query<DataAccess.Model.ORDER_DEP00>(provider);
            ORDER_DEP01 = new Query<DataAccess.Model.ORDER_DEP01>(provider);
            ORDER_DEP02 = new Query<DataAccess.Model.ORDER_DEP02>(provider);
            ORDER00 = new Query<DataAccess.Model.ORDER00>(provider);
            ORDER01 = new Query<DataAccess.Model.ORDER01>(provider);
            OUT_BACK00 = new Query<DataAccess.Model.OUT_BACK00>(provider);
            OUT_BACK01 = new Query<DataAccess.Model.OUT_BACK01>(provider);
            OUT00 = new Query<DataAccess.Model.OUT00>(provider);
            OUT01 = new Query<DataAccess.Model.OUT01>(provider);
            PagePowerSign = new Query<DataAccess.Model.PagePowerSign>(provider);
            PagePowerSignPublic = new Query<DataAccess.Model.PagePowerSignPublic>(provider);
            PLAN00 = new Query<DataAccess.Model.PLAN00>(provider);
            PLAN01 = new Query<DataAccess.Model.PLAN01>(provider);
            PLAN02 = new Query<DataAccess.Model.PLAN02>(provider);
            Position = new Query<DataAccess.Model.Position>(provider);
            PREPARE00 = new Query<DataAccess.Model.PREPARE00>(provider);
            PREPARE01 = new Query<DataAccess.Model.PREPARE01>(provider);
            PROD_Cate = new Query<DataAccess.Model.PROD_Cate>(provider);
            PROD_DEP = new Query<DataAccess.Model.PROD_DEP>(provider);
            PROD_KIND = new Query<DataAccess.Model.PROD_KIND>(provider);
            PROD_UNIT = new Query<DataAccess.Model.PROD_UNIT>(provider);
            PRODUCT00 = new Query<DataAccess.Model.PRODUCT00>(provider);
            PRODUCT01 = new Query<DataAccess.Model.PRODUCT01>(provider);
            Purchase00 = new Query<DataAccess.Model.Purchase00>(provider);
            Purchase01 = new Query<DataAccess.Model.Purchase01>(provider);
            RECEIVABLES00 = new Query<DataAccess.Model.RECEIVABLES00>(provider);
            RECEIVABLES01 = new Query<DataAccess.Model.RECEIVABLES01>(provider);
            SHOP_ACCOUNT = new Query<DataAccess.Model.SHOP_ACCOUNT>(provider);
            SHOP_BILL = new Query<DataAccess.Model.SHOP_BILL>(provider);
            SHOP_PAY_HISOTRY = new Query<DataAccess.Model.SHOP_PAY_HISOTRY>(provider);
            SHOP_PRICE_AREA = new Query<DataAccess.Model.SHOP_PRICE_AREA>(provider);
            SHOP_SUPPLIER_RELATION = new Query<DataAccess.Model.SHOP_SUPPLIER_RELATION>(provider);
            SHOP00 = new Query<DataAccess.Model.SHOP00>(provider);
            STOCK = new Query<DataAccess.Model.STOCK>(provider);
            STOCK_SHOP00 = new Query<DataAccess.Model.STOCK_SHOP00>(provider);
            STOCK01 = new Query<DataAccess.Model.STOCK01>(provider);
            STOCK02 = new Query<DataAccess.Model.STOCK02>(provider);
            SUPPLIERS = new Query<DataAccess.Model.SUPPLIERS>(provider);
            SYS_PARAMATERS = new Query<DataAccess.Model.SYS_PARAMATERS>(provider);
            TABLE_SEED = new Query<DataAccess.Model.TABLE_SEED>(provider);
            TAKEIN00 = new Query<DataAccess.Model.TAKEIN00>(provider);
            TAKEIN01 = new Query<DataAccess.Model.TAKEIN01>(provider);
            TAKEIN10 = new Query<DataAccess.Model.TAKEIN10>(provider);
            TAKEIN11 = new Query<DataAccess.Model.TAKEIN11>(provider);
            TEST = new Query<DataAccess.Model.TEST>(provider);
            UploadConfig = new Query<DataAccess.Model.UploadConfig>(provider);
            UploadFile = new Query<DataAccess.Model.UploadFile>(provider);
            UploadType = new Query<DataAccess.Model.UploadType>(provider);
            UseLog = new Query<DataAccess.Model.UseLog>(provider);
            V_COMPONENT01_PRODUCT00 = new Query<DataAccess.Model.V_COMPONENT01_PRODUCT00>(provider);
            V_IN01_PRODUCT01 = new Query<DataAccess.Model.V_IN01_PRODUCT01>(provider);
            V_ORDER01_PRODUCT01 = new Query<DataAccess.Model.V_ORDER01_PRODUCT01>(provider);
            V_ORDERDEP02_PRODDEP = new Query<DataAccess.Model.V_ORDERDEP02_PRODDEP>(provider);
            V_OUT_BACK01_PRODUCT00 = new Query<DataAccess.Model.V_OUT_BACK01_PRODUCT00>(provider);
            V_OUT01_PRODUCT00 = new Query<DataAccess.Model.V_OUT01_PRODUCT00>(provider);
            V_Position_Branch = new Query<DataAccess.Model.V_Position_Branch>(provider);
            V_PROD_CATE = new Query<DataAccess.Model.V_PROD_CATE>(provider);
            V_PROD_DEP = new Query<DataAccess.Model.V_PROD_DEP>(provider);
            V_PRODUCT_COMPONENT00 = new Query<DataAccess.Model.V_PRODUCT_COMPONENT00>(provider);
            V_Product01_PRCAREA = new Query<DataAccess.Model.V_Product01_PRCAREA>(provider);
            V_Purchase01_PRODUCT00 = new Query<DataAccess.Model.V_Purchase01_PRODUCT00>(provider);
            V_STOCK_SHOP00 = new Query<DataAccess.Model.V_STOCK_SHOP00>(provider);
            V_STOCK01_PRODUCT00 = new Query<DataAccess.Model.V_STOCK01_PRODUCT00>(provider);
            V_STOCK01_PRODUCT01 = new Query<DataAccess.Model.V_STOCK01_PRODUCT01>(provider);
            V_STOCK02_PRODUCT00 = new Query<DataAccess.Model.V_STOCK02_PRODUCT00>(provider);
            WebConfig = new Query<DataAccess.Model.WebConfig>(provider);
            #endregion


            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{
            	DataProvider.Schema.Tables.Add(new Adjust00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Adjust01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new BranchStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Col_Order00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new COL_ORDER01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new COL_ORDER02Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new COMPONENT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new COMPONENT01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new CONTRACT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new CONTRACT01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Dispose00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Dispose01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new DIVISIONStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new DUE00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new DUE01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new EmailSendHistoryStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new EMPLOYEEStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new GROUPAREAStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new HEAD_SHOP_ACCOUNTStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new HEAD_SHOP_BILLStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new HEAD_SHOP_PAY_HISTORYStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new IN_BACK00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new IN_BACK01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new IN00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new IN01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new InformationStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new InformationClassStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Inventory00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Inventory01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new LoginLogStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ManagerStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Material00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Material01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new MenuInfoStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new OnlineUsersStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ORDER_DEP00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ORDER_DEP01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ORDER_DEP02Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ORDER00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ORDER01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new OUT_BACK00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new OUT_BACK01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new OUT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new OUT01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PagePowerSignStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PagePowerSignPublicStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PLAN00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PLAN01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PLAN02Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PositionStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PREPARE00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PREPARE01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PROD_CateStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PROD_DEPStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PROD_KINDStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PROD_UNITStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PRODUCT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PRODUCT01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Purchase00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Purchase01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new RECEIVABLES00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new RECEIVABLES01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SHOP_ACCOUNTStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SHOP_BILLStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SHOP_PAY_HISOTRYStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SHOP_PRICE_AREAStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SHOP_SUPPLIER_RELATIONStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SHOP00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new STOCKStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new STOCK_SHOP00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new STOCK01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new STOCK02Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SUPPLIERSStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new SYS_PARAMATERSStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new TABLE_SEEDStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new TAKEIN00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new TAKEIN01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new TAKEIN10Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new TAKEIN11Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new TESTStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UploadConfigStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UploadFileStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UploadTypeStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UseLogStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_COMPONENT01_PRODUCT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_IN01_PRODUCT01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_ORDER01_PRODUCT01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_ORDERDEP02_PRODDEPStructs(DataProvider));
            	//DataProvider.Schema.Tables.Add(new V_OUT_BACK01_PRODUCT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_OUT01_PRODUCT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_Position_BranchStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_PROD_CATEStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_PROD_DEPStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_PRODUCT_COMPONENT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_Product01_PRCAREAStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_Purchase01_PRODUCT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_STOCK_SHOP00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_STOCK01_PRODUCT00Structs(DataProvider));
            	//DataProvider.Schema.Tables.Add(new V_STOCK01_PRODUCT01Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new V_STOCK02_PRODUCT00Structs(DataProvider));
            	DataProvider.Schema.Tables.Add(new WebConfigStructs(DataProvider));
            }
            #endregion
        }
        

        #region ' Helpers '
            
        internal static DateTime DateTimeNowTruncatedDownToSecond() {
            var now = DateTime.Now;
            return now.AddTicks(-now.Ticks % TimeSpan.TicksPerSecond);
        }

        #endregion

    }
}