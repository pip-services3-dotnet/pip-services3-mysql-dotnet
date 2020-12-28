using PipServices3.Commons.Config;
using System.Threading.Tasks;
using Xunit;

namespace PipServices3.MySql.Connect
{
    public class MySqlConnectionResolverTest
    {
        [Fact]
        public async Task TestConnectionConfig()
        {
            var dbConfig = ConfigParams.FromTuples(
                "connection.host", "localhost",
                "connection.port", 1433,
                "connection.database", "test",
                "connection.allowbatch", true,
                "credential.username", "sa",
                "credential.password", "pwd#123"
            );

            var resolver = new MySqlConnectionResolver();
            resolver.Configure(dbConfig);

            var connectionString = await resolver.ResolveAsync(null);
            Assert.Equal("server=localhost;port=1433;database=test;user id=sa;password=pwd#123;allowbatch=True", connectionString);
        }
    }
}
