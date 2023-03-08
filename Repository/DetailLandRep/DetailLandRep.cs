using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IDetailLandRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DetailLandRep
{
    public class DetailLandRep : BaseRepository, IDetailLandRep
    {
        private IOptions<AppSetting> _setting;
        public DetailLandRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }

        public async Task<bool> DeleteDetailLand(object id)
        {
            var proc = "DETAIL_LAND_DELETE";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }

        public async Task<DetailLand> GetDetailLandById(object id)
        {
            var proc = "DETAIL_LAND_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<DetailLand>(proc, id);
            return result;
        }

        public async Task<List<List<object>>> GetListDetailLand()
        {
            var proc = "DETAIL_LAND_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(DetailLand) }, proc);
            return result;
        }

        public async Task<bool> SaveDetailLand(DetailLand entity)
        {
            var proc = "DETAIL_LAND_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, entity);
            return result;
        }
    }
}
