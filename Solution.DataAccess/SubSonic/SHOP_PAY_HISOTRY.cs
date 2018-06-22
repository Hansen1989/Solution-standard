 
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
    /// A class which represents the SHOP_PAY_HISOTRY table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class SHOP_PAY_HISOTRY: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<SHOP_PAY_HISOTRY> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<SHOP_PAY_HISOTRY>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<SHOP_PAY_HISOTRY> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(SHOP_PAY_HISOTRY item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                SHOP_PAY_HISOTRY item=new SHOP_PAY_HISOTRY();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<SHOP_PAY_HISOTRY> _repo;
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
        public SHOP_PAY_HISOTRY(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                SHOP_PAY_HISOTRY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SHOP_PAY_HISOTRY>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public SHOP_PAY_HISOTRY(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            SHOP_ID = readRecord.get_string("SHOP_ID",null);
               
            Head_SHOP_ID = readRecord.get_string("Head_SHOP_ID",null);
               
            BILL_ID = readRecord.get_long("BILL_ID",null);
               
            AMOUNT = readRecord.get_string("AMOUNT",null);
               
            PAY_DATE = readRecord.get_datetime("PAY_DATE",null);
               
            PAYER = readRecord.get_string("PAYER",null);
               
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

        public SHOP_PAY_HISOTRY(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<SHOP_PAY_HISOTRY> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<SHOP_PAY_HISOTRY> _repo;
            
            if(db.TestMode){
                SHOP_PAY_HISOTRY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SHOP_PAY_HISOTRY>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<SHOP_PAY_HISOTRY> GetRepo(){
            return GetRepo("","");
        }
        
        public static SHOP_PAY_HISOTRY SingleOrDefault(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            SHOP_PAY_HISOTRY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static SHOP_PAY_HISOTRY SingleOrDefault(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            SHOP_PAY_HISOTRY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<SHOP_PAY_HISOTRY> Find(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<SHOP_PAY_HISOTRY> Find(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<SHOP_PAY_HISOTRY> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<SHOP_PAY_HISOTRY> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<SHOP_PAY_HISOTRY> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<SHOP_PAY_HISOTRY> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<SHOP_PAY_HISOTRY> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<SHOP_PAY_HISOTRY> GetPaged(int pageIndex, int pageSize) {
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
            if(obj.GetType()==typeof(SHOP_PAY_HISOTRY)){
                SHOP_PAY_HISOTRY compare=(SHOP_PAY_HISOTRY)obj;
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

        string _Head_SHOP_ID;
		/// <summary>
		/// 
		/// </summary>
        public string Head_SHOP_ID
        {
            get { return _Head_SHOP_ID; }
            set
            {
                if(_Head_SHOP_ID!=value || _isLoaded){
                    _Head_SHOP_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Head_SHOP_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        long _BILL_ID;
		/// <summary>
		/// 
		/// </summary>
        public long BILL_ID
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

        string _AMOUNT;
		/// <summary>
		/// 
		/// </summary>
        public string AMOUNT
        {
            get { return _AMOUNT; }
            set
            {
                if(_AMOUNT!=value || _isLoaded){
                    _AMOUNT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AMOUNT");
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

        string _PAYER;
		/// <summary>
		/// 
		/// </summary>
        public string PAYER
        {
            get { return _PAYER; }
            set
            {
                if(_PAYER!=value || _isLoaded){
                    _PAYER=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PAYER");
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


        public static void Delete(Expression<Func<SHOP_PAY_HISOTRY, bool>> expression) {
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

