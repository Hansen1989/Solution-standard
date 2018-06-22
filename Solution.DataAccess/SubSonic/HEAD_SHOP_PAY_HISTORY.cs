 
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
    /// A class which represents the HEAD_SHOP_PAY_HISTORY table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class HEAD_SHOP_PAY_HISTORY: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<HEAD_SHOP_PAY_HISTORY> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<HEAD_SHOP_PAY_HISTORY>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<HEAD_SHOP_PAY_HISTORY> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(HEAD_SHOP_PAY_HISTORY item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                HEAD_SHOP_PAY_HISTORY item=new HEAD_SHOP_PAY_HISTORY();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<HEAD_SHOP_PAY_HISTORY> _repo;
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
        public HEAD_SHOP_PAY_HISTORY(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                HEAD_SHOP_PAY_HISTORY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<HEAD_SHOP_PAY_HISTORY>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public HEAD_SHOP_PAY_HISTORY(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            SHOP_ID = readRecord.get_string("SHOP_ID",null);
               
            BILL_AMOUNT = readRecord.get_decimal("BILL_AMOUNT",null);
               
            SUP_ID = readRecord.get_string("SUP_ID",null);
               
            BILL_ID = readRecord.get_string("BILL_ID",null);
               
            PAY_AMOUNT = readRecord.get_decimal("PAY_AMOUNT",null);
               
            PAY_METHOD = readRecord.get_byte("PAY_METHOD",null);
               
            BILL_DATE = readRecord.get_datetime("BILL_DATE",null);
               
            PAY_DATE = readRecord.get_datetime("PAY_DATE",null);
               
            Memo = readRecord.get_string("Memo",null);
               
            CRT_DATETIME = readRecord.get_datetime("CRT_DATETIME",null);
               
            CRT_USER_ID = readRecord.get_string("CRT_USER_ID",null);
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

        public HEAD_SHOP_PAY_HISTORY(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<HEAD_SHOP_PAY_HISTORY> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<HEAD_SHOP_PAY_HISTORY> _repo;
            
            if(db.TestMode){
                HEAD_SHOP_PAY_HISTORY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<HEAD_SHOP_PAY_HISTORY>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<HEAD_SHOP_PAY_HISTORY> GetRepo(){
            return GetRepo("","");
        }
        
        public static HEAD_SHOP_PAY_HISTORY SingleOrDefault(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            HEAD_SHOP_PAY_HISTORY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static HEAD_SHOP_PAY_HISTORY SingleOrDefault(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            HEAD_SHOP_PAY_HISTORY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<HEAD_SHOP_PAY_HISTORY> Find(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<HEAD_SHOP_PAY_HISTORY> Find(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<HEAD_SHOP_PAY_HISTORY> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<HEAD_SHOP_PAY_HISTORY> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<HEAD_SHOP_PAY_HISTORY> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<HEAD_SHOP_PAY_HISTORY> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<HEAD_SHOP_PAY_HISTORY> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<HEAD_SHOP_PAY_HISTORY> GetPaged(int pageIndex, int pageSize) {
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
            if(obj.GetType()==typeof(HEAD_SHOP_PAY_HISTORY)){
                HEAD_SHOP_PAY_HISTORY compare=(HEAD_SHOP_PAY_HISTORY)obj;
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

        decimal _PAY_AMOUNT;
		/// <summary>
		/// 
		/// </summary>
        public decimal PAY_AMOUNT
        {
            get { return _PAY_AMOUNT; }
            set
            {
                if(_PAY_AMOUNT!=value || _isLoaded){
                    _PAY_AMOUNT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PAY_AMOUNT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _PAY_METHOD;
		/// <summary>
		/// 
		/// </summary>
        public byte PAY_METHOD
        {
            get { return _PAY_METHOD; }
            set
            {
                if(_PAY_METHOD!=value || _isLoaded){
                    _PAY_METHOD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PAY_METHOD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _BILL_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime BILL_DATE
        {
            get { return _BILL_DATE; }
            set
            {
                if(_BILL_DATE!=value || _isLoaded){
                    _BILL_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BILL_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _PAY_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime PAY_DATE
        {
            get { return _PAY_DATE; }
            set
            {
                if(_PAY_DATE!=value || _isLoaded){
                    _PAY_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PAY_DATE");
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


        public static void Delete(Expression<Func<HEAD_SHOP_PAY_HISTORY, bool>> expression) {
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

