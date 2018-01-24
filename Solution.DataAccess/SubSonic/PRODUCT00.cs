 
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
    /// A class which represents the PRODUCT00 table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class PRODUCT00: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PRODUCT00> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PRODUCT00>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PRODUCT00> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(PRODUCT00 item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PRODUCT00 item=new PRODUCT00();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PRODUCT00> _repo;
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
        public PRODUCT00(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PRODUCT00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PRODUCT00>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PRODUCT00(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            PROD_ID = readRecord.get_string("PROD_ID",null);
               
            PROD_NAME1 = readRecord.get_string("PROD_NAME1",null);
               
            PROD_NAME2 = readRecord.get_string("PROD_NAME2",null);
               
            PROD_KIND = readRecord.get_string("PROD_KIND",null);
               
            PROD_DEP = readRecord.get_string("PROD_DEP",null);
               
            PROD_CATE = readRecord.get_string("PROD_CATE",null);
               
            DIV_ID = readRecord.get_string("DIV_ID",null);
               
            PROD_TYPE = readRecord.get_byte("PROD_TYPE",null);
               
            PROD_Source = readRecord.get_int("PROD_Source",null);
               
            INV_TYPE = readRecord.get_int("INV_TYPE",null);
               
            STOCK_TYPE = readRecord.get_int("STOCK_TYPE",null);
               
            BOM_TYPE = readRecord.get_int("BOM_TYPE",null);
               
            MarginControl = readRecord.get_int("MarginControl",null);
               
            PROD_RangTYPE = readRecord.get_int("PROD_RangTYPE",null);
               
            PROD_iRang = readRecord.get_int("PROD_iRang",null);
               
            PROD_SPEC = readRecord.get_string("PROD_SPEC",null);
               
            PROD_Margin = readRecord.get_string("PROD_Margin",null);
               
            PROD_BARCODE = readRecord.get_string("PROD_BARCODE",null);
               
            PROD_UNIT = readRecord.get_string("PROD_UNIT",null);
               
            PROD_UNIT1 = readRecord.get_string("PROD_UNIT1",null);
               
            PROD_CONVERT1 = readRecord.get_int("PROD_CONVERT1",null);
               
            PROD_UNIT2 = readRecord.get_string("PROD_UNIT2",null);
               
            PROD_CONVERT2 = readRecord.get_int("PROD_CONVERT2",null);
               
            Report_UNIT = readRecord.get_int("Report_UNIT",null);
               
            IsBool1 = readRecord.get_byte("IsBool1",null);
               
            IsBool2 = readRecord.get_byte("IsBool2",null);
               
            IsBool3 = readRecord.get_bool("IsBool3",null);
               
            PROD_MEMO = readRecord.get_string("PROD_MEMO",null);
               
            CRT_DATETIME = readRecord.get_datetime("CRT_DATETIME",null);
               
            CRT_USER_ID = readRecord.get_string("CRT_USER_ID",null);
               
            MOD_DATETIME = readRecord.get_datetime("MOD_DATETIME",null);
               
            MOD_USER_ID = readRecord.get_string("MOD_USER_ID",null);
               
            LAST_UPDATE = readRecord.get_datetime("LAST_UPDATE",null);
               
            STATUS = readRecord.get_byte("STATUS",null);
               
            PROD_NAME1_SPELLING = readRecord.get_string("PROD_NAME1_SPELLING",null);
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

        public PRODUCT00(Expression<Func<PRODUCT00, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PRODUCT00> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<PRODUCT00> _repo;
            
            if(db.TestMode){
                PRODUCT00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PRODUCT00>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PRODUCT00> GetRepo(){
            return GetRepo("","");
        }
        
        public static PRODUCT00 SingleOrDefault(Expression<Func<PRODUCT00, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PRODUCT00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PRODUCT00 SingleOrDefault(Expression<Func<PRODUCT00, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PRODUCT00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PRODUCT00, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PRODUCT00, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PRODUCT00> Find(Expression<Func<PRODUCT00, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PRODUCT00> Find(Expression<Func<PRODUCT00, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PRODUCT00> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PRODUCT00> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PRODUCT00> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PRODUCT00> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PRODUCT00> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PRODUCT00> GetPaged(int pageIndex, int pageSize) {
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
                            return this.PROD_ID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PRODUCT00)){
                PRODUCT00 compare=(PRODUCT00)obj;
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
                            return this.PROD_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "PROD_ID";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "PROD_ID";
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

        string _PROD_NAME2;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_NAME2
        {
            get { return _PROD_NAME2; }
            set
            {
                if(_PROD_NAME2!=value || _isLoaded){
                    _PROD_NAME2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_NAME2");
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

        string _DIV_ID;
		/// <summary>
		/// 
		/// </summary>
        public string DIV_ID
        {
            get { return _DIV_ID; }
            set
            {
                if(_DIV_ID!=value || _isLoaded){
                    _DIV_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DIV_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _PROD_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public byte PROD_TYPE
        {
            get { return _PROD_TYPE; }
            set
            {
                if(_PROD_TYPE!=value || _isLoaded){
                    _PROD_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PROD_Source;
		/// <summary>
		/// 
		/// </summary>
        public int PROD_Source
        {
            get { return _PROD_Source; }
            set
            {
                if(_PROD_Source!=value || _isLoaded){
                    _PROD_Source=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_Source");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _INV_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public int INV_TYPE
        {
            get { return _INV_TYPE; }
            set
            {
                if(_INV_TYPE!=value || _isLoaded){
                    _INV_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="INV_TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _STOCK_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public int STOCK_TYPE
        {
            get { return _STOCK_TYPE; }
            set
            {
                if(_STOCK_TYPE!=value || _isLoaded){
                    _STOCK_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STOCK_TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _BOM_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public int BOM_TYPE
        {
            get { return _BOM_TYPE; }
            set
            {
                if(_BOM_TYPE!=value || _isLoaded){
                    _BOM_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BOM_TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _MarginControl;
		/// <summary>
		/// 
		/// </summary>
        public int MarginControl
        {
            get { return _MarginControl; }
            set
            {
                if(_MarginControl!=value || _isLoaded){
                    _MarginControl=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MarginControl");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PROD_RangTYPE;
		/// <summary>
		/// 
		/// </summary>
        public int PROD_RangTYPE
        {
            get { return _PROD_RangTYPE; }
            set
            {
                if(_PROD_RangTYPE!=value || _isLoaded){
                    _PROD_RangTYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_RangTYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PROD_iRang;
		/// <summary>
		/// 
		/// </summary>
        public int PROD_iRang
        {
            get { return _PROD_iRang; }
            set
            {
                if(_PROD_iRang!=value || _isLoaded){
                    _PROD_iRang=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_iRang");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_SPEC;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_SPEC
        {
            get { return _PROD_SPEC; }
            set
            {
                if(_PROD_SPEC!=value || _isLoaded){
                    _PROD_SPEC=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_SPEC");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_Margin;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_Margin
        {
            get { return _PROD_Margin; }
            set
            {
                if(_PROD_Margin!=value || _isLoaded){
                    _PROD_Margin=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_Margin");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_BARCODE;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_BARCODE
        {
            get { return _PROD_BARCODE; }
            set
            {
                if(_PROD_BARCODE!=value || _isLoaded){
                    _PROD_BARCODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_BARCODE");
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

        int _Report_UNIT;
		/// <summary>
		/// 
		/// </summary>
        public int Report_UNIT
        {
            get { return _Report_UNIT; }
            set
            {
                if(_Report_UNIT!=value || _isLoaded){
                    _Report_UNIT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Report_UNIT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _IsBool1;
		/// <summary>
		/// 
		/// </summary>
        public byte IsBool1
        {
            get { return _IsBool1; }
            set
            {
                if(_IsBool1!=value || _isLoaded){
                    _IsBool1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsBool1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _IsBool2;
		/// <summary>
		/// 
		/// </summary>
        public byte IsBool2
        {
            get { return _IsBool2; }
            set
            {
                if(_IsBool2!=value || _isLoaded){
                    _IsBool2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsBool2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _IsBool3;
		/// <summary>
		/// 
		/// </summary>
        public bool IsBool3
        {
            get { return _IsBool3; }
            set
            {
                if(_IsBool3!=value || _isLoaded){
                    _IsBool3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsBool3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PROD_MEMO;
		/// <summary>
		/// 
		/// </summary>
        public string PROD_MEMO
        {
            get { return _PROD_MEMO; }
            set
            {
                if(_PROD_MEMO!=value || _isLoaded){
                    _PROD_MEMO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PROD_MEMO");
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


        public static void Delete(Expression<Func<PRODUCT00, bool>> expression) {
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

