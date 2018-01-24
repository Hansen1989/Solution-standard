 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: PRODUCT00
        /// Primary Key: Id
        /// </summary>

        public class PRODUCT00Structs: DatabaseTable {
            
            public PRODUCT00Structs(IDataProvider provider):base("PRODUCT00",provider){
                ClassName = "PRODUCT00";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("PROD_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PROD_ID"
                });

                Columns.Add(new DatabaseColumn("PROD_NAME1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "PROD_NAME1"
                });

                Columns.Add(new DatabaseColumn("PROD_NAME2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "PROD_NAME2"
                });

                Columns.Add(new DatabaseColumn("PROD_KIND", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_KIND"
                });

                Columns.Add(new DatabaseColumn("PROD_DEP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_DEP"
                });

                Columns.Add(new DatabaseColumn("PROD_CATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_CATE"
                });

                Columns.Add(new DatabaseColumn("DIV_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "DIV_ID"
                });

                Columns.Add(new DatabaseColumn("PROD_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_TYPE"
                });

                Columns.Add(new DatabaseColumn("PROD_Source", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_Source"
                });

                Columns.Add(new DatabaseColumn("INV_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "INV_TYPE"
                });

                Columns.Add(new DatabaseColumn("STOCK_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STOCK_TYPE"
                });

                Columns.Add(new DatabaseColumn("BOM_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BOM_TYPE"
                });

                Columns.Add(new DatabaseColumn("MarginControl", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "MarginControl"
                });

                Columns.Add(new DatabaseColumn("PROD_RangTYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_RangTYPE"
                });

                Columns.Add(new DatabaseColumn("PROD_iRang", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_iRang"
                });

                Columns.Add(new DatabaseColumn("PROD_SPEC", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PROD_SPEC"
                });

                Columns.Add(new DatabaseColumn("PROD_Margin", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PROD_Margin"
                });

                Columns.Add(new DatabaseColumn("PROD_BARCODE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PROD_BARCODE"
                });

                Columns.Add(new DatabaseColumn("PROD_UNIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_UNIT"
                });

                Columns.Add(new DatabaseColumn("PROD_UNIT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_UNIT1"
                });

                Columns.Add(new DatabaseColumn("PROD_CONVERT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_CONVERT1"
                });

                Columns.Add(new DatabaseColumn("PROD_UNIT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_UNIT2"
                });

                Columns.Add(new DatabaseColumn("PROD_CONVERT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_CONVERT2"
                });

                Columns.Add(new DatabaseColumn("Report_UNIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Report_UNIT"
                });

                Columns.Add(new DatabaseColumn("IsBool1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsBool1"
                });

                Columns.Add(new DatabaseColumn("IsBool2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsBool2"
                });

                Columns.Add(new DatabaseColumn("IsBool3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsBool3"
                });

                Columns.Add(new DatabaseColumn("PROD_MEMO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "PROD_MEMO"
                });

                Columns.Add(new DatabaseColumn("CRT_DATETIME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CRT_DATETIME"
                });

                Columns.Add(new DatabaseColumn("CRT_USER_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "CRT_USER_ID"
                });

                Columns.Add(new DatabaseColumn("MOD_DATETIME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "MOD_DATETIME"
                });

                Columns.Add(new DatabaseColumn("MOD_USER_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "MOD_USER_ID"
                });

                Columns.Add(new DatabaseColumn("LAST_UPDATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "LAST_UPDATE"
                });

                Columns.Add(new DatabaseColumn("STATUS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STATUS"
                });

                Columns.Add(new DatabaseColumn("PROD_NAME1_SPELLING", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "PROD_NAME1_SPELLING"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn PROD_ID{
                get{
                    return this.GetColumn("PROD_ID");
                }
            }
				
            
            public IColumn PROD_NAME1{
                get{
                    return this.GetColumn("PROD_NAME1");
                }
            }
				
            
            public IColumn PROD_NAME2{
                get{
                    return this.GetColumn("PROD_NAME2");
                }
            }
				
            
            public IColumn PROD_KIND{
                get{
                    return this.GetColumn("PROD_KIND");
                }
            }
				
            
            public IColumn PROD_DEP{
                get{
                    return this.GetColumn("PROD_DEP");
                }
            }
				
            
            public IColumn PROD_CATE{
                get{
                    return this.GetColumn("PROD_CATE");
                }
            }
				
            
            public IColumn DIV_ID{
                get{
                    return this.GetColumn("DIV_ID");
                }
            }
				
            
            public IColumn PROD_TYPE{
                get{
                    return this.GetColumn("PROD_TYPE");
                }
            }
				
            
            public IColumn PROD_Source{
                get{
                    return this.GetColumn("PROD_Source");
                }
            }
				
            
            public IColumn INV_TYPE{
                get{
                    return this.GetColumn("INV_TYPE");
                }
            }
				
            
            public IColumn STOCK_TYPE{
                get{
                    return this.GetColumn("STOCK_TYPE");
                }
            }
				
            
            public IColumn BOM_TYPE{
                get{
                    return this.GetColumn("BOM_TYPE");
                }
            }
				
            
            public IColumn MarginControl{
                get{
                    return this.GetColumn("MarginControl");
                }
            }
				
            
            public IColumn PROD_RangTYPE{
                get{
                    return this.GetColumn("PROD_RangTYPE");
                }
            }
				
            
            public IColumn PROD_iRang{
                get{
                    return this.GetColumn("PROD_iRang");
                }
            }
				
            
            public IColumn PROD_SPEC{
                get{
                    return this.GetColumn("PROD_SPEC");
                }
            }
				
            
            public IColumn PROD_Margin{
                get{
                    return this.GetColumn("PROD_Margin");
                }
            }
				
            
            public IColumn PROD_BARCODE{
                get{
                    return this.GetColumn("PROD_BARCODE");
                }
            }
				
            
            public IColumn PROD_UNIT{
                get{
                    return this.GetColumn("PROD_UNIT");
                }
            }
				
            
            public IColumn PROD_UNIT1{
                get{
                    return this.GetColumn("PROD_UNIT1");
                }
            }
				
            
            public IColumn PROD_CONVERT1{
                get{
                    return this.GetColumn("PROD_CONVERT1");
                }
            }
				
            
            public IColumn PROD_UNIT2{
                get{
                    return this.GetColumn("PROD_UNIT2");
                }
            }
				
            
            public IColumn PROD_CONVERT2{
                get{
                    return this.GetColumn("PROD_CONVERT2");
                }
            }
				
            
            public IColumn Report_UNIT{
                get{
                    return this.GetColumn("Report_UNIT");
                }
            }
				
            
            public IColumn IsBool1{
                get{
                    return this.GetColumn("IsBool1");
                }
            }
				
            
            public IColumn IsBool2{
                get{
                    return this.GetColumn("IsBool2");
                }
            }
				
            
            public IColumn IsBool3{
                get{
                    return this.GetColumn("IsBool3");
                }
            }
				
            
            public IColumn PROD_MEMO{
                get{
                    return this.GetColumn("PROD_MEMO");
                }
            }
				
            
            public IColumn CRT_DATETIME{
                get{
                    return this.GetColumn("CRT_DATETIME");
                }
            }
				
            
            public IColumn CRT_USER_ID{
                get{
                    return this.GetColumn("CRT_USER_ID");
                }
            }
				
            
            public IColumn MOD_DATETIME{
                get{
                    return this.GetColumn("MOD_DATETIME");
                }
            }
				
            
            public IColumn MOD_USER_ID{
                get{
                    return this.GetColumn("MOD_USER_ID");
                }
            }
				
            
            public IColumn LAST_UPDATE{
                get{
                    return this.GetColumn("LAST_UPDATE");
                }
            }
				
            
            public IColumn STATUS{
                get{
                    return this.GetColumn("STATUS");
                }
            }
				
            
            public IColumn PROD_NAME1_SPELLING{
                get{
                    return this.GetColumn("PROD_NAME1_SPELLING");
                }
            }
				
            
                    
        }
        
}
