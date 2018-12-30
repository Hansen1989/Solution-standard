 
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
    /// A class which represents the RECEIVABLES00 table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class RECEIVABLES00: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<RECEIVABLES00> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<RECEIVABLES00>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<RECEIVABLES00> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(RECEIVABLES00 item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                RECEIVABLES00 item=new RECEIVABLES00();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<RECEIVABLES00> _repo;
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
        public RECEIVABLES00(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                RECEIVABLES00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RECEIVABLES00>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public RECEIVABLES00(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_long("Id",null);
               
            SHOP_ID = readRecord.get_string("SHOP_ID",null);
               
            BILL_ID = readRecord.get_string("BILL_ID",null);
               
            STATUS = readRecord.get_int("STATUS",null);
               
            INPUT_DATE = readRecord.get_datetime("INPUT_DATE",null);
               
            IN_SHOP = readRecord.get_string("IN_SHOP",null);
               
            USER_ID = readRecord.get_string("USER_ID",null);
               
            APP_USER = readRecord.get_string("APP_USER",null);
               
            APP_DATETIME = readRecord.get_datetime("APP_DATETIME",null);
               
            MEMO = readRecord.get_string("MEMO",null);
               
            CRT_DATETIME = readRecord.get_datetime("CRT_DATETIME",null);
               
            CRT_USER_ID = readRecord.get_string("CRT_USER_ID",null);
               
            MOD_DATETIME = readRecord.get_datetime("MOD_DATETIME",null);
               
            MOD_USER_ID = readRecord.get_string("MOD_USER_ID",null);
               
            LAST_UPDATE = readRecord.get_datetime("LAST_UPDATE",null);
               
            BILL_AMOUNT = readRecord.get_decimal("BILL_AMOUNT",null);
               
            BILL_COST = readRecord.get_decimal("BILL_COST",null);
               
            BILL_TYPE = readRecord.get_int("BILL_TYPE",null);
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

        public RECEIVABLES00(Expression<Func<RECEIVABLES00, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<RECEIVABLES00> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<RECEIVABLES00> _repo;
            
            if(db.TestMode){
                RECEIVABLES00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RECEIVABLES00>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<RECEIVABLES00> GetRepo(){
            return GetRepo("","");
        }
        
        public static RECEIVABLES00 SingleOrDefault(Expression<Func<RECEIVABLES00, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            RECEIVABLES00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static RECEIVABLES00 SingleOrDefault(Expression<Func<RECEIVABLES00, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            RECEIVABLES00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<RECEIVABLES00, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<RECEIVABLES00, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<RECEIVABLES00> Find(Expression<Func<RECEIVABLES00, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<RECEIVABLES00> Find(Expression<Func<RECEIVABLES00, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<RECEIVABLES00> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<RECEIVABLES00> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<RECEIVABLES00> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<RECEIVABLES00> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<RECEIVABLES00> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<RECEIVABLES00> GetPaged(int pageIndex, int pageSize) {
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
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.SHOP_ID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(RECEIVABLES00)){
                RECEIVABLES00 compare=(RECEIVABLES00)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.SHOP_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "SHOP_ID";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "SHOP_ID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        long _Id;
		/// <summary>
		/// 
		/// </summary>
        public long Id
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

        string _SHOP_ID;
		/// <summary>
		/// 
		/// </summary>
        public string SHOP_ID
        {
            get { return _SHOP_ID; }
            set
            {
                if(_SHOP_ID!=value || _isLoaded){
                    _SHOP_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SHOP_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _BILL_ID;
		/// <summary>
		/// 
		/// </summary>
        public string BILL_ID
        {
            get { return _BILL_ID; }
            set
            {
                if(_BILL_ID!=value || _isLoaded){
                    _BILL_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BILL_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _STATUS;
		/// <summary>
		/// 
		/// </summary>
        public int STATUS
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

        DateTime _INPUT_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime INPUT_DATE
        {
            get { return _INPUT_DATE; }
            set
            {
                if(_INPUT_DATE!=value || _isLoaded){
                    _INPUT_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="INPUT_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IN_SHOP;
		/// <summary>
		/// 
		/// </summary>
        public string IN_SHOP
        {
            get { return _IN_SHOP; }
            set
            {
                if(_IN_SHOP!=value || _isLoaded){
                    _IN_SHOP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IN_SHOP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _USER_ID;
		/// <summary>
		/// 
		/// </summary>
        public string USER_ID
        {
            get { return _USER_ID; }
            set
            {
                if(_USER_ID!=value || _isLoaded){
                    _USER_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="USER_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _APP_USER;
		/// <summary>
		/// 
		/// </summary>
        public string APP_USER
        {
            get { return _APP_USER; }
            set
            {
                if(_APP_USER!=value || _isLoaded){
                    _APP_USER=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="APP_USER");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _APP_DATETIME;
		/// <summary>
		/// 
		/// </summary>
        public DateTime APP_DATETIME
        {
            get { return _APP_DATETIME; }
            set
            {
                if(_APP_DATETIME!=value || _isLoaded){
                    _APP_DATETIME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="APP_DATETIME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MEMO;
		/// <summary>
		/// 
		/// </summary>
        public string MEMO
        {
            get { return _MEMO; }
            set
            {
                if(_MEMO!=value || _isLoaded){
                    _MEMO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MEMO");
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

        decimal _BILL_AMOUNT;
		/// <summary>
		/// 
		/// </summary>
        public decimal BILL_AMOUNT
        {
            get { return _BILL_AMOUNT; }
            set
            {
                if(_BILL_AMOUNT!=value || _isLoaded){
                    _BILL_AMOUNT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BILL_AMOUNT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _BILL_COST;
		/// <summary>
		/// 
		/// </summary>
        public decimal BILL_COST
        {
            get { return _BILL_COST; }
            set
            {
                if(_BILL_COST!=value || _isLoaded){
                    _BILL_COST=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BILL_COST");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _BILL_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public int BILL_TYPE
        {
            get { return _BILL_TYPE; }
            set
            {
                if(_BILL_TYPE!=value || _isLoaded){
                    _BILL_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BILL_TYPE");
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


        public static void Delete(Expression<Func<RECEIVABLES00, bool>> expression) {
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

