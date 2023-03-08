using Entities.Model;
using IRepository.IDetailLandRep;
using IService.IDetailLandSer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.DetailLandSer
{
    public class DetailLandSer : IDetailLandSer
    {
        private IDetailLandRep _detailRep;
        public DetailLandSer(IDetailLandRep detailRep)
        {
            _detailRep = detailRep;
        }

        public async Task<bool> DeleteDetailLand(object id)
        {
            var result = await _detailRep.DeleteDetailLand(id);
            return result;
        }

        public async Task<DetailLand> GetDetailLandById(object id)
        {
            var result = await _detailRep.GetDetailLandById(id);
            return result;
        }

        public async Task<List<List<object>>> GetListDetailLand()
        {
            var result = await _detailRep.GetListDetailLand();
            return result;
        }

        public async Task<bool> InsertUpdateDetailLand(DetailLand entity)
        {
            var result = await _detailRep.SaveDetailLand(entity);
            return result;
        }
    }
}
