 
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
    /// A class which represents the IN01 table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class IN01: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<IN01> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<IN01>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<IN01> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(IN01 item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                IN01 item=new IN01();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<IN01> _repo;
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
        public IN01(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                IN01.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<IN01>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public IN01(){
			_db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            SHOP_ID = readRecord.get_string("SHOP_ID",null);
               
            IN_ID = readRecord.get_string("IN_ID",null);
               
            SNo = readRecord.get_int("SNo",null);
               
            PROD_ID = readRecord.get_string("PROD_ID",null);
               
            QUANTITY = readRecord.get_decimal("QUANTITY",null);
               
            STD_UNIT = readRecord.get_string("STD_UNIT",null);
               
            STD_CONVERT = readRecord.get_int("STD_CONVERT",null);
               
            STD_QUAN = readRecord.get_decimal("STD_QUAN",null);
               
            STD_PRICE = readRecord.get_decimal("STD_PRICE",null);
               
            COST = readRecord.get_decimal("COST",null);
               
            QUAN1 = readRecord.get_decimal("QUAN1",null);
               
            QUAN2 = readRecord.get_decimal("QUAN2",null);
               
            MEMO = readRecord.get_string("MEMO",null);
               
            BAT_NO = readRecord.get_string("BAT_NO",null);
               
            Exp_DateTime = readRecord.get_datetime("Exp_DateTime",null);
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

        public IN01(Expression<Func<IN01, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<IN01> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<IN01> _repo;
            
            if(db.TestMode){
                IN01.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<IN01>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<IN01> GetRepo(){
            return GetRepo("","");
        }
        
        public static IN01 SingleOrDefault(Expression<Func<IN01, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            IN01 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static IN01 SingleOrDefault(Expression<Func<IN01, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            IN01 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<IN01, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<IN01, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<IN01> Find(Expression<Func<IN01, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<IN01> Find(Expression<Func<IN01, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<IN01> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<IN01> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<IN01> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<IN01> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<IN01> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<IN01> GetPaged(int pageIndex, int pageSize) {
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
            if(obj.GetType()==typeof(IN01)){
                IN01 compare=(IN01)obj;
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

        string _IN_ID;
		/// <summary>
		/// 
		/// </summary>
        public string IN_ID
        {
            get { return _IN_ID; }
            set
            {
                if(_IN_ID!=value || _isLoaded){
                    _IN_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IN_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SNo;
		/// <summary>
		/// 
		/// </summary>
        public int SNo
        {
            get { return _SNo; }
            set
            {
                if(_SNo!=value || _isLoaded){
                    _SNo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SNo");
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

        decimal _QUANTITY;
		/// <summary>
		/// 
		/// </summary>
        public decimal QUANTITY
        {
            get { return _QUANTITY; }
            set
            {
                if(_QUANTITY!=value || _isLoaded){
                    _QUANTITY=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QUANTITY");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _STD_UNIT;
		/// <summary>
		/// 
		/// </summary>
        public string STD_UNIT
        {
            get { return _STD_UNIT; }
            set
            {
                if(_STD_UNIT!=value || _isLoaded){
                    _STD_UNIT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STD_UNIT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _STD_CONVERT;
		/// <summary>
		/// 
		/// </summary>
        public int STD_CONVERT
        {
            get { return _STD_CONVERT; }
            set
            {
                if(_STD_CONVERT!=value || _isLoaded){
                    _STD_CONVERT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STD_CONVERT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _STD_QUAN;
		/// <summary>
		/// 
		/// </summary>
        public decimal STD_QUAN
        {
            get { return _STD_QUAN; }
            set
            {
                if(_STD_QUAN!=value || _isLoaded){
                    _STD_QUAN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STD_QUAN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _STD_PRICE;
		/// <summary>
		/// 
		/// </summary>
        public decimal STD_PRICE
        {
            get { return _STD_PRICE; }
            set
            {
                if(_STD_PRICE!=value || _isLoaded){
                    _STD_PRICE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STD_PRICE");
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

        decimal _QUAN1;
		/// <summary>
		/// 
		/// </summary>
        public decimal QUAN1
        {
            get { return _QUAN1; }
            set
            {
                if(_QUAN1!=value || _isLoaded){
                    _QUAN1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QUAN1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _QUAN2;
		/// <summary>
		/// 
		/// </summary>
        public decimal QUAN2
        {
            get { return _QUAN2; }
            set
            {
                if(_QUAN2!=value || _isLoaded){
                    _QUAN2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QUAN2");
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

        string _BAT_NO;
		/// <summary>
		/// 
		/// </summary>
        public string BAT_NO
        {
            get { return _BAT_NO; }
            set
            {
                if(_BAT_NO!=value || _isLoaded){
                    _BAT_NO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BAT_NO");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _Exp_DateTime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime Exp_DateTime
        {
            get { return _Exp_DateTime; }
            set
            {
                if(_Exp_DateTime!=value || _isLoaded){
                    _Exp_DateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Exp_DateTime");
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


        public static void Delete(Expression<Func<IN01, bool>> expression) {
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

