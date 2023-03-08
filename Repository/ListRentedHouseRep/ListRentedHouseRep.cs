using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IListRentedHouseRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ListRentedHouseRep
{
    public class ListRentedHouseRep : BaseRepository, IListRentedHouseRep
    {
        private IOptions<AppSetting> _setting;
        public ListRentedHouseRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }
        public async Task<List<List<object>>> GetListRentedHouse()
        {
            var proc = "LIST_RENTED_HOUSE_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(ListRentedHouse) }, proc);
            return result;
        }

        public async Task<bool> SaveListRentedHouse(ListRentedHouse entity)
        {
            var proc = "LIST_RENTED_HOUSE_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, entity);
            return result;
        }

        public async Task<ListRentedHouse> GetListRentedHouseById(object id)
        {
            var proc = "LIST_RENTED_HOUSE_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<ListRentedHouse>(proc, id);
            return result;
        }

        public async Task<bool> DeleteListRentedHouse(object id)
        {
            var proc = "LIST_RENTED_HOUSE_DELETE";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }     
    }
}
