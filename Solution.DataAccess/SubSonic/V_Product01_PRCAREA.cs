 
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
    /// A class which represents the V_Product01_PRCAREA table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class V_Product01_PRCAREA: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<V_Product01_PRCAREA> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<V_Product01_PRCAREA>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<V_Product01_PRCAREA> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(V_Product01_PRCAREA item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                V_Product01_PRCAREA item=new V_Product01_PRCAREA();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<V_Product01_PRCAREA> _repo;
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
        public V_Product01_PRCAREA(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                V_Product01_PRCAREA.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<V_Product01_PRCAREA>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public V_Product01_PRCAREA(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            PRCAREA_ID = readRecord.get_string("PRCAREA_ID",null);
               
            PRCAREA_NAME = readRecord.get_string("PRCAREA_NAME",null);
               
            PROD_ID = readRecord.get_string("PROD_ID",null);
               
            PROD_NAME1 = readRecord.get_string("PROD_NAME1",null);
               
            PROD_NAME1_SPELLING = readRecord.get_string("PROD_NAME1_SPELLING",null);
               
            PROD_KIND = readRecord.get_string("PROD_KIND",null);
               
            PROD_DEP = readRecord.get_string("PROD_DEP",null);
               
            PROD_CATE = readRecord.get_string("PROD_CATE",null);
               
            PROD_UNIT = readRecord.get_string("PROD_UNIT",null);
               
            UNIT_NAME = readRecord.get_string("UNIT_NAME",null);
               
            PROD_UNIT1 = readRecord.get_string("PROD_UNIT1",null);
               
            UNIT_NAME1 = readRecord.get_string("UNIT_NAME1",null);
               
            PROD_CONVERT1 = readRecord.get_int("PROD_CONVERT1",null);
               
            PROD_UNIT2 = readRecord.get_string("PROD_UNIT2",null);
               
            UNIT_NAME2 = readRecord.get_string("UNIT_NAME2",null);
               
            PROD_CONVERT2 = readRecord.get_int("PROD_CONVERT2",null);
               
            SUP_ID = readRecord.get_string("SUP_ID",null);
               
            SUP_NAME = readRecord.get_string("SUP_NAME",null);
               
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
               
            ORDER_UNIT = readRecord.get_int("ORDER_UNIT",null);
               
            ORDER_QUAN = readRecord.get_int("ORDER_QUAN",null);
               
            Purchase_UNIT = readRecord.get_int("Purchase_UNIT",null);
               
            Purchase_UNIT_NAME = readRecord.get_string("Purchase_UNIT_NAME",null);
               
            Purchase_QUAN = readRecord.get_int("Purchase_QUAN",null);
               
            SAFE_QUAN = readRecord.get_int("SAFE_QUAN",null);
               
            PROD_PRICE = readRecord.get_decimal("PROD_PRICE",null);
               
            ENABLE = readRecord.get_byte("ENABLE",null);
               
            VISIBLE = readRecord.get_byte("VISIBLE",null);
               
            BOM_ID = readRecord.get_string("BOM_ID",null);
               
            CRT_DATETIME = readRecord.get_datetime("CRT_DATETIME",null);
               
            CRT_USER_ID = readRecord.get_string("CRT_USER_ID",null);
               
            MOD_DATETIME = readRecord.get_datetime("MOD_DATETIME",null);
               
            MOD_USER_ID = readRecord.get_string("MOD_USER_ID",null);
               
            LAST_UPDATE = readRecord.get_datetime("LAST_UPDATE",null);
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

        public V_Product01_PRCAREA(Expression<Func<V_Product01_PRCAREA, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<V_Product01_PRCAREA> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<V_Product01_PRCAREA> _repo;
            
            if(db.TestMode){
                V_Product01_PRCAREA.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<V_Product01_PRCAREA>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<V_Product01_PRCAREA> GetRepo(){
            return GetRepo("","");
        }
        
        public static V_Product01_PRCAREA SingleOrDefault(Expression<Func<V_Product01_PRCAREA, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            V_Product01_PRCAREA single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static V_Product01_PRCAREA SingleOrDefault(Expression<Func<V_Product01_PRCAREA, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            V_Product01_PRCAREA single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<V_Product01_PRCAREA, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<V_Product01_PRCAREA, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<V_Product01_PRCAREA> Find(Expression<Func<V_Product01_PRCAREA, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<V_Product01_PRCAREA> Find(Expression<Func<V_Product01_PRCAREA, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<V_Product01_PRCAREA> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<V_Product01_PRCAREA> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<V_Product01_PRCAREA> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<V_Product01_PRCAREA> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<V_Product01_PRCAREA> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<V_Product01_PRCAREA> GetPaged(int pageIndex, int pageSize) {
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
            if(obj.GetType()==typeof(V_Product01_PRCAREA)){
                V_Product01_PRCAREA compare=(V_Product01_PRCAREA)obj;
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

        string _PRCAREA_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string PRCAREA_NAME
        {
            get { return _PRCAREA_NAME; }
            set
            {
                if(_PRCAREA_NAME!=value || _isLoaded){
                    _PRCAREA_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PRCAREA_NAME");
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

        string _PROD_NAME1;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_NAME1
        {
            get { return _PROD_NAME1; }
            set
            {
                if(_PROD_NAME1!=value || _isLoaded){
                    _PROD_NAME1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_NAME1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_NAME1_SPELLING;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_NAME1_SPELLING
        {
            get { return _PROD_NAME1_SPELLING; }
            set
            {
                if(_PROD_NAME1_SPELLING!=value || _isLoaded){
                    _PROD_NAME1_SPELLING=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_NAME1_SPELLING");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_KIND;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_KIND
        {
            get { return _PROD_KIND; }
            set
            {
                if(_PROD_KIND!=value || _isLoaded){
                    _PROD_KIND=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_KIND");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_DEP;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_DEP
        {
            get { return _PROD_DEP; }
            set
            {
                if(_PROD_DEP!=value || _isLoaded){
                    _PROD_DEP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_DEP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_CATE;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_CATE
        {
            get { return _PROD_CATE; }
            set
            {
                if(_PROD_CATE!=value || _isLoaded){
                    _PROD_CATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_CATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_UNIT;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_UNIT
        {
            get { return _PROD_UNIT; }
            set
            {
                if(_PROD_UNIT!=value || _isLoaded){
                    _PROD_UNIT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_UNIT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UNIT_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string UNIT_NAME
        {
            get { return _UNIT_NAME; }
            set
            {
                if(_UNIT_NAME!=value || _isLoaded){
                    _UNIT_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UNIT_NAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_UNIT1;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_UNIT1
        {
            get { return _PROD_UNIT1; }
            set
            {
                if(_PROD_UNIT1!=value || _isLoaded){
                    _PROD_UNIT1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_UNIT1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UNIT_NAME1;
		/// <summary>
		/// 
		/// </summary>
        public string UNIT_NAME1
        {
            get { return _UNIT_NAME1; }
            set
            {
                if(_UNIT_NAME1!=value || _isLoaded){
                    _UNIT_NAME1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UNIT_NAME1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PROD_CONVERT1;
		/// <summary>
		/// 
		/// </summary>
        public int PROD_CONVERT1
        {
            get { return _PROD_CONVERT1; }
            set
            {
                if(_PROD_CONVERT1!=value || _isLoaded){
                    _PROD_CONVERT1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_CONVERT1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_UNIT2;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_UNIT2
        {
            get { return _PROD_UNIT2; }
            set
            {
                if(_PROD_UNIT2!=value || _isLoaded){
                    _PROD_UNIT2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_UNIT2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UNIT_NAME2;
		/// <summary>
		/// 
		/// </summary>
        public string UNIT_NAME2
        {
            get { return _UNIT_NAME2; }
            set
            {
                if(_UNIT_NAME2!=value || _isLoaded){
                    _UNIT_NAME2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UNIT_NAME2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PROD_CONVERT2;
		/// <summary>
		/// 
		/// </summary>
        public int PROD_CONVERT2
        {
            get { return _PROD_CONVERT2; }
            set
            {
                if(_PROD_CONVERT2!=value || _isLoaded){
                    _PROD_CONVERT2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_CONVERT2");
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

        string _SUP_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_NAME
        {
            get { return _SUP_NAME; }
            set
            {
                if(_SUP_NAME!=value || _isLoaded){
                    _SUP_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_NAME");
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

        string _Purchase_UNIT_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string Purchase_UNIT_NAME
        {
            get { return _Purchase_UNIT_NAME; }
            set
            {
                if(_Purchase_UNIT_NAME!=value || _isLoaded){
                    _Purchase_UNIT_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Purchase_UNIT_NAME");
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


        public static void Delete(Expression<Func<V_Product01_PRCAREA, bool>> expression) {
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

