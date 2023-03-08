using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IDetailHouseRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.DetailHouseRep
{
    public class DetailHouseRep : BaseRepository, IDetailHouseRep
    {
        private IOptions<AppSetting> _setting;
        public DetailHouseRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }

        public async Task<bool> DeleteDetailHouse(object id)
        {
            var proc = "DETAIL_HOUSE_DELETE_BY_ID";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }

        public async Task<DetailHouse> GetDetailHouseById(object id)
        {
            var proc = "DETAIL_HOUSE_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<DetailHouse>(proc, id);
            return result;
        }

        public async Task<List<List<object>>> GetListDetailHouse()
        {
            var proc = "DETAIL_HOUSE_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(DetailHouse) }, proc);
            return result;
        }

        public async Task<bool> SaveDetailHouse(DetailHouse entity)
        {
            var proc = "DETAIL_HOUSE_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, entity);
            return result;
        }
    }
}
