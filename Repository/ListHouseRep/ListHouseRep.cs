using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IListHouseRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ListHouseRep
{
    public class ListHouseRep : BaseRepository, IListHouseRep
    {
        private IOptions<AppSetting> _setting;
        public ListHouseRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }
        public async Task<List<List<object>>> GetListHouse()
        {
            var proc = "LIST_HOUSE_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(ListHouse) }, proc);
            return result;
        }

        public async Task<bool> SaveListHouse(ListHouse entity)
        {
            var proc = "LIST_HOUSE_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, entity);
            return result;
        }

        public async Task<ListHouse> GetListHouseById(object id)
        {
            var proc = "LIST_HOUSE_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<ListHouse>(proc, id);
            return result;
        }

        public async Task<bool> DeleteListHouse(object id)
        {
            var proc = "LIST_HOUSE_DELETE";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }
    }
}
