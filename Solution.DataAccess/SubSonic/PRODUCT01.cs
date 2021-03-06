 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using SubSonic.Repository;
using System.Data.Common;
using SubSonic.SqlGeneration.Schema;

namespace Solution.DataAccess.DataModel
{    
    /// <summary>
    /// A class which represents the PRODUCT01 table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class PRODUCT01: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PRODUCT01> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PRODUCT01>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PRODUCT01> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(PRODUCT01 item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PRODUCT01 item=new PRODUCT01();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PRODUCT01> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Solution.DataAccess.DataModel.SolutionDataBase_standardDB _db;
        public PRODUCT01(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PRODUCT01.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PRODUCT01>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PRODUCT01(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            PRCAREA_ID = readRecord.get_string("PRCAREA_ID",null);
               
            PROD_ID = readRecord.get_string("PROD_ID",null);
               
            SUP_ID = readRecord.get_string("SUP_ID",null);
               
            SEND_TYPE = readRecord.get_byte("SEND_TYPE",null);
               
            TAX_TYPE = readRecord.get_byte("TAX_TYPE",null);
               
            Tax = readRecord.get_int("Tax",null);
               
            SUP_COST = readRecord.get_decimal("SUP_COST",null);
               
            SUP_COST1 = readRecord.get_decimal("SUP_COST1",null);
               
            SUP_COST2 = readRecord.get_decimal("SUP_COST2",null);
               
            SUP_Return = readRecord.get_decimal("SUP_Return",null);
               
            SUP_Return1 = readRecord.get_decimal("SUP_Return1",null);
               
            SUP_Return2 = readRecord.get_decimal("SUP_Return2",null);
               
            U_Cost = readRecord.get_decimal("U_Cost",null);
               
            U_Cost1 = readRecord.get_decimal("U_Cost1",null);
               
            U_Cost2 = readRecord.get_decimal("U_Cost2",null);
               
            U_Ret_COST = readRecord.get_decimal("U_Ret_COST",null);
               
            U_Ret_COST1 = readRecord.get_decimal("U_Ret_COST1",null);
               
            U_Ret_COST2 = readRecord.get_decimal("U_Ret_COST2",null);
               
            T_COST = readRecord.get_decimal("T_COST",null);
               
            T_COST1 = readRecord.get_decimal("T_COST1",null);
               
            T_COST2 = readRecord.get_decimal("T_COST2",null);
               
            T_Ret_COST = readRecord.get_decimal("T_Ret_COST",null);
               
            T_Ret_COST1 = readRecord.get_decimal("T_Ret_COST1",null);
               
            T_Ret_COST2 = readRecord.get_decimal("T_Ret_COST2",null);
               
            COST = readRecord.get_decimal("COST",null);
               
            COST1 = readRecord.get_decimal("COST1",null);
               
            COST2 = readRecord.get_decimal("COST2",null);
               
            ENABLE = readRecord.get_byte("ENABLE",null);
               
            VISIBLE = readRecord.get_byte("VISIBLE",null);
               
            BOM_ID = readRecord.get_string("BOM_ID",null);
               
            CRT_DATETIME = readRecord.get_datetime("CRT_DATETIME",null);
               
            CRT_USER_ID = readRecord.get_string("CRT_USER_ID",null);
               
            MOD_DATETIME = readRecord.get_datetime("MOD_DATETIME",null);
               
            MOD_USER_ID = readRecord.get_string("MOD_USER_ID",null);
               
            LAST_UPDATE = readRecord.get_datetime("LAST_UPDATE",null);
               
            STATUS = readRecord.get_byte("STATUS",null);
               
            ORDER_UNIT = readRecord.get_int("ORDER_UNIT",null);
               
            ORDER_QUAN = readRecord.get_int("ORDER_QUAN",null);
               
            Purchase_UNIT = readRecord.get_int("Purchase_UNIT",null);
               
            Purchase_QUAN = readRecord.get_int("Purchase_QUAN",null);
               
            SAFE_QUAN = readRecord.get_int("SAFE_QUAN",null);
               
            PROD_PRICE = readRecord.get_decimal("PROD_PRICE",null);
                }   

        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PRODUCT01(Expression<Func<PRODUCT01, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PRODUCT01> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<PRODUCT01> _repo;
            
            if(db.TestMode){
                PRODUCT01.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PRODUCT01>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PRODUCT01> GetRepo(){
            return GetRepo("","");
        }
        
        public static PRODUCT01 SingleOrDefault(Expression<Func<PRODUCT01, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PRODUCT01 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PRODUCT01 SingleOrDefault(Expression<Func<PRODUCT01, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PRODUCT01 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PRODUCT01, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PRODUCT01, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PRODUCT01> Find(Expression<Func<PRODUCT01, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PRODUCT01> Find(Expression<Func<PRODUCT01, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PRODUCT01> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PRODUCT01> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PRODUCT01> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PRODUCT01> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PRODUCT01> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PRODUCT01> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.PRCAREA_ID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PRODUCT01)){
                PRODUCT01 compare=(PRODUCT01)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.PRCAREA_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "PRCAREA_ID";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "PRCAREA_ID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value || _isLoaded){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PRCAREA_ID;
		/// <summary>
		/// 
		/// </summary>
        public string PRCAREA_ID
        {
            get { return _PRCAREA_ID; }
            set
            {
                if(_PRCAREA_ID!=value || _isLoaded){
                    _PRCAREA_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PRCAREA_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_ID;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_ID
        {
            get { return _PROD_ID; }
            set
            {
                if(_PROD_ID!=value || _isLoaded){
                    _PROD_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_ID;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_ID
        {
            get { return _SUP_ID; }
            set
            {
                if(_SUP_ID!=value || _isLoaded){
                    _SUP_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _SEND_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public byte SEND_TYPE
        {
            get { return _SEND_TYPE; }
            set
            {
                if(_SEND_TYPE!=value || _isLoaded){
                    _SEND_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SEND_TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _TAX_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public byte TAX_TYPE
        {
            get { return _TAX_TYPE; }
            set
            {
                if(_TAX_TYPE!=value || _isLoaded){
                    _TAX_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TAX_TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Tax;
		/// <summary>
		/// 
		/// </summary>
        public int Tax
        {
            get { return _Tax; }
            set
            {
                if(_Tax!=value || _isLoaded){
                    _Tax=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Tax");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _SUP_COST;
		/// <summary>
		/// 
		/// </summary>
        public decimal SUP_COST
        {
            get { return _SUP_COST; }
            set
            {
                if(_SUP_COST!=value || _isLoaded){
                    _SUP_COST=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_COST");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _SUP_COST1;
		/// <summary>
		/// 
		/// </summary>
        public decimal SUP_COST1
        {
            get { return _SUP_COST1; }
            set
            {
                if(_SUP_COST1!=value || _isLoaded){
                    _SUP_COST1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_COST1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _SUP_COST2;
		/// <summary>
		/// 
		/// </summary>
        public decimal SUP_COST2
        {
            get { return _SUP_COST2; }
            set
            {
                if(_SUP_COST2!=value || _isLoaded){
                    _SUP_COST2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_COST2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _SUP_Return;
		/// <summary>
		/// 
		/// </summary>
        public decimal SUP_Return
        {
            get { return _SUP_Return; }
            set
            {
                if(_SUP_Return!=value || _isLoaded){
                    _SUP_Return=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_Return");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _SUP_Return1;
		/// <summary>
		/// 
		/// </summary>
        public decimal SUP_Return1
        {
            get { return _SUP_Return1; }
            set
            {
                if(_SUP_Return1!=value || _isLoaded){
                    _SUP_Return1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_Return1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _SUP_Return2;
		/// <summary>
		/// 
		/// </summary>
        public decimal SUP_Return2
        {
            get { return _SUP_Return2; }
            set
            {
                if(_SUP_Return2!=value || _isLoaded){
                    _SUP_Return2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_Return2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _U_Cost;
		/// <summary>
		/// 
		/// </summary>
        public decimal U_Cost
        {
            get { return _U_Cost; }
            set
            {
                if(_U_Cost!=value || _isLoaded){
                    _U_Cost=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="U_Cost");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _U_Cost1;
		/// <summary>
		/// 
		/// </summary>
        public decimal U_Cost1
        {
            get { return _U_Cost1; }
            set
            {
                if(_U_Cost1!=value || _isLoaded){
                    _U_Cost1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="U_Cost1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _U_Cost2;
		/// <summary>
		/// 
		/// </summary>
        public decimal U_Cost2
        {
            get { return _U_Cost2; }
            set
            {
                if(_U_Cost2!=value || _isLoaded){
                    _U_Cost2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="U_Cost2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _U_Ret_COST;
		/// <summary>
		/// 
		/// </summary>
        public decimal U_Ret_COST
        {
            get { return _U_Ret_COST; }
            set
            {
                if(_U_Ret_COST!=value || _isLoaded){
                    _U_Ret_COST=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="U_Ret_COST");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _U_Ret_COST1;
		/// <summary>
		/// 
		/// </summary>
        public decimal U_Ret_COST1
        {
            get { return _U_Ret_COST1; }
            set
            {
                if(_U_Ret_COST1!=value || _isLoaded){
                    _U_Ret_COST1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="U_Ret_COST1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _U_Ret_COST2;
		/// <summary>
		/// 
		/// </summary>
        public decimal U_Ret_COST2
        {
            get { return _U_Ret_COST2; }
            set
            {
                if(_U_Ret_COST2!=value || _isLoaded){
                    _U_Ret_COST2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="U_Ret_COST2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _T_COST;
		/// <summary>
		/// 
		/// </summary>
        public decimal T_COST
        {
            get { return _T_COST; }
            set
            {
                if(_T_COST!=value || _isLoaded){
                    _T_COST=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T_COST");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _T_COST1;
		/// <summary>
		/// 
		/// </summary>
        public decimal T_COST1
        {
            get { return _T_COST1; }
            set
            {
                if(_T_COST1!=value || _isLoaded){
                    _T_COST1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T_COST1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _T_COST2;
		/// <summary>
		/// 
		/// </summary>
        public decimal T_COST2
        {
            get { return _T_COST2; }
            set
            {
                if(_T_COST2!=value || _isLoaded){
                    _T_COST2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T_COST2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _T_Ret_COST;
		/// <summary>
		/// 
		/// </summary>
        public decimal T_Ret_COST
        {
            get { return _T_Ret_COST; }
            set
            {
                if(_T_Ret_COST!=value || _isLoaded){
                    _T_Ret_COST=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T_Ret_COST");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _T_Ret_COST1;
		/// <summary>
		/// 
		/// </summary>
        public decimal T_Ret_COST1
        {
            get { return _T_Ret_COST1; }
            set
            {
                if(_T_Ret_COST1!=value || _isLoaded){
                    _T_Ret_COST1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T_Ret_COST1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _T_Ret_COST2;
		/// <summary>
		/// 
		/// </summary>
        public decimal T_Ret_COST2
        {
            get { return _T_Ret_COST2; }
            set
            {
                if(_T_Ret_COST2!=value || _isLoaded){
                    _T_Ret_COST2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T_Ret_COST2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _COST;
		/// <summary>
		/// 
		/// </summary>
        public decimal COST
        {
            get { return _COST; }
            set
            {
                if(_COST!=value || _isLoaded){
                    _COST=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COST");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _COST1;
		/// <summary>
		/// 
		/// </summary>
        public decimal COST1
        {
            get { return _COST1; }
            set
            {
                if(_COST1!=value || _isLoaded){
                    _COST1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COST1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _COST2;
		/// <summary>
		/// 
		/// </summary>
        public decimal COST2
        {
            get { return _COST2; }
            set
            {
                if(_COST2!=value || _isLoaded){
                    _COST2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COST2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _ENABLE;
		/// <summary>
		/// 
		/// </summary>
        public byte ENABLE
        {
            get { return _ENABLE; }
            set
            {
                if(_ENABLE!=value || _isLoaded){
                    _ENABLE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ENABLE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _VISIBLE;
		/// <summary>
		/// 
		/// </summary>
        public byte VISIBLE
        {
            get { return _VISIBLE; }
            set
            {
                if(_VISIBLE!=value || _isLoaded){
                    _VISIBLE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="VISIBLE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _BOM_ID;
		/// <summary>
		/// 
		/// </summary>
        public string BOM_ID
        {
            get { return _BOM_ID; }
            set
            {
                if(_BOM_ID!=value || _isLoaded){
                    _BOM_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BOM_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _CRT_DATETIME;
		/// <summary>
		/// 
		/// </summary>
        public DateTime CRT_DATETIME
        {
            get { return _CRT_DATETIME; }
            set
            {
                if(_CRT_DATETIME!=value || _isLoaded){
                    _CRT_DATETIME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CRT_DATETIME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CRT_USER_ID;
		/// <summary>
		/// 
		/// </summary>
        public string CRT_USER_ID
        {
            get { return _CRT_USER_ID; }
            set
            {
                if(_CRT_USER_ID!=value || _isLoaded){
                    _CRT_USER_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CRT_USER_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _MOD_DATETIME;
		/// <summary>
		/// 
		/// </summary>
        public DateTime MOD_DATETIME
        {
            get { return _MOD_DATETIME; }
            set
            {
                if(_MOD_DATETIME!=value || _isLoaded){
                    _MOD_DATETIME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MOD_DATETIME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MOD_USER_ID;
		/// <summary>
		/// 
		/// </summary>
        public string MOD_USER_ID
        {
            get { return _MOD_USER_ID; }
            set
            {
                if(_MOD_USER_ID!=value || _isLoaded){
                    _MOD_USER_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MOD_USER_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LAST_UPDATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime LAST_UPDATE
        {
            get { return _LAST_UPDATE; }
            set
            {
                if(_LAST_UPDATE!=value || _isLoaded){
                    _LAST_UPDATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LAST_UPDATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _STATUS;
		/// <summary>
		/// 
		/// </summary>
        public byte STATUS
        {
            get { return _STATUS; }
            set
            {
                if(_STATUS!=value || _isLoaded){
                    _STATUS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STATUS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ORDER_UNIT;
		/// <summary>
		/// 
		/// </summary>
        public int ORDER_UNIT
        {
            get { return _ORDER_UNIT; }
            set
            {
                if(_ORDER_UNIT!=value || _isLoaded){
                    _ORDER_UNIT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ORDER_UNIT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ORDER_QUAN;
		/// <summary>
		/// 
		/// </summary>
        public int ORDER_QUAN
        {
            get { return _ORDER_QUAN; }
            set
            {
                if(_ORDER_QUAN!=value || _isLoaded){
                    _ORDER_QUAN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ORDER_QUAN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Purchase_UNIT;
		/// <summary>
		/// 
		/// </summary>
        public int Purchase_UNIT
        {
            get { return _Purchase_UNIT; }
            set
            {
                if(_Purchase_UNIT!=value || _isLoaded){
                    _Purchase_UNIT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Purchase_UNIT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Purchase_QUAN;
		/// <summary>
		/// 
		/// </summary>
        public int Purchase_QUAN
        {
            get { return _Purchase_QUAN; }
            set
            {
                if(_Purchase_QUAN!=value || _isLoaded){
                    _Purchase_QUAN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Purchase_QUAN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SAFE_QUAN;
		/// <summary>
		/// 
		/// </summary>
        public int SAFE_QUAN
        {
            get { return _SAFE_QUAN; }
            set
            {
                if(_SAFE_QUAN!=value || _isLoaded){
                    _SAFE_QUAN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SAFE_QUAN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _PROD_PRICE;
		/// <summary>
		/// 
		/// </summary>
        public decimal PROD_PRICE
        {
            get { return _PROD_PRICE; }
            set
            {
                if(_PROD_PRICE!=value || _isLoaded){
                    _PROD_PRICE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_PRICE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
				_repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }

        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PRODUCT01, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}

