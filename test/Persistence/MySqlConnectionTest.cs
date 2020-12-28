using PipServices3.Commons.Config;
using System;
using Xunit;

namespace PipServices3.MySql.Persistence
{
	/// <summary>
	/// Unit tests for the <c>MySqlConnectionTest</c> class
	/// </summary>
	[Collection("Sequential")]
	public class MySqlConnectionTest : IDisposable
	{
		private MySqlConnection Db { get; }

		private string mysqlUri;
		private string mysqlHost;
		private string mysqlPort;
		private string mysqlDatabase;
		private string mysqlUsername;
		private string mysqlPassword;

		public MySqlConnectionTest()
		{
			Db = new MySqlConnection();

			mysqlUri = Environment.GetEnvironmentVariable("MYSQL_URI");
			mysqlHost = Environment.GetEnvironmentVariable("MYSQL_HOST") ?? "localhost";
			mysqlPort = Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3306";
			mysqlDatabase = Environment.GetEnvironmentVariable("MYSQL_DB") ?? "test";
			mysqlUsername = Environment.GetEnvironmentVariable("MYSQL_USER") ?? "user";
			mysqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "mysql";
			if (mysqlUri == null && mysqlHost == null)
				return;

			if (Db == null) return;
		}

		public void Dispose()
		{
			Db.CloseAsync(null).Wait();
		}

		[Fact]
		public void TestOpenAsync_Success()
		{
			Db.Configure(ConfigParams.FromTuples(
				"connection.uri", mysqlUri,
				"connection.host", mysqlHost,
				"connection.port", mysqlPort,
				"connection.database", mysqlDatabase,
				"credential.username", mysqlUsername,
				"credential.password", mysqlPassword
			));

			Db.OpenAsync(null).Wait();

			var actual = Db.IsOpen();

			Assert.True(actual);
		}

		//[Fact]
		//public void TestOpenAsync_Failure()
		//{
		//    Db.CloseAsync(null).Wait();

		//    Db.Configure(ConfigParams.FromTuples(
		//        "connection.uri", mysqlUri,
		//        "connection.host", mysqlHost,
		//        "connection.port", "1234",
		//        "connection.database", mysqlDatabase
		//    ));

		//    var ex = Assert.Throws<AggregateException>(() => Db.OpenAsync(null).Wait());
		//    Assert.Equal("Connection to mysql failed", ex.InnerException.Message);
		//}
	}
}
