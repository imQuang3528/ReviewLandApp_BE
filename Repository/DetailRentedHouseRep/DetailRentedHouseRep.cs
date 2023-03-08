using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IDetailRentedHouseRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ListLandRep
{
    public class DetailRentedHouseRep : BaseRepository, IDetailRentedHouseRep
    {
        private IOptions<AppSetting> _setting;
        public DetailRentedHouseRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }

        public async Task<bool> DeleteDetailRentedHouse(object id)
        {
            var proc = "DETAIL_RENTED_HOUSE_DELETE";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }

        public async Task<DetailRentedHouse> GetDetailRentedHouseById(object id)
        {
            var proc = "DETAIL_RENTED_HOUSE_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<DetailRentedHouse>(proc, id);
            return result;
        }

        public async Task<List<List<object>>> GetListDetailRentedHouse()
        {
            var proc = "DETAIL_RENTED_HOUSE_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(DetailRentedHouse) }, proc);
            return result;
        }

        public async Task<bool> SaveDetailRentedHouse(DetailRentedHouse entity)
        {
            var proc = "DETAIL_RENTED_HOUSE_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, entity);
            return result;
        }
    }
}
