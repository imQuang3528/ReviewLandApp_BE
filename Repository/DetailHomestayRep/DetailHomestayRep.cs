using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IDetailHomestayRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.DetailHomestayRep
{
    public class DetailHomestayRep : BaseRepository, IDetailHomestayRep
    {
        private IOptions<AppSetting> _setting;
        public DetailHomestayRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }

        public async Task<List<List<object>>> GetListDetailHomestay()
        {
            var proc = "DETAIL_HOMESTAY_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(DetailHomestay) }, proc);
            return result;
        }

        public async Task<bool> SaveDetailHomestay(DetailHomestay entity)
        {
            var proc = "DETAIL_HOMESTAY_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, entity);
            return result;
        }

        public async Task<DetailHomestay> GetDetailHomestayById(object id)
        {
            var proc = "DETAIL_HOMESTAY_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<DetailHomestay>(proc, id);
            return result;
        }

        public async Task<bool> DeleteDetailHomestay(object id)
        {
            var proc = "DETAIL_HOMESTAY_DELETE_BY_ID";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }
    }
}
