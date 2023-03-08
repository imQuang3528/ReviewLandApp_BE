using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IListLandRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ListLandRep
{
    public class ListLandRep : BaseRepository, IListLandRep
    {
        private IOptions<AppSetting> _setting;
        public ListLandRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }
        public async Task<List<List<object>>> GetListLand()
        {
            var proc = "GET_LIST_LAND";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(ListLand)}, proc);
            return result;
        }

        public async Task<bool> SaveListLand(ListLand entity)
        {
            var proc = "INSERT_UPDATE_LISTLAND";
            var result = await ExecuteStoreUsingDynamicParam(proc, entity);
            return result;
        }

        public async Task<ListLand> GetListLandById(object id)
        {
            var proc = "GET_LIST_LAND_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<ListLand>(proc, id);
            return result;
        }

        public async Task<bool> DeleteListLand(object id)
        {
            var proc = "DELETE_LIST_LAND";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }
    }
}
