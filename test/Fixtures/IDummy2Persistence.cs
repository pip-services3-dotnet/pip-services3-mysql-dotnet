//using PipServices3.Commons.Data;
//using PipServices3.Data;
//using PipServices3.MySql.Fixtures;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace PipServices3.MySql.Persistence
//{
//    public interface IDummy2Persistence : IGetter<Dummy2, Integer>, IWriter<Dummy2, Integer>, IPartialUpdater<Dummy2, Integer>
//    {
//        Task<DataPage<Dummy2>> GetPageByFilterAsync(string correlationId, FilterParams filter, PagingParams paging);
//        Task<long> GetCountByFilterAsync(string correlationId, FilterParams filter);
//        Task<List<Dummy2>> GetListByIdsAsync(string correlationId, Integer[] ids);
//        Task<Dummy2> SetAsync(string correlationId, Dummy2 item);
//        Task DeleteByIdsAsync(string correlationId, Integer[] ids);
//    }
//}

