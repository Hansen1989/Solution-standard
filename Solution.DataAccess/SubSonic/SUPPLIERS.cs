 
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
    /// A class which represents the SUPPLIERS table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class SUPPLIERS: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<SUPPLIERS> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<SUPPLIERS>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<SUPPLIERS> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(SUPPLIERS item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                SUPPLIERS item=new SUPPLIERS();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<SUPPLIERS> _repo;
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
        public SUPPLIERS(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                SUPPLIERS.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SUPPLIERS>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public SUPPLIERS(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            SUP_ID = readRecord.get_string("SUP_ID",null);
               
            SUP_NAME = readRecord.get_string("SUP_NAME",null);
               
            SUP_NICKNAME = readRecord.get_string("SUP_NICKNAME",null);
               
            SUP_TYPE = readRecord.get_int("SUP_TYPE",null);
               
            SUP_ADD = readRecord.get_string("SUP_ADD",null);
               
            SUP_TEL = readRecord.get_string("SUP_TEL",null);
               
            SUP_Email = readRecord.get_string("SUP_Email",null);
               
            SUP_ZIP = readRecord.get_string("SUP_ZIP",null);
               
            SUP_Contact = readRecord.get_string("SUP_Contact",null);
               
            SUP_Mobile = readRecord.get_string("SUP_Mobile",null);
               
            SUP_CODE_ID = readRecord.get_string("SUP_CODE_ID",null);
               
            SUP_BankName = readRecord.get_string("SUP_BankName",null);
               
            SUP_BankID = readRecord.get_string("SUP_BankID",null);
               
            SUP_PASSWORD = readRecord.get_string("SUP_PASSWORD",null);
               
            Send_DAY = readRecord.get_int("Send_DAY",null);
               
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

        public SUPPLIERS(Expression<Func<SUPPLIERS, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<SUPPLIERS> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<SUPPLIERS> _repo;
            
            if(db.TestMode){
                SUPPLIERS.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SUPPLIERS>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<SUPPLIERS> GetRepo(){
            return GetRepo("","");
        }
        
        public static SUPPLIERS SingleOrDefault(Expression<Func<SUPPLIERS, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            SUPPLIERS single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static SUPPLIERS SingleOrDefault(Expression<Func<SUPPLIERS, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            SUPPLIERS single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<SUPPLIERS, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<SUPPLIERS, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<SUPPLIERS> Find(Expression<Func<SUPPLIERS, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<SUPPLIERS> Find(Expression<Func<SUPPLIERS, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<SUPPLIERS> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<SUPPLIERS> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<SUPPLIERS> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<SUPPLIERS> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<SUPPLIERS> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<SUPPLIERS> GetPaged(int pageIndex, int pageSize) {
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
                            return this.SUP_ID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(SUPPLIERS)){
                SUPPLIERS compare=(SUPPLIERS)obj;
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
                            return this.SUP_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "SUP_ID";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "SUP_ID";
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

        string _SUP_NICKNAME;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_NICKNAME
        {
            get { return _SUP_NICKNAME; }
            set
            {
                if(_SUP_NICKNAME!=value || _isLoaded){
                    _SUP_NICKNAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_NICKNAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SUP_TYPE;
		/// <summary>
		/// 
		/// </summary>
        public int SUP_TYPE
        {
            get { return _SUP_TYPE; }
            set
            {
                if(_SUP_TYPE!=value || _isLoaded){
                    _SUP_TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_ADD;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_ADD
        {
            get { return _SUP_ADD; }
            set
            {
                if(_SUP_ADD!=value || _isLoaded){
                    _SUP_ADD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_ADD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_TEL;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_TEL
        {
            get { return _SUP_TEL; }
            set
            {
                if(_SUP_TEL!=value || _isLoaded){
                    _SUP_TEL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_TEL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_Email;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_Email
        {
            get { return _SUP_Email; }
            set
            {
                if(_SUP_Email!=value || _isLoaded){
                    _SUP_Email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_Email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_ZIP;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_ZIP
        {
            get { return _SUP_ZIP; }
            set
            {
                if(_SUP_ZIP!=value || _isLoaded){
                    _SUP_ZIP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_ZIP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_Contact;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_Contact
        {
            get { return _SUP_Contact; }
            set
            {
                if(_SUP_Contact!=value || _isLoaded){
                    _SUP_Contact=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_Contact");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_Mobile;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_Mobile
        {
            get { return _SUP_Mobile; }
            set
            {
                if(_SUP_Mobile!=value || _isLoaded){
                    _SUP_Mobile=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_Mobile");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_CODE_ID;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_CODE_ID
        {
            get { return _SUP_CODE_ID; }
            set
            {
                if(_SUP_CODE_ID!=value || _isLoaded){
                    _SUP_CODE_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_CODE_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_BankName;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_BankName
        {
            get { return _SUP_BankName; }
            set
            {
                if(_SUP_BankName!=value || _isLoaded){
                    _SUP_BankName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_BankName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_BankID;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_BankID
        {
            get { return _SUP_BankID; }
            set
            {
                if(_SUP_BankID!=value || _isLoaded){
                    _SUP_BankID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_BankID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SUP_PASSWORD;
		/// <summary>
		/// 
		/// </summary>
        public string SUP_PASSWORD
        {
            get { return _SUP_PASSWORD; }
            set
            {
                if(_SUP_PASSWORD!=value || _isLoaded){
                    _SUP_PASSWORD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SUP_PASSWORD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Send_DAY;
		/// <summary>
		/// 
		/// </summary>
        public int Send_DAY
        {
            get { return _Send_DAY; }
            set
            {
                if(_Send_DAY!=value || _isLoaded){
                    _Send_DAY=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Send_DAY");
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


        public static void Delete(Expression<Func<SUPPLIERS, bool>> expression) {
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

