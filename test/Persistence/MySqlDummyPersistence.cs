﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PipServices3.Commons.Data;

namespace PipServices3.MySql.Persistence
{
	public class MySqlDummyPersistence : IdentifiableMySqlPersistence<Dummy, string>, IDummyPersistence
    {
        public MySqlDummyPersistence()
            : base("dummies")
        {
        }

        protected override void DefineSchema()
        {
            ClearSchema();
            EnsureSchema($"CREATE TABLE `{_tableName}` (`id` VARCHAR(32) PRIMARY KEY, `key` VARCHAR(50), `content` TEXT, `create_time_utc` DATETIME, `sub_dummy` TEXT)");
            EnsureIndex($"{_tableName}_key", new Dictionary<string, bool> { { "key", true } }, new IndexOptions { Unique = true });
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
                filterCondition += string.Format("{0}='{1}'", QuoteIdentifier("key"), key);
            return filterCondition;
        }
    }
}