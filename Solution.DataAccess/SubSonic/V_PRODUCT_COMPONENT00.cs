 
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
    /// A class which represents the V_PRODUCT_COMPONENT00 table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class V_PRODUCT_COMPONENT00: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<V_PRODUCT_COMPONENT00> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<V_PRODUCT_COMPONENT00>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<V_PRODUCT_COMPONENT00> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(V_PRODUCT_COMPONENT00 item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                V_PRODUCT_COMPONENT00 item=new V_PRODUCT_COMPONENT00();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<V_PRODUCT_COMPONENT00> _repo;
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
        public V_PRODUCT_COMPONENT00(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                V_PRODUCT_COMPONENT00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<V_PRODUCT_COMPONENT00>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public V_PRODUCT_COMPONENT00(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            COM00_ID = readRecord.get_string("COM00_ID",null);
               
            COM00_PROD_ID = readRecord.get_string("COM00_PROD_ID",null);
               
            COM00_NAME1 = readRecord.get_string("COM00_NAME1",null);
               
            COM00_NUM = readRecord.get_int("COM00_NUM",null);
               
            COM00_WEIGHT = readRecord.get_decimal("COM00_WEIGHT",null);
               
            COM00_DEFAULTCOM = readRecord.get_byte("COM00_DEFAULTCOM",null);
               
            COM00_QUAN1 = readRecord.get_int("COM00_QUAN1",null);
               
            COM00_QUAN2 = readRecord.get_int("COM00_QUAN2",null);
               
            COM00_DefQuan = readRecord.get_int("COM00_DefQuan",null);
               
            COM00_BOM_Cost = readRecord.get_decimal("COM00_BOM_Cost",null);
               
            COM00_ExpDateTime = readRecord.get_string("COM00_ExpDateTime",null);
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

        public V_PRODUCT_COMPONENT00(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<V_PRODUCT_COMPONENT00> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<V_PRODUCT_COMPONENT00> _repo;
            
            if(db.TestMode){
                V_PRODUCT_COMPONENT00.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<V_PRODUCT_COMPONENT00>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<V_PRODUCT_COMPONENT00> GetRepo(){
            return GetRepo("","");
        }
        
        public static V_PRODUCT_COMPONENT00 SingleOrDefault(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            V_PRODUCT_COMPONENT00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static V_PRODUCT_COMPONENT00 SingleOrDefault(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            V_PRODUCT_COMPONENT00 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<V_PRODUCT_COMPONENT00> Find(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<V_PRODUCT_COMPONENT00> Find(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<V_PRODUCT_COMPONENT00> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<V_PRODUCT_COMPONENT00> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<V_PRODUCT_COMPONENT00> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<V_PRODUCT_COMPONENT00> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<V_PRODUCT_COMPONENT00> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<V_PRODUCT_COMPONENT00> GetPaged(int pageIndex, int pageSize) {
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
                            return this.COM00_ID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(V_PRODUCT_COMPONENT00)){
                V_PRODUCT_COMPONENT00 compare=(V_PRODUCT_COMPONENT00)obj;
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
                            return this.COM00_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "COM00_ID";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "COM00_ID";
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

        string _COM00_ID;
		/// <summary>
		/// 
		/// </summary>
        public string COM00_ID
        {
            get { return _COM00_ID; }
            set
            {
                if(_COM00_ID!=value || _isLoaded){
                    _COM00_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _COM00_PROD_ID;
		/// <summary>
		/// 
		/// </summary>
        public string COM00_PROD_ID
        {
            get { return _COM00_PROD_ID; }
            set
            {
                if(_COM00_PROD_ID!=value || _isLoaded){
                    _COM00_PROD_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_PROD_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _COM00_NAME1;
		/// <summary>
		/// 
		/// </summary>
        public string COM00_NAME1
        {
            get { return _COM00_NAME1; }
            set
            {
                if(_COM00_NAME1!=value || _isLoaded){
                    _COM00_NAME1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_NAME1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _COM00_NUM;
		/// <summary>
		/// 
		/// </summary>
        public int COM00_NUM
        {
            get { return _COM00_NUM; }
            set
            {
                if(_COM00_NUM!=value || _isLoaded){
                    _COM00_NUM=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_NUM");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _COM00_WEIGHT;
		/// <summary>
		/// 
		/// </summary>
        public decimal COM00_WEIGHT
        {
            get { return _COM00_WEIGHT; }
            set
            {
                if(_COM00_WEIGHT!=value || _isLoaded){
                    _COM00_WEIGHT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_WEIGHT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _COM00_DEFAULTCOM;
		/// <summary>
		/// 
		/// </summary>
        public byte COM00_DEFAULTCOM
        {
            get { return _COM00_DEFAULTCOM; }
            set
            {
                if(_COM00_DEFAULTCOM!=value || _isLoaded){
                    _COM00_DEFAULTCOM=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_DEFAULTCOM");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _COM00_QUAN1;
		/// <summary>
		/// 
		/// </summary>
        public int COM00_QUAN1
        {
            get { return _COM00_QUAN1; }
            set
            {
                if(_COM00_QUAN1!=value || _isLoaded){
                    _COM00_QUAN1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_QUAN1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _COM00_QUAN2;
		/// <summary>
		/// 
		/// </summary>
        public int COM00_QUAN2
        {
            get { return _COM00_QUAN2; }
            set
            {
                if(_COM00_QUAN2!=value || _isLoaded){
                    _COM00_QUAN2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_QUAN2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _COM00_DefQuan;
		/// <summary>
		/// 
		/// </summary>
        public int COM00_DefQuan
        {
            get { return _COM00_DefQuan; }
            set
            {
                if(_COM00_DefQuan!=value || _isLoaded){
                    _COM00_DefQuan=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_DefQuan");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _COM00_BOM_Cost;
		/// <summary>
		/// 
		/// </summary>
        public decimal COM00_BOM_Cost
        {
            get { return _COM00_BOM_Cost; }
            set
            {
                if(_COM00_BOM_Cost!=value || _isLoaded){
                    _COM00_BOM_Cost=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_BOM_Cost");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _COM00_ExpDateTime;
		/// <summary>
		/// 
		/// </summary>
        public string COM00_ExpDateTime
        {
            get { return _COM00_ExpDateTime; }
            set
            {
                if(_COM00_ExpDateTime!=value || _isLoaded){
                    _COM00_ExpDateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="COM00_ExpDateTime");
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


        public static void Delete(Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression) {
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

