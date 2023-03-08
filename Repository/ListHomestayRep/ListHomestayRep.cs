using Dapper;
using Entities.AppSetting;
using Entities.Model;
using IRepository.IListHomestayRep;
using Microsoft.Extensions.Options;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ListHomestayRep
{
    public class ListHomestayRep : BaseRepository, IListHomestayRep
    {
        private IOptions<AppSetting> _setting;
        public ListHomestayRep(IOptions<AppSetting> setting) : base(setting)
        {
            this._setting = setting;
        }

        public async Task<bool> DeleteListHomestay(object id)
        {
            var proc = "LIST_HOMESTAY_DELETE";
            var result = await ExecuteUsingStoreProcedure(proc, id);
            return result;
        }

        public async Task<List<List<object>>> GetListHomestay()
        {
            var proc = "LIST_HOMESTAY_GET_LIST";
            var result = await QueryMultipleUsingStoreProcedure(new List<Type>() { typeof(ListHomestay) }, proc);
            return result;
        }

        public async Task<ListHomestay> GetListHomestayById(object id)
        {
            var proc = "LIST_HOMESTAY_GET_BY_ID";
            var result = await QuerySingleUsingStoreProcedure<ListHomestay>(proc, id);
            return result;
        }

        public async Task<bool> SaveListHomestay(ListHomestay entity)
        {
            var proc = "LIST_HOMESTAY_INSERT";
            var result = await ExecuteUsingStoreProcedure(proc, entity);
            return result;
        }
    }
}
