using Entities.Model;
using IRepository.IListLandRep;
using IRepository.IListRentedHouseRep;
using IService.IListLandSer;
using IService.IListRentedHouseSer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.ListLandSer
{
    public class ListRentedHouseSer : IListRentedHouseSer
    {
        private IListRentedHouseRep _listRentedHouseRep;
        public ListRentedHouseSer(IListRentedHouseRep listRentedHouseRep)
        {
            this._listRentedHouseRep = listRentedHouseRep;
        }
        public async Task<bool> DeleteListRentedHouse(object id)
        {
            var result = await _listRentedHouseRep.DeleteListRentedHouse(id);
            return result;
        }

        public async Task<List<List<object>>> GetListRentedHouse()
        {
            var result = await _listRentedHouseRep.GetListRentedHouse();
            return result;
        }

        public async Task<ListRentedHouse> GetListRentedHouseById(object id)
        {
            var result = await _listRentedHouseRep.GetListRentedHouseById(id);
            return result;
        }

        public async Task<bool> InsertUpdateListRentedHouse(ListRentedHouse entity)
        {
            var result = await _listRentedHouseRep.SaveListRentedHouse(entity);
            return result;
        }
    }
}
