using Entities.Model;
using IRepository.IDetailHomestayRep;
using IRepository.IListHomestayRep;
using IService.IDetailHomestaySer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.DetailHomestaySer
{
    public class DetailHomestaySer:IDetailHomestaySer
    {
        private IDetailHomestayRep _detailRep;
        public DetailHomestaySer(IDetailHomestayRep detailRep)
        {
            _detailRep = detailRep;
        }

        public async Task<bool> DeleteDetailHomestay(object id)
        {
            var result = await _detailRep.DeleteDetailHomestay(id);
            return result;
        }

        public async Task<DetailHomestay> GetDetailHomestayById(object id)
        {
            var result = await _detailRep.GetDetailHomestayById(id);
            return result;
        }

        public async Task<List<List<object>>> GetListDetailHomestay()
        {
            var result = await _detailRep.GetListDetailHomestay();
            return result;
        }

        public async Task<bool> InsertUpdateDetailHomestay(DetailHomestay entity)
        {
            var result = await _detailRep.SaveDetailHomestay(entity);
            return result;
        }
    }
}
