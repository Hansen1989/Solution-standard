 
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
    /// A class which represents the Purchase00 table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class Purchase00: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Purchase00> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Purchase00>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Purchase00> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Purchase00 item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Purchase00 item=new Purchase00();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Purchase00> _repo;
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
        public Purchase00(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Purchase00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Purchase00>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Purchase00(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            SHOP_ID = readRecord.get_string("SHOP_ID",null);
               
            Purchase_ID = readRecord.get_string("Purchase_ID",null);
               
            STATUS = readRecord.get_int("STATUS",null);
               
            PAY_STATUS = readRecord.get_int("PAY_STATUS",null);
               
            INPUT_DATE = readRecord.get_datetime("INPUT_DATE",null);
               
            SUP_ID = readRecord.get_string("SUP_ID",null);
               
            EXPECT_DATE = readRecord.get_datetime("EXPECT_DATE",null);
               
            USER_ID = readRecord.get_string("USER_ID",null);
               
            APP_USER = readRecord.get_string("APP_USER",null);
               
            APP_DATETIME = readRecord.get_datetime("APP_DATETIME",null);
               
            TOT_AMOUNT = readRecord.get_decimal("TOT_AMOUNT",null);
               
            TOT_TAX = readRecord.get_decimal("TOT_TAX",null);
               
            TOT_QTY = readRecord.get_decimal("TOT_QTY",null);
               
            PRE_PAY = readRecord.get_decimal("PRE_PAY",null);
               
            PRE_PAY_ID = readRecord.get_string("PRE_PAY_ID",null);
               
            EXPORTED = readRecord.get_byte("EXPORTED",null);
               
            EXPORTED_ID = readRecord.get_string("EXPORTED_ID",null);
               
            Memo = readRecord.get_string("Memo",null);
               
            LOCKED = readRecord.get_byte("LOCKED",null);
               
            CRT_DATETIME = readRecord.get_datetime("CRT_DATETIME",null);
               
            CRT_USER_ID = readRecord.get_string("CRT_USER_ID",null);
               
            MOD_DATETIME = readRecord.get_datetime("MOD_DATETIME",null);
               
            MOD_USER_ID = readRecord.get_string("MOD_USER_ID",null);
               
            LAST_UPDATE = readRecord.get_datetime("LAST_UPDATE",null);
               
            Trans_STATUS = readRecord.get_byte("Trans_STATUS",null);
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

        public Purchase00(Expression<Func<Purchase00, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Purchase00> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<Purchase00> _repo;
            
            if(db.TestMode){
                Purchase00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Purchase00>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Purchase00> GetRepo(){
            return GetRepo("","");
        }
        
        public static Purchase00 SingleOrDefault(Expression<Func<Purchase00, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Purchase00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Purchase00 SingleOrDefault(Expression<Func<Purchase00, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Purchase00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Purchase00, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Purchase00, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Purchase00> Find(Expression<Func<Purchase00, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Purchase00> Find(Expression<Func<Purchase00, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Purchase00> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Purchase00> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Purchase00> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Purchase00> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Purchase00> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Purchase00> GetPaged(int pageIndex, int pageSize) {
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
                            return this.SHOP_ID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Purchase00)){
                Purchase00 compare=(Purchase00)obj;
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

        string _Purchase_ID;
		/// <summary>
		/// 
		/// </summary>
        public string Purchase_ID
        {
            get { return _Purchase_ID; }
            set
            {
                if(_Purchase_ID!=value || _isLoaded){
                    _Purchase_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Purchase_ID");
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

        int _PAY_STATUS;
		/// <summary>
		/// 
		/// </summary>
        public int PAY_STATUS
        {
            get { return _PAY_STATUS; }
            set
            {
                if(_PAY_STATUS!=value || _isLoaded){
                    _PAY_STATUS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PAY_STATUS");
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

        DateTime _EXPECT_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime EXPECT_DATE
        {
            get { return _EXPECT_DATE; }
            set
            {
                if(_EXPECT_DATE!=value || _isLoaded){
                    _EXPECT_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXPECT_DATE");
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

        decimal _TOT_AMOUNT;
		/// <summary>
		/// 
		/// </summary>
        public decimal TOT_AMOUNT
        {
            get { return _TOT_AMOUNT; }
            set
            {
                if(_TOT_AMOUNT!=value || _isLoaded){
                    _TOT_AMOUNT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TOT_AMOUNT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _TOT_TAX;
		/// <summary>
		/// 
		/// </summary>
        public decimal TOT_TAX
        {
            get { return _TOT_TAX; }
            set
            {
                if(_TOT_TAX!=value || _isLoaded){
                    _TOT_TAX=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TOT_TAX");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _TOT_QTY;
		/// <summary>
		/// 
		/// </summary>
        public decimal TOT_QTY
        {
            get { return _TOT_QTY; }
            set
            {
                if(_TOT_QTY!=value || _isLoaded){
                    _TOT_QTY=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TOT_QTY");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _PRE_PAY;
		/// <summary>
		/// 
		/// </summary>
        public decimal PRE_PAY
        {
            get { return _PRE_PAY; }
            set
            {
                if(_PRE_PAY!=value || _isLoaded){
                    _PRE_PAY=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PRE_PAY");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PRE_PAY_ID;
		/// <summary>
		/// 
		/// </summary>
        public string PRE_PAY_ID
        {
            get { return _PRE_PAY_ID; }
            set
            {
                if(_PRE_PAY_ID!=value || _isLoaded){
                    _PRE_PAY_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PRE_PAY_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _EXPORTED;
		/// <summary>
		/// 
		/// </summary>
        public byte EXPORTED
        {
            get { return _EXPORTED; }
            set
            {
                if(_EXPORTED!=value || _isLoaded){
                    _EXPORTED=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXPORTED");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EXPORTED_ID;
		/// <summary>
		/// 
		/// </summary>
        public string EXPORTED_ID
        {
            get { return _EXPORTED_ID; }
            set
            {
                if(_EXPORTED_ID!=value || _isLoaded){
                    _EXPORTED_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXPORTED_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Memo;
		/// <summary>
		/// 
		/// </summary>
        public string Memo
        {
            get { return _Memo; }
            set
            {
                if(_Memo!=value || _isLoaded){
                    _Memo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Memo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _LOCKED;
		/// <summary>
		/// 
		/// </summary>
        public byte LOCKED
        {
            get { return _LOCKED; }
            set
            {
                if(_LOCKED!=value || _isLoaded){
                    _LOCKED=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LOCKED");
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

        byte _Trans_STATUS;
		/// <summary>
		/// 
		/// </summary>
        public byte Trans_STATUS
        {
            get { return _Trans_STATUS; }
            set
            {
                if(_Trans_STATUS!=value || _isLoaded){
                    _Trans_STATUS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Trans_STATUS");
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


        public static void Delete(Expression<Func<Purchase00, bool>> expression) {
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

