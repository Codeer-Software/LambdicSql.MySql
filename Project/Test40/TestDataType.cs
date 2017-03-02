using System.Data;
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
    public class TestDataType
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

        [TestMethod]
        public void Test_CreateTable_MySQL()
        {
            CleanUpCreateDropTestTable();

            var sql = Db<DBForCreateTest>.Sql(db =>
                CreateTable(db.table3,
                    new Column(db.table3.obj1, DataType.TinyInt()),
                    new Column(db.table3.obj2, DataType.SmallInt()),
                    new Column(db.table3.obj3, DataType.MediumInt()),
                    new Column(db.table3.obj4, DataType.Int()),
                    new Column(db.table3.obj5, DataType.BigInt()),
                    new Column(db.table3.obj6, DataType.Float()),
                    new Column(db.table3.obj7, DataType.Double()),
                    new Column(db.table3.obj8, DataType.Decimal()),
                    new Column(db.table3.obj9, DataType.Char(1)),
                    new Column(db.table3.obj10, DataType.VarChar(1)),
                    new Column(db.table3.obj11, DataType.TinyBlob()),
                    new Column(db.table3.obj12, DataType.Blob()),
                    new Column(db.table3.obj13, DataType.MediumBlob()),
                    new Column(db.table3.obj14, DataType.LongBlob()),
                    new Column(db.table3.obj15, DataType.TinyText()),
                    new Column(db.table3.obj16, DataType.Text()),
                    new Column(db.table3.obj17, DataType.MediumText()),
                    new Column(db.table3.obj18, DataType.LongText()),
                    new Column(db.table3.obj19, DataType.Enum("a", "b")),
                    new Column(db.table3.obj20, DataType.Set("a", "b")),
                    new Column(db.table3.obj21, DataType.Date()),
                    new Column(db.table3.obj22, DataType.Time()),
                    new Column(db.table3.obj23, DataType.DateTime()),
                    new Column(db.table3.obj24, DataType.TimeStamp()),
                    new Column(db.table3.obj25, DataType.Year())
                ));

            _connection.Execute(sql);
        }

        void CleanUpCreateDropTestTable()
        {
            try
            {
                var sql = Db<DBForCreateTest>.Sql(db => DropTable(db.table3));
                _connection.Execute(sql);
            }
            catch { }
        }
    }
}
