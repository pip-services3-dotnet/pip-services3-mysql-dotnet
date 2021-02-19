using PipServices3.Commons.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipServices3.MySql.Persistence
{
    public class JsonMySqlDummyPersistence: IdentifiableJsonMySqlPersistence<Dummy, string>, IDummyPersistence
    {
        public JsonMySqlDummyPersistence()
            : base("dummies_json")
        {
        }

        protected override void DefineSchema()
        {
            ClearSchema();
            EnsureTable();
            EnsureSchema($"ALTER TABLE `{_tableName}` ADD `data_key` VARCHAR(50) AS (JSON_UNQUOTE(`data`->\"$.key\"))");
            EnsureIndex($"{_tableName}_key", new Dictionary<string, bool> { { "data_key", true } }, new IndexOptions { Unique = true });
        }

        public async Task<DataPage<Dummy>> GetPageByFilterAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await base.GetPageByFilterAsync(correlationId, ComposeFilter(filter), paging, null, null);
        }

        public async Task<long> GetCountByFilterAsync(string correlationId, FilterParams filter)
        {
            return await base.GetCountByFilterAsync(correlationId, ComposeFilter(filter));
        }

        private string ComposeFilter(FilterParams filter)
        {
            filter ??= new FilterParams();
            var key = filter.GetAsNullableString("key");

            var filterCondition = "";
            if (key != null)
                filterCondition += "data->\"$.key\"='" + key + "'";
            
            return filterCondition;
        }
    }
}
