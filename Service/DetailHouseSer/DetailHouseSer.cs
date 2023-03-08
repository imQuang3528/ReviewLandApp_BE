using Entities.Model;
using IRepository.IDetailHouseRep;
using IRepository.IListLandRep;
using IService.IDetailHouseSer;
using IService.IListLandSer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.DetailHouseSer
{
    public class DetailHouseSer : IDetailHouseSer
    {
        private IDetailHouseRep _detailRep;
        public DetailHouseSer(IDetailHouseRep detailRep)
        {
            _detailRep = detailRep;
        }

        public async Task<bool> DeleteDetailHouse(object id)
        {
            var result = await _detailRep.DeleteDetailHouse(id);
            return result;
        }

        public async Task<List<List<object>>> GetListDetailHouse()
        {
            var result = await _detailRep.GetListDetailHouse();
            return result;
        }

        public async Task<DetailHouse> GetListDetailHouseId(object id)
        {
            var result = await _detailRep.GetDetailHouseById(id);
            return result;
        }

        public async Task<bool> InsertUpdateDetailHouse(DetailHouse entity)
        {
            var result = await _detailRep.SaveDetailHouse(entity);
            return result;
        }
    }
}
