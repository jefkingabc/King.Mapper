﻿namespace King.Mapper.Integration
{
    using King.Mapper.Data;
    using King.Mapper.Generated.Sql;
    using King.Mapper.Integration.Model;
    using NUnit.Framework;
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    [TestFixture]
    public class ExecutorTests
    {
        #region Members
        private readonly string connectionString = ConfigurationManager.AppSettings["database"];
        #endregion

        [Test]
        public async Task Insert()
        {
            var random = new Random();
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = new dboSimulatedInsertStatement()
                {
                    TestInt = random.Next(),
                };

                var executor = new Executor(con);
                var results = await executor.NonQuery(sproc);

                Assert.AreEqual(1, results);
            }
        }

        [Test]
        public async Task Select()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var executor = new Executor(con);
                var data = await executor.Query(sproc);

                Assert.IsNotNull(data);

                var obj = data.Model<SelectData>();

                Assert.IsNotNull(obj);
                Assert.AreEqual(sproc.TestInt, obj.Identifier);
                Assert.AreEqual(sproc.TestBigInt, obj.BigInt);
                Assert.AreEqual(sproc.TestBit, obj.Bit);
                Assert.AreEqual(sproc.TestDate.Value.Date, obj.Date.Date);
                Assert.AreEqual(sproc.TestDateTime.Value.Date, obj.DateTime.Date);
                Assert.AreEqual(sproc.TestDateTime2.Value.Date, obj.DateTime2.Date);
                Assert.AreEqual(sproc.TestDecimal, obj.Decimal);
                Assert.AreEqual(sproc.TestFloat, obj.Float);
                Assert.AreEqual(Math.Round((decimal)sproc.TestMoney, 4), obj.Money);
                Assert.AreEqual(sproc.TestNChar, obj.NChar);
                Assert.AreEqual(sproc.TestNText, obj.NText);
                Assert.AreEqual(sproc.TestText, obj.Text);
                CollectionAssert.AreEqual(sproc.TestBinary, obj.Binary);
                CollectionAssert.AreEqual(sproc.TestImage, obj.Image);
                Assert.AreEqual(sproc.TestGuid, obj.Unique);
            }
        }

        [Test]
        public async Task DataReader()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var sproc = SimulatedSelectStatement.Create();

                var executor = new Executor(con);
                var reader = await executor.DataReader(sproc);

                Assert.IsNotNull(reader);
                Assert.IsTrue(reader.Read());

                var obj = reader.Model<SelectData>();

                Assert.IsNotNull(obj);
                Assert.AreEqual(sproc.TestInt, obj.Identifier);
                Assert.AreEqual(sproc.TestBigInt, obj.BigInt);
                Assert.AreEqual(sproc.TestBit, obj.Bit);
                Assert.AreEqual(sproc.TestDate.Value.Date, obj.Date.Date);
                Assert.AreEqual(sproc.TestDateTime.Value.Date, obj.DateTime.Date);
                Assert.AreEqual(sproc.TestDateTime2.Value.Date, obj.DateTime2.Date);
                Assert.AreEqual(sproc.TestDecimal, obj.Decimal);
                Assert.AreEqual(sproc.TestFloat, obj.Float);
                Assert.AreEqual(Math.Round((decimal)sproc.TestMoney, 4), obj.Money);
                Assert.AreEqual(sproc.TestNChar, obj.NChar);
                Assert.AreEqual(sproc.TestNText, obj.NText);
                Assert.AreEqual(sproc.TestText, obj.Text);
                CollectionAssert.AreEqual(sproc.TestBinary, obj.Binary);
                CollectionAssert.AreEqual(sproc.TestImage, obj.Image);
                Assert.AreEqual(sproc.TestGuid, obj.Unique);
            }
        }
    }
}