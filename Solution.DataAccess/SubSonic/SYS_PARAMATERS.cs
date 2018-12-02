 
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
    /// A class which represents the SYS_PARAMATERS table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class SYS_PARAMATERS: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<SYS_PARAMATERS> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<SYS_PARAMATERS>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<SYS_PARAMATERS> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(SYS_PARAMATERS item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                SYS_PARAMATERS item=new SYS_PARAMATERS();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<SYS_PARAMATERS> _repo;
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
        public SYS_PARAMATERS(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                SYS_PARAMATERS.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SYS_PARAMATERS>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public SYS_PARAMATERS(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            Code = readRecord.get_string("Code",null);
               
            VALUE = readRecord.get_string("VALUE",null);
               
            KEY_CN = readRecord.get_string("KEY_CN",null);
               
            MEMO = readRecord.get_string("MEMO",null);
               
            Area_Id = readRecord.get_string("Area_Id",null);
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

        public SYS_PARAMATERS(Expression<Func<SYS_PARAMATERS, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<SYS_PARAMATERS> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<SYS_PARAMATERS> _repo;
            
            if(db.TestMode){
                SYS_PARAMATERS.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SYS_PARAMATERS>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<SYS_PARAMATERS> GetRepo(){
            return GetRepo("","");
        }
        
        public static SYS_PARAMATERS SingleOrDefault(Expression<Func<SYS_PARAMATERS, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            SYS_PARAMATERS single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static SYS_PARAMATERS SingleOrDefault(Expression<Func<SYS_PARAMATERS, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            SYS_PARAMATERS single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<SYS_PARAMATERS, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<SYS_PARAMATERS, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<SYS_PARAMATERS> Find(Expression<Func<SYS_PARAMATERS, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<SYS_PARAMATERS> Find(Expression<Func<SYS_PARAMATERS, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<SYS_PARAMATERS> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<SYS_PARAMATERS> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<SYS_PARAMATERS> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<SYS_PARAMATERS> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<SYS_PARAMATERS> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<SYS_PARAMATERS> GetPaged(int pageIndex, int pageSize) {
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
                            return this.Code.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(SYS_PARAMATERS)){
                SYS_PARAMATERS compare=(SYS_PARAMATERS)obj;
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
                            return this.Code.ToString();
                    }

        public string DescriptorColumn() {
            return "Code";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Code";
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

        string _Code;
		/// <summary>
		/// 
		/// </summary>
        public string Code
        {
            get { return _Code; }
            set
            {
                if(_Code!=value || _isLoaded){
                    _Code=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Code");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _VALUE;
		/// <summary>
		/// 
		/// </summary>
        public string VALUE
        {
            get { return _VALUE; }
            set
            {
                if(_VALUE!=value || _isLoaded){
                    _VALUE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="VALUE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _KEY_CN;
		/// <summary>
		/// 
		/// </summary>
        public string KEY_CN
        {
            get { return _KEY_CN; }
            set
            {
                if(_KEY_CN!=value || _isLoaded){
                    _KEY_CN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="KEY_CN");
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

        string _Area_Id;
		/// <summary>
		/// 
		/// </summary>
        public string Area_Id
        {
            get { return _Area_Id; }
            set
            {
                if(_Area_Id!=value || _isLoaded){
                    _Area_Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Area_Id");
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


        public static void Delete(Expression<Func<SYS_PARAMATERS, bool>> expression) {
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

