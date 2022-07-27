using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;
using PipServices3.MySql.Connect;
using PipServices3.MySql.Fixtures;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PipServices3.MySql.Persistence
{
	/// <summary>
	/// Unit tests for the <c>MySqlDummyConnectionTest</c> class
	/// </summary>
	[Collection("Sequential")]
	public class MySqlDummyConnectionTest : IDisposable
	{
		private MySqlConnection connection { get; }
		private MySqlDummyPersistence persistence { get; }
		private DummyPersistenceFixture fixture { get;  }

		private string mysqlUri;
		private string mysqlHost;
		private string mysqlPort;
		private string mysqlDatabase;
		private string mysqlUsername;
		private string mysqlPassword;

		public MySqlDummyConnectionTest()
		{
			connection = new MySqlConnection();

			mysqlUri = Environment.GetEnvironmentVariable("MYSQL_URI");
			mysqlHost = Environment.GetEnvironmentVariable("MYSQL_HOST") ?? "localhost";
			mysqlPort = Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3306";
			mysqlDatabase = Environment.GetEnvironmentVariable("MYSQL_DB") ?? "test";
			mysqlUsername = Environment.GetEnvironmentVariable("MYSQL_USER") ?? "user";
			mysqlPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "password";
			if (mysqlUri == null && mysqlHost == null)
				return;

			if (connection == null) return;

			connection.Configure(ConfigParams.FromTuples(
				"connection.uri", mysqlUri,
				"connection.host", mysqlHost,
				"connection.port", mysqlPort,
				"connection.database", mysqlDatabase,
				"credential.username", mysqlUsername,
				"credential.password", mysqlPassword
			));

			persistence = new MySqlDummyPersistence();

			persistence.SetReferences(References.FromTuples(
				new Descriptor("pip-services", "connection", "mysql", "default", "1.0"), connection
			));

			fixture = new DummyPersistenceFixture(persistence);

			connection.OpenAsync(null).Wait();
			persistence.OpenAsync(null).Wait();
			persistence.ClearAsync(null).Wait();
		}

		public void Dispose()
		{
			persistence.CloseAsync(null).Wait();
			connection.CloseAsync(null).Wait();
		}

		[Fact]
		public void TestConnection()
		{
			Assert.True(connection.GetConnection() != null);
			Assert.True(connection.GetDatabaseName() != "");
		}

		[Fact]
		public async Task TestCrudOperations()
		{
			await fixture.TestCrudOperationsAsync();
		}

		[Fact]
		public async Task TestBatchOperations()
		{
			await fixture.TestBatchOperationsAsync();
		}
	}
}
