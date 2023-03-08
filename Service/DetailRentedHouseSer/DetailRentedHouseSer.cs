using Entities.Model;
using IRepository.IDetailRentedHouseRep;
using IRepository.IListLandRep;
using IService.IDetailRentedHouseSer;
using IService.IListLandSer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.DetailRentedHouseSer
{
    public class DetailRentedHouseSer : IDetailRentedHouseSer
    {
        private IDetailRentedHouseRep _detailRep;
        public DetailRentedHouseSer(IDetailRentedHouseRep detailRep)
        {
            _detailRep = detailRep;
        }

        public async Task<bool> DeleteDetailRentedHouse(object id)
        {
            var result = await _detailRep.DeleteDetailRentedHouse(id);
            return result;
        }

        public async Task<List<List<object>>> GetDetailRentedHouse()
        {
            var result = await _detailRep.GetListDetailRentedHouse();
            return result;
        }

        public async Task<DetailRentedHouse> GetDetailRentedHouseById(object id)
        {
            var result = await _detailRep.GetDetailRentedHouseById(id);
            return result;
        }

        public async Task<bool> InsertUpdateDetailRentedHouse(DetailRentedHouse entity)
        {
            var result = await _detailRep.SaveDetailRentedHouse(entity);
            return result;
        }
    }
}
