 
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
    /// A class which represents the Purchase01 table in the SolutionDataBase_standard Database.
    /// </summary>
    public partial class Purchase01: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Purchase01> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Purchase01>(new Solution.DataAccess.DataModel.SolutionDataBase_standardDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Purchase01> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Purchase01 item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Purchase01 item=new Purchase01();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Purchase01> _repo;
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
        public Purchase01(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Purchase01.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Purchase01>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Purchase01(){
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
               
            SNo = readRecord.get_int("SNo",null);
               
            PROD_ID = readRecord.get_string("PROD_ID",null);
               
            QUANTITY = readRecord.get_decimal("QUANTITY",null);
               
            STD_UNIT = readRecord.get_string("STD_UNIT",null);
               
            STD_CONVERT = readRecord.get_int("STD_CONVERT",null);
               
            STD_QUAN = readRecord.get_decimal("STD_QUAN",null);
               
            STD_PRICE = readRecord.get_decimal("STD_PRICE",null);
               
            Tax = readRecord.get_decimal("Tax",null);
               
            QUAN1 = readRecord.get_decimal("QUAN1",null);
               
            QUAN2 = readRecord.get_decimal("QUAN2",null);
               
            Item_DISC_Amt = readRecord.get_decimal("Item_DISC_Amt",null);
               
            MEMO = readRecord.get_string("MEMO",null);
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

        public Purchase01(Expression<Func<Purchase01, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Purchase01> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.SolutionDataBase_standardDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB();
            }else{
                db=new Solution.DataAccess.DataModel.SolutionDataBase_standardDB(connectionString, providerName);
            }
            IRepository<Purchase01> _repo;
            
            if(db.TestMode){
                Purchase01.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Purchase01>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Purchase01> GetRepo(){
            return GetRepo("","");
        }
        
        public static Purchase01 SingleOrDefault(Expression<Func<Purchase01, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Purchase01 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Purchase01 SingleOrDefault(Expression<Func<Purchase01, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Purchase01 single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Purchase01, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Purchase01, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Purchase01> Find(Expression<Func<Purchase01, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Purchase01> Find(Expression<Func<Purchase01, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Purchase01> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Purchase01> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Purchase01> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Purchase01> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Purchase01> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Purchase01> GetPaged(int pageIndex, int pageSize) {
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
            if(obj.GetType()==typeof(Purchase01)){
                Purchase01 compare=(Purchase01)obj;
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

        decimal _Tax;
		/// <summary>
		/// 
		/// </summary>
        public decimal Tax
        {
            get { return _Tax; }
            set
            {
                if(_Tax!=value || _isLoaded){
                    _Tax=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Tax");
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

        decimal _Item_DISC_Amt;
		/// <summary>
		/// 
		/// </summary>
        public decimal Item_DISC_Amt
        {
            get { return _Item_DISC_Amt; }
            set
            {
                if(_Item_DISC_Amt!=value || _isLoaded){
                    _Item_DISC_Amt=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Item_DISC_Amt");
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


        public static void Delete(Expression<Func<Purchase01, bool>> expression) {
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

