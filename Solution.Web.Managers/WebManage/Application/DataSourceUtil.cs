using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace Solution.Web.Managers.WebManage.Application
{
    public static class DataSourceUtil
    {
        #region GetClassDataTable

        /// <summary>
        /// 获取班级的数据表格
        /// </summary>
        /// <returns></returns>
        public static DataTable GetClassDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("LogTime", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Desc", typeof(string)));

            DataRow row = table.NewRow();

            row[0] = 101;
            row[1] = "班级一";
            row[2] = 2000;
            row[3] = DateTime.Parse("2000-09-01");
            row[4] = "班级一创建于2000年9月1号，班长胡飞，连续三年获得全校优秀班级称号。";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "班级二";
            row[2] = 2005;
            row[3] = DateTime.Parse("2005-09-01");
            row[4] = "班级二创建于2005年9月1号，班长董婷婷，连续两年获得全校优秀班级称号。";
            table.Rows.Add(row);

            return table;
        } 

        #endregion

        #region GetEmptyDataTable

        /// <summary>
        /// 获取空数据表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEmptyDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(String)));
            table.Columns.Add(new DataColumn("Group", typeof(int)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("LogTime", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Desc", typeof(string)));
            table.Columns.Add(new DataColumn("Guid", typeof(Guid)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));

            return table;
        }

        #endregion

        #region GetDataTable

        /// <summary>
        /// 获取模拟表格
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(String)));
            table.Columns.Add(new DataColumn("Group", typeof(int)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("LogTime", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Desc", typeof(string)));
            table.Columns.Add(new DataColumn("Guid", typeof(Guid)));

            // Hobby：reading,basketball,travel,movie,music
            // 爱好：读书, 篮球, 旅游, 电影, 音乐
            table.Columns.Add(new DataColumn("Hobby", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));

            // 考试成绩
            table.Columns.Add(new DataColumn("ChineseScore", typeof(Int32)));
            table.Columns.Add(new DataColumn("MathScore", typeof(Int32)));
            table.Columns.Add(new DataColumn("TotalScore", typeof(Int32)));

            // 体检结果
            table.Columns.Add(new DataColumn("ShenGao", typeof(Int32)));
            table.Columns.Add(new DataColumn("TiZhong", typeof(Int32)));
            table.Columns.Add(new DataColumn("XueYaDi", typeof(String)));
            table.Columns.Add(new DataColumn("XueYaGao", typeof(String)));
            table.Columns.Add(new DataColumn("ShiLiZuo", typeof(Single)));
            table.Columns.Add(new DataColumn("ShiLiYou", typeof(Single)));
            table.Columns.Add(new DataColumn("ShiLiZuoJiaoZhen", typeof(Single)));
            table.Columns.Add(new DataColumn("ShiLiYouJiaoZhen", typeof(Single)));

            // 合并单元格需要的字段
            table.Columns.Add(new DataColumn("GroupB", typeof(int)));


            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "张萍萍";
            row[2] = 2000;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 1;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-100); // DBNull.Value;
            row[8] = "张萍萍，女，20岁，出生于中国南方的一个小山村，毕业于中国科学技术大学。<br/>毕业后就职于某大型国有企业，任部门经理，连续三年获得企业优秀员工称号。<br/>aaaaaaaaaaabbbbbbbbbbbbcccccccccccdddddddddddddeeeeeeeeeeeeffffffffffff";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,music";
            row[11] = "2000-09-01";
            row[12] = 80;
            row[13] = 90;
            row[14] = 170;
            row[15] = 180;
            row[16] = 150;
            row[17] = 80;
            row[18] = 120;
            row[19] = 0.2;
            row[20] = 0.5;
            row[21] = 1.0;
            row[22] = 1.2;
            row[23] = 1;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "陈飞";
            row[2] = 2000;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 1;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "陈飞，男，20岁，出生于中国北方的一个小山村，毕业于南方科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "basketball,travel,movie,reading,music";
            row[11] = "2001-09-01";
            row[12] = 85;
            row[13] = 90;
            row[14] = 175;
            row[15] = 160;
            row[16] = 120;
            row[17] = 70;
            row[18] = 110;
            row[19] = 0.3;
            row[20] = 0.3;
            row[21] = 1.2;
            row[22] = 1.2;
            row[23] = 3;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "董婷婷";
            row[2] = 2000;
            row[3] = true;
            row[4] = "化学系";
            row[5] = 2;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "董婷婷，女，18岁，出生于中国海南岛的一个小山村，毕业于中国科学技术大学。<br/>董婷婷是在学校认识丈夫刘国的，有一天晚上下自习后，董婷婷发短信给刘国说“做我男朋友吧！”，然后他们就走到了一起。";
            row[9] = Guid.NewGuid();
            row[10] = "basketball,movie,music";
            row[11] = "2008-09-01";
            row[12] = 90;
            row[13] = 90;
            row[14] = 180;
            row[15] = 190;
            row[16] = 130;
            row[17] = 82;
            row[18] = 125;
            row[19] = 0.8;
            row[20] = 0.6;
            row[21] = 1.2;
            row[22] = 1.0;
            row[23] = 2;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 104;
            row[1] = "刘国";
            row[2] = 2002;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 2;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "刘国，男，22岁，出生于中国澳门的一个小山村，毕业于中国科学技术大学。<br/>刘国是作为交换生来中科大学习，在校期间认识了妻子董婷婷，虽然是被追到手了，不过在人前却总是说“老婆是我千辛万苦追来的！”。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,movie";
            row[11] = "2002-09-01";
            row[12] = 95;
            row[13] = 95;
            row[14] = 190;
            row[15] = 170;
            row[16] = 130;
            row[17] = 76;
            row[18] = 112;
            row[19] = 1.0;
            row[20] = 1.0;
            row[21] = 1.0;
            row[22] = 1.0;
            row[23] = 2;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 105;
            row[1] = "康颖颖";
            row[2] = 2008;
            row[3] = true;
            row[4] = "数学系";
            row[5] = 3;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-60);
            row[8] = "康颖颖，女，26岁，出生于中国福建的一个小山村，毕业于香港科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,movie,music";
            row[11] = "2008-09-01";
            row[12] = 85;
            row[13] = 95;
            row[14] = 180;
            row[15] = 159;
            row[16] = 90;
            row[17] = 77;
            row[18] = 128;
            row[19] = 0.6;
            row[20] = 0.9;
            row[21] = 1.2;
            row[22] = 1.2;
            row[23] = 3;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 106;
            row[1] = "彭博";
            row[2] = 2008;
            row[3] = true;
            row[4] = "数学系";
            row[5] = 3;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-50);
            row[8] = "彭博，男，28岁，出生于中国浙江的一个小山村，毕业于电子科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "basketball,travel,music";
            row[11] = "2003-09-01";
            row[12] = 60;
            row[13] = 100;
            row[14] = 160;
            row[15] = 175;
            row[16] = 150;
            row[17] = 88;
            row[18] = 126;
            row[19] = 0.1;
            row[20] = 0.3;
            row[21] = 1.5;
            row[22] = 1.2;
            row[23] = 3;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 107;
            row[1] = "黄婷婷";
            row[2] = 2008;
            row[3] = true;
            row[4] = "数学系";
            row[5] = 3;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-50);
            row[8] = "黄婷婷，女，25岁，出生于中国北方的一个小山村，毕业于北京科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "travel,movie,music,reading";
            row[11] = "2000-09-01";
            row[12] = 100;
            row[13] = 80;
            row[14] = 180;
            row[15] = 160;
            row[16] = 80;
            row[17] = 70;
            row[18] = 110;
            row[19] = 0.8;
            row[20] = 0.8;
            row[21] = 1.2;
            row[22] = 1.2;
            row[23] = 3;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 108;
            row[1] = "唐超";
            row[2] = 2004;
            row[3] = false;
            row[4] = "物理系";
            row[5] = 3;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-50);
            row[8] = "唐超，男，26岁，出生于中国河南的一个小山村，毕业于中国科学技术大学。<br/>作为刘国的同班同学，唐超是班里的尖子生，本科还没毕业就被哈佛大学录取了，现在好像还没毕业呢。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,movie,music,basketball";
            row[11] = "2004-09-01";
            row[12] = 80;
            row[13] = 80;
            row[14] = 160;
            row[15] = 188;
            row[16] = 130;
            row[17] = 82;
            row[18] = 130;
            row[19] = 0.5;
            row[20] = 0.8;
            row[21] = 1.3;
            row[22] = 1.2;
            row[23] = 3;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 109;
            row[1] = "杨婷婷";
            row[2] = 2004;
            row[3] = true;
            row[4] = "物理系";
            row[5] = 5;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-50);
            row[8] = "杨婷婷，女，25岁，出生于中国广西的一个小山村，毕业于南方科学技术大学。<br/>杨婷婷的父母都是中科大的高材生，他们很高兴送女儿上一所前中科大校长创办的大学，而南科大自己颁发的学位文凭也颇受争议。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,movie";
            row[11] = "2003-09-01";
            row[12] = 90;
            row[13] = 60;
            row[14] = 150;
            row[15] = 166;
            row[16] = 110;
            row[17] = 70;
            row[18] = 116;
            row[19] = 0.8;
            row[20] = 1.0;
            row[21] = 0.8;
            row[22] = 1.0;
            row[23] = 5;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 110;
            row[1] = "徐鹏";
            row[2] = 2002;
            row[3] = false;
            row[4] = "物理系";
            row[5] = 5;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-50);
            row[8] = "徐鹏，男，23岁，出生于中国安徽的一个小山村，毕业于国防科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,travel";
            row[11] = "2002-09-01";
            row[12] = 60;
            row[13] = 90;
            row[14] = 150;
            row[15] = 198;
            row[16] = 145;
            row[17] = 83;
            row[18] = 128;
            row[19] = 1.2;
            row[20] = 1.5;
            row[21] = 1.2;
            row[22] = 1.5;
            row[23] = 5;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 111;
            row[1] = "董国";
            row[2] = 2012;
            row[3] = true;
            row[4] = "自动化系";
            row[5] = 5;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-5);
            row[8] = "董国，男，22岁，出生于中国台湾的一个小山村，毕业于台湾科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,movie,music,basketball";
            row[11] = "2006-09-01";
            row[12] = 90;
            row[13] = 70;
            row[14] = 160;
            row[15] = 158;
            row[16] = 76;
            row[17] = 69;
            row[18] = 109;
            row[19] = 0.8;
            row[20] = 0.6;
            row[21] = 1.2;
            row[22] = 1.2;
            row[23] = 5;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 112;
            row[1] = "张一弛";
            row[2] = 2012;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 5;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-5);
            row[8] = "张一弛，男，28岁，出生于中国河南的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,movie,music";
            row[11] = "2000-09-01";
            row[12] = 99;
            row[13] = 98;
            row[14] = 197;
            row[15] = 183;
            row[16] = 125;
            row[17] = 80;
            row[18] = 120;
            row[19] = 0.8;
            row[20] = 0.6;
            row[21] = 1.2;
            row[22] = 1.2;
            row[23] = 5;
            table.Rows.Add(row);

            return table;
        }


        /// <summary>
        /// 获取模拟表格（简单表格）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSimpleDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(String)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));



            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "张萍萍";
            row[2] = 2000;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 0;
            row[6] = "2000-09-01";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "陈飞";
            row[2] = 2000;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 1;
            row[6] = "2001-09-01";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "董婷婷";
            row[2] = 2000;
            row[3] = true;
            row[4] = "化学系";
            row[5] = 0;
            row[6] = "2008-09-01";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 104;
            row[1] = "刘国";
            row[2] = 2002;
            row[3] = false;
            row[4] = "化学系";
            row[5] = 1;
            row[6] = "2002-09-01";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 105;
            row[1] = "康颖颖";
            row[2] = 2008;
            row[3] = true;
            row[4] = "数学系";
            row[5] = 0;
            row[6] = "2008-09-01";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 106;
            row[1] = "彭博";
            row[2] = 2008;
            row[3] = true;
            row[4] = "数学系";
            row[5] = 1;
            row[6] = "2003-09-01";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 107;
            row[1] = "黄婷婷";
            row[2] = 2008;
            row[3] = true;
            row[4] = "数学系";
            row[5] = 0;
            row[6] = "2000-09-01";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 108;
            row[1] = "唐超";
            row[2] = 2004;
            row[3] = false;
            row[4] = "物理系";
            row[5] = 1;
            row[6] = "2004-09-01";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 109;
            row[1] = "杨婷婷";
            row[2] = 2004;
            row[3] = true;
            row[4] = "物理系";
            row[5] = 0;
            row[6] = "2003-09-01";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 110;
            row[1] = "徐鹏";
            row[2] = 2002;
            row[3] = false;
            row[4] = "物理系";
            row[5] = 1;
            row[6] = "2002-09-01";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 111;
            row[1] = "董国";
            row[2] = 2012;
            row[3] = true;
            row[4] = "自动化系";
            row[5] = 1;
            row[6] = "2006-09-01";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 112;
            row[1] = "张一弛";
            row[2] = 2012;
            row[3] = true;
            row[4] = "材料科学与工程系";
            row[5] = 1;
            row[6] = "2000-09-01";
            table.Rows.Add(row);

            return table;
        }

        #endregion

        #region GetDataTable2

        /// <summary>
        /// 获取模拟表格2
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable2()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(String)));
            table.Columns.Add(new DataColumn("Group", typeof(int)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("LogTime", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Desc", typeof(string)));
            table.Columns.Add(new DataColumn("Guid", typeof(Guid)));
            table.Columns.Add(new DataColumn("Hobby", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));
            table.Columns.Add(new DataColumn("Donate", typeof(int)));
            table.Columns.Add(new DataColumn("Fee", typeof(int)));
            // Hobby：reading,basketball,travel,movie,music
            // 爱好：读书, 篮球, 旅游, 电影, 音乐 

            // 考试成绩
            table.Columns.Add(new DataColumn("ChineseScore", typeof(Int32)));
            table.Columns.Add(new DataColumn("MathScore", typeof(Int32)));
            table.Columns.Add(new DataColumn("TotalScore", typeof(Int32)));


            DataRow row = null;

            row = table.NewRow();
            row[0] = 101;
            row[1] = "陈萍萍";
            row[2] = 2000;
            row[3] = true;
            row[4] = "计算机应用技术";
            row[5] = 1;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "陈萍萍，女，20岁，出生于中国南方的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,travel";
            row[11] = "2000-09-01";
            row[12] = 299;
            row[13] = 2990;
            row[14] = 80;
            row[15] = 80;
            row[16] = 160;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "胡飞";
            row[2] = 2008;
            row[3] = true;
            row[4] = "信息工程";
            row[5] = 1;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-90);
            row[8] = "胡飞，男，20岁，出生于中国北方的一个小山村，毕业于南方科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball";
            row[11] = "2008-09-01";
            row[12] = 199;
            row[13] = 1990;
            row[14] = 90;
            row[15] = 80;
            row[16] = 170;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "金婷婷";
            row[2] = 2001;
            row[3] = false;
            row[4] = "会计学";
            row[5] = 2;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-80);
            row[8] = "金婷婷，女，28岁，出生于中国海南岛的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,music";
            row[11] = "2001-09-01";
            row[12] = 299;
            row[13] = 3990;
            row[14] = 85;
            row[15] = 85;
            row[16] = 170;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 104;
            row[1] = "潘国";
            row[2] = 2008;
            row[3] = false;
            row[4] = "国际经济与贸易";
            row[5] = 2;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-70);
            row[8] = "潘国，男，22岁，出生于中国澳门的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,music";
            row[11] = "2008-09-01";
            row[12] = 399;
            row[13] = 3998;
            row[14] = 89;
            row[15] = 80;
            row[16] = 169;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 105;
            row[1] = "吴颖颖";
            row[2] = 2002;
            row[3] = true;
            row[4] = "市场营销";
            row[5] = 3;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-60);
            row[8] = "吴颖颖，女，26岁，出生于中国福建的一个小山村，毕业于香港科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,movie,music";
            row[11] = "2002-09-01";
            row[12] = 499;
            row[13] = 4992;
            row[14] = 92;
            row[15] = 85;
            row[16] = 177;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 106;
            row[1] = "张博";
            row[2] = 2003;
            row[3] = true;
            row[4] = "财务管理";
            row[5] = 3;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-50);
            row[8] = "张博，男，28岁，出生于中国浙江的一个小山村，毕业于电子科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "movie,music";
            row[11] = "2003-09-01";
            row[12] = 99;
            row[13] = 997;
            row[14] = 88;
            row[15] = 86;
            row[16] = 174;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 107;
            row[1] = "杨倩倩";
            row[2] = 2000;
            row[3] = false;
            row[4] = "材料物理与化学";
            row[5] = 4;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-40);
            row[8] = "杨倩倩，女，25岁，出生于中国北方的一个小山村，毕业于北京科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "travel,movie,music";
            row[11] = "2000-09-01";
            row[12] = 399;
            row[13] = 3995;
            row[14] = 95;
            row[15] = 82;
            row[16] = 177;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 108;
            row[1] = "董超";
            row[2] = 2004;
            row[3] = false;
            row[4] = "生物医学工程";
            row[5] = 4;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-30);
            row[8] = "董超，男，26岁，出生于中国河南的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "basketball,movie,music";
            row[11] = "2004-09-01";
            row[12] = 299;
            row[13] = 2996;
            row[14] = 86;
            row[15] = 98;
            row[16] = 184;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 109;
            row[1] = "张娟娟";
            row[2] = 2003;
            row[3] = true;
            row[4] = "材料物理与化学";
            row[5] = 5;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-20);
            row[8] = "张娟娟，女，25岁，出生于中国广西的一个小山村，毕业于南方科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,movie,music";
            row[11] = "2003-09-01";
            row[12] = 599;
            row[13] = 5990;
            row[14] = 92;
            row[15] = 96;
            row[16] = 198;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 110;
            row[1] = "叶鹏";
            row[2] = 2006;
            row[3] = false;
            row[4] = "电子商务";
            row[5] = 5;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-10);
            row[8] = "叶鹏，男，23岁，出生于中国安徽的一个小山村，毕业于国防科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,movie,music";
            row[11] = "2006-09-01";
            row[12] = 699;
            row[13] = 6990;
            row[14] = 69;
            row[15] = 99;
            row[16] = 168;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 111;
            row[1] = "李玲玲";
            row[2] = 2002;
            row[3] = true;
            row[4] = "管理学";
            row[5] = 5;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-5);
            row[8] = "李玲玲，女，22岁，出生于中国台湾的一个小山村，毕业于台湾科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,music";
            row[11] = "2002-09-01";
            row[12] = 399;
            row[13] = 3990;
            row[14] = 88;
            row[15] = 92;
            row[16] = 180;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 112;
            row[1] = "张萍萍";
            row[2] = 2000;
            row[3] = true;
            row[4] = "计算机应用技术";
            row[5] = 1;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "张萍萍，女，20岁，出生于中国南方的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,travel";
            row[11] = "2000-09-01";
            row[12] = 299;
            row[13] = 2999;
            row[14] = 82;
            row[15] = 88;
            row[16] = 170;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 113;
            row[1] = "曹飞";
            row[2] = 2008;
            row[3] = false;
            row[4] = "信息工程";
            row[5] = 1;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-90);
            row[8] = "曹飞，男，20岁，出生于中国北方的一个小山村，毕业于南方科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball";
            row[11] = "2008-09-01";
            row[12] = 399;
            row[13] = 3996;
            row[14] = 96;
            row[15] = 85;
            row[16] = 181;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 114;
            row[1] = "孙婷婷";
            row[2] = 2001;
            row[3] = true;
            row[4] = "材料物理与化学";
            row[5] = 2;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-80);
            row[8] = "孙婷婷，女，28岁，出生于中国海南岛的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,basketball,music";
            row[11] = "2001-09-01";
            row[12] = 499;
            row[13] = 4990;
            row[14] = 80;
            row[15] = 90;
            row[16] = 170;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 115;
            row[1] = "董国";
            row[2] = 2008;
            row[3] = false;
            row[4] = "国际经济与贸易";
            row[5] = 2;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-70);
            row[8] = "董国，男，22岁，出生于中国澳门的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,music";
            row[11] = "2008-09-01";
            row[12] = 299;
            row[13] = 2992;
            row[14] = 90;
            row[15] = 95;
            row[16] = 185;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 116;
            row[1] = "习颖颖";
            row[2] = 2002;
            row[3] = true;
            row[4] = "市场营销";
            row[5] = 3;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-60);
            row[8] = "习颖颖，女，26岁，出生于中国福建的一个小山村，毕业于香港科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,movie,music";
            row[11] = "2002-09-01";
            row[12] = 199;
            row[13] = 1990;
            row[14] = 86;
            row[15] = 90;
            row[16] = 176;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 117;
            row[1] = "李博";
            row[2] = 2003;
            row[3] = true;
            row[4] = "财务管理";
            row[5] = 3;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-50);
            row[8] = "李博，男，28岁，出生于中国浙江的一个小山村，毕业于电子科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "movie,music";
            row[11] = "2003-09-01";
            row[12] = 99;
            row[13] = 990;
            row[14] = 80;
            row[15] = 95;
            row[16] = 175;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 118;
            row[1] = "黄婷婷";
            row[2] = 2000;
            row[3] = false;
            row[4] = "材料物理与化学";
            row[5] = 4;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-40);
            row[8] = "黄婷婷，女，25岁，出生于中国北方的一个小山村，毕业于北京科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "travel,movie,music";
            row[11] = "2000-09-01";
            row[12] = 399;
            row[13] = 3990;
            row[14] = 95;
            row[15] = 88;
            row[16] = 183;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 119;
            row[1] = "韩超";
            row[2] = 2004;
            row[3] = false;
            row[4] = "生物医学工程";
            row[5] = 4;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-30);
            row[8] = "韩超，男，26岁，出生于中国河南的一个小山村，毕业于中国科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "basketball,movie,music";
            row[11] = "2004-09-01";
            row[12] = 399;
            row[13] = 3991;
            row[14] = 88;
            row[15] = 86;
            row[16] = 174;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 120;
            row[1] = "王娟娟";
            row[2] = 2003;
            row[3] = true;
            row[4] = "材料物理与化学";
            row[5] = 5;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-20);
            row[8] = "王娟娟，女，25岁，出生于中国广西的一个小山村，毕业于南方科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,movie,music";
            row[11] = "2003-09-01";
            row[12] = 399;
            row[13] = 3992;
            row[14] = 90;
            row[15] = 88;
            row[16] = 178;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 121;
            row[1] = "周鹏";
            row[2] = 2006;
            row[3] = false;
            row[4] = "电子商务";
            row[5] = 5;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-10);
            row[8] = "周鹏，男，23岁，出生于中国安徽的一个小山村，毕业于国防科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,movie,music";
            row[11] = "2006-09-01";
            row[12] = 299;
            row[13] = 2992;
            row[14] = 92;
            row[15] = 96;
            row[16] = 186;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 122;
            row[1] = "吴玲玲";
            row[2] = 2002;
            row[3] = true;
            row[4] = "管理学";
            row[5] = 5;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-5);
            row[8] = "吴玲玲，女，22岁，出生于中国台湾的一个小山村，毕业于台湾科学技术大学。";
            row[9] = Guid.NewGuid();
            row[10] = "reading,travel,music";
            row[11] = "2002-09-01";
            row[12] = 399;
            row[13] = 3993;
            row[14] = 95;
            row[15] = 89;
            row[16] = 184;
            table.Rows.Add(row);


            return table;
        } 
        #endregion

    }
}