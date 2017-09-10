using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LambdicSql;
using LambdicSql.feat.Dapper;
using static LambdicSql.MySql.Symbol;
using static Test.Helper.DBProviderInfo;
using Test.Helper;
using LambdicSql.MySql;

namespace Test
{
    [TestClass]
    public class TestSymbolFuncs
    {
        public TestContext TestContext { get; set; }
        public IDbConnection _connection;

        [TestInitialize]
        public void TestInitialize()
        {
            _connection = TestEnvironment.CreateConnection(TestContext);
            _connection.Open();
        }

        [TestCleanup]
        public void TestCleanup() => _connection.Dispose();

        public class SelectData
        {
            public decimal Val { get; set; }
            public decimal Val1 { get; set; }
            public decimal Val2 { get; set; }
            public decimal Val3 { get; set; }
            public double ValDouble { get; set; }
            public double ValFloat { get; set; }
        }

        [TestMethod]
        public void Test_Sum()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new SelectData
               {
                   Val1 = Sum(db.tbl_remuneration.money),
                   Val2 = Sum(All(), db.tbl_remuneration.money)
               }).
               From(db.tbl_remuneration).
                   Join(db.tbl_staff, db.tbl_remuneration.staff_id == db.tbl_staff.id).
               GroupBy(db.tbl_staff.id, db.tbl_staff.name));
            
            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
 @"SELECT
	SUM(tbl_remuneration.money) AS Val1,
	SUM(ALL tbl_remuneration.money) AS Val2
FROM tbl_remuneration
	JOIN tbl_staff ON tbl_remuneration.staff_id = tbl_staff.id
GROUP BY tbl_staff.id, tbl_staff.name");
        }

        [TestMethod]
        public void Test_Count_1()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new SelectData
               {
                   Val1 = Count(db.tbl_remuneration.money),
                   Val2 = Count(Asterisk()),
                   Val3 = Count(Distinct(), db.tbl_remuneration.money)
               }).
               From(db.tbl_remuneration).
                   Join(db.tbl_staff, db.tbl_remuneration.staff_id == db.tbl_staff.id).
               GroupBy(db.tbl_staff.id, db.tbl_staff.name));
            
            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	COUNT(tbl_remuneration.money) AS Val1,
	COUNT(*) AS Val2,
	COUNT(DISTINCT tbl_remuneration.money) AS Val3
FROM tbl_remuneration
	JOIN tbl_staff ON tbl_remuneration.staff_id = tbl_staff.id
GROUP BY tbl_staff.id, tbl_staff.name");
        }

        [TestMethod]
        public void Test_Count_2()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new SelectData
               {
                   Val1 = Count(All(), Asterisk())
               }).
               From(db.tbl_remuneration).
                   Join(db.tbl_staff, db.tbl_remuneration.staff_id == db.tbl_staff.id).
               GroupBy(db.tbl_staff.id, db.tbl_staff.name));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	COUNT(ALL *) AS Val1
FROM tbl_remuneration
	JOIN tbl_staff ON tbl_remuneration.staff_id = tbl_staff.id
GROUP BY tbl_staff.id, tbl_staff.name");
        }

        [TestMethod]
        public void Test_Avg_Min_Max()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new SelectData
               {
                   Val1 = (decimal)Avg(db.tbl_remuneration.money),
                   Val2 = Min(db.tbl_remuneration.money),
                   Val3 = Max(db.tbl_remuneration.money),
               }).
               From(db.tbl_remuneration).
                   Join(db.tbl_staff, db.tbl_remuneration.staff_id == db.tbl_staff.id).
               GroupBy(db.tbl_staff.id, db.tbl_staff.name));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	AVG(tbl_remuneration.money) AS Val1,
	MIN(tbl_remuneration.money) AS Val2,
	MAX(tbl_remuneration.money) AS Val3
FROM tbl_remuneration
	JOIN tbl_staff ON tbl_remuneration.staff_id = tbl_staff.id
GROUP BY tbl_staff.id, tbl_staff.name");
        }

        [TestMethod]
        public void Test_Abs_Round()
        {
            var sql = Db<DB>.Sql(db =>
                Select(new SelectData
                {
                    Val1 = Abs(1),
                    Val2 = Round(2, 3),
                }).
                From(db.tbl_staff));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	ABS(@p_0) AS Val1,
	ROUND(@p_1, @p_2) AS Val2
FROM tbl_staff", 1, 2, 3);
        }

        [TestMethod]
        public void Test_Concat()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new
               {
                   Val = Concat(db.tbl_staff.name, "a", "b")
               }).
               From(db.tbl_staff));
            
            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	CONCAT(tbl_staff.name, @p_0, @p_1) AS Val
FROM tbl_staff", "a", "b");
        }

        [TestMethod]
        public void Test_Lower()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new
               {
                   Val = Lower(db.tbl_staff.name)
               }).
               From(db.tbl_staff));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	LOWER(tbl_staff.name) AS Val
FROM tbl_staff");
        }

        [TestMethod]
        public void Test_Upper()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new
               {
                   Val = Upper(db.tbl_staff.name)
               }).
               From(db.tbl_staff));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	UPPER(tbl_staff.name) AS Val
FROM tbl_staff");
        }
        
        [TestMethod]
        public void Test_Replace()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new
               {
                   Val = Replace(db.tbl_staff.name, "a", "b")
               }).
               From(db.tbl_staff));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	REPLACE(tbl_staff.name, @p_0, @p_1) AS Val
FROM tbl_staff",
"a", "b");
        }
        
        [TestMethod]
        public void Test_Substring()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new
               {
                   Val = Substring(db.tbl_staff.name, 0, 1)
               }).
               From(db.tbl_staff));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	SUBSTRING(tbl_staff.name, @p_0, @p_1) AS Val
FROM tbl_staff",
0, 1);
        }

        [TestMethod]
        public void Test_Extract_2()
        {
            var sql = Db<DB>.Sql(db =>
            Select(new
            {
                Val1 = (long)Extract(DateTimeElement.Year, Current_TimeStamp()),
                Val2 = (long)Extract(DateTimeElement.Month, Current_TimeStamp()),
                Val3 = (long)Extract(DateTimeElement.Day, Current_TimeStamp()),
                Val4 = (long)Extract(DateTimeElement.Hour, Current_TimeStamp()),
                Val5 = (long)Extract(DateTimeElement.Minute, Current_TimeStamp()),
                Val6 = (long)Extract(DateTimeElement.Second, Current_TimeStamp()),
                Val7 = (long)Extract(DateTimeElement.Quarter, Current_TimeStamp()),
                Val8 = (long)Extract(DateTimeElement.Week, Current_TimeStamp())
            }));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	EXTRACT(YEAR FROM CURRENT_TIMESTAMP) AS Val1,
	EXTRACT(MONTH FROM CURRENT_TIMESTAMP) AS Val2,
	EXTRACT(DAY FROM CURRENT_TIMESTAMP) AS Val3,
	EXTRACT(HOUR FROM CURRENT_TIMESTAMP) AS Val4,
	EXTRACT(MINUTE FROM CURRENT_TIMESTAMP) AS Val5,
	EXTRACT(SECOND FROM CURRENT_TIMESTAMP) AS Val6,
	EXTRACT(QUARTER FROM CURRENT_TIMESTAMP) AS Val7,
	EXTRACT(WEEK FROM CURRENT_TIMESTAMP) AS Val8");
        }

        [TestMethod]
        public void Test_Coalesce()
        {
            var sql = Db<DB>.Sql(db =>
               Select(new
               {
                   id = Coalesce(db.tbl_staff.name, "a")
               }).
               From(db.tbl_staff));

            var datas = _connection.Query(sql).ToList();
            Assert.IsTrue(0 < datas.Count);
            AssertEx.AreEqual(sql, _connection,
@"SELECT
	COALESCE(tbl_staff.name, @p_0) AS id
FROM tbl_staff",
"a");
        }
    }
}