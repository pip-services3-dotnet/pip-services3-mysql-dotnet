using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
using PipServices3.MySql.Connect;

namespace PipServices3.MySql.Build
{
    /// <summary>
    /// Creates MySql components by their descriptors.
    /// </summary>
    /// See <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_build_1_1_factory.html">Factory</a>, 
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-mysql-dotnet/class_pip_services3_1_1_sql_server_1_1_persistence_1_1_sql_server_connection.html">MySqlConnection</a>
    public class DefaultMySqlFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services", "factory", "mysql", "default", "1.0");
        public static Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "mysql", "default", "1.0");
        public static Descriptor MySqlConnection3Descriptor = new Descriptor("pip-services3", "connection", "mysql", "*", "1.0");
        public static Descriptor MySqlConnectionDescriptor = new Descriptor("pip-services", "connection", "mysql", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultMySqlFactory()
        {
            RegisterAsType(MySqlConnection3Descriptor, typeof(MySqlConnection));
            RegisterAsType(MySqlConnectionDescriptor, typeof(MySqlConnection));
        }
    }
}
