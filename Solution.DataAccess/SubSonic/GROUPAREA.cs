 
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
    /// A class which represents the GROUPAREA table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class GROUPAREA: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<GROUPAREA> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<GROUPAREA>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<GROUPAREA> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(GROUPAREA item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                GROUPAREA item=new GROUPAREA();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<GROUPAREA> _repo;
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
        public GROUPAREA(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                GROUPAREA.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<GROUPAREA>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public GROUPAREA(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            AREA_ID = readRecord.get_string("AREA_ID",null);
               
            AREA_NAME = readRecord.get_string("AREA_NAME",null);
               
            AREA_ADD = readRecord.get_string("AREA_ADD",null);
               
            AREA_TEL = readRecord.get_string("AREA_TEL",null);
               
            AREA_EMAIL = readRecord.get_string("AREA_EMAIL",null);
               
            AREA_CONTECT = readRecord.get_string("AREA_CONTECT",null);
               
            AREA_MEMO = readRecord.get_string("AREA_MEMO",null);
               
            AREA_STATUS = readRecord.get_byte("AREA_STATUS",null);
               
            CRT_DATETIME = readRecord.get_string("CRT_DATETIME",null);
               
            CRT_USER_ID = readRecord.get_string("CRT_USER_ID",null);
               
            MOD_DATETIME = readRecord.get_datetime("MOD_DATETIME",null);
               
            MOD_USER_ID = readRecord.get_string("MOD_USER_ID",null);
               
            LAST_UPDATE = readRecord.get_datetime("LAST_UPDATE",null);
               
            STATUS = readRecord.get_byte("STATUS",null);
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

        public GROUPAREA(Expression<Func<GROUPAREA, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<GROUPAREA> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<GROUPAREA> _repo;
            
            if(db.TestMode){
                GROUPAREA.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<GROUPAREA>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<GROUPAREA> GetRepo(){
            return GetRepo("","");
        }
        
        public static GROUPAREA SingleOrDefault(Expression<Func<GROUPAREA, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            GROUPAREA single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static GROUPAREA SingleOrDefault(Expression<Func<GROUPAREA, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            GROUPAREA single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<GROUPAREA, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<GROUPAREA, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<GROUPAREA> Find(Expression<Func<GROUPAREA, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<GROUPAREA> Find(Expression<Func<GROUPAREA, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<GROUPAREA> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<GROUPAREA> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<GROUPAREA> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<GROUPAREA> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<GROUPAREA> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<GROUPAREA> GetPaged(int pageIndex, int pageSize) {
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
                            return this.AREA_ID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(GROUPAREA)){
                GROUPAREA compare=(GROUPAREA)obj;
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
                            return this.AREA_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "AREA_ID";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "AREA_ID";
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

        string _AREA_ID;
		/// <summary>
		/// 
		/// </summary>
        public string AREA_ID
        {
            get { return _AREA_ID; }
            set
            {
                if(_AREA_ID!=value || _isLoaded){
                    _AREA_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AREA_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string AREA_NAME
        {
            get { return _AREA_NAME; }
            set
            {
                if(_AREA_NAME!=value || _isLoaded){
                    _AREA_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_NAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AREA_ADD;
		/// <summary>
		/// 
		/// </summary>
        public string AREA_ADD
        {
            get { return _AREA_ADD; }
            set
            {
                if(_AREA_ADD!=value || _isLoaded){
                    _AREA_ADD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_ADD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AREA_TEL;
		/// <summary>
		/// 
		/// </summary>
        public string AREA_TEL
        {
            get { return _AREA_TEL; }
            set
            {
                if(_AREA_TEL!=value || _isLoaded){
                    _AREA_TEL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_TEL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AREA_EMAIL;
		/// <summary>
		/// 
		/// </summary>
        public string AREA_EMAIL
        {
            get { return _AREA_EMAIL; }
            set
            {
                if(_AREA_EMAIL!=value || _isLoaded){
                    _AREA_EMAIL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_EMAIL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AREA_CONTECT;
		/// <summary>
		/// 
		/// </summary>
        public string AREA_CONTECT
        {
            get { return _AREA_CONTECT; }
            set
            {
                if(_AREA_CONTECT!=value || _isLoaded){
                    _AREA_CONTECT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_CONTECT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _AREA_MEMO;
		/// <summary>
		/// 
		/// </summary>
        public string AREA_MEMO
        {
            get { return _AREA_MEMO; }
            set
            {
                if(_AREA_MEMO!=value || _isLoaded){
                    _AREA_MEMO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_MEMO");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _AREA_STATUS;
		/// <summary>
		/// 
		/// </summary>
        public byte AREA_STATUS
        {
            get { return _AREA_STATUS; }
            set
            {
                if(_AREA_STATUS!=value || _isLoaded){
                    _AREA_STATUS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AREA_STATUS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CRT_DATETIME;
		/// <summary>
		/// 
		/// </summary>
        public string CRT_DATETIME
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


        public static void Delete(Expression<Func<GROUPAREA, bool>> expression) {
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

