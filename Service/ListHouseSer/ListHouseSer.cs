using Entities.Model;
using IRepository.IListHouseRep;
using IService.IListHouseSer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.ListHouseSer
{
    public class ListHouseSer:IListHouseSer
    {
        private IListHouseRep _listRep;
        public ListHouseSer(IListHouseRep listRep)
        {
            _listRep = listRep;
        }

        public async Task<bool> DeleteListHouse(object id)
        {
            var result = await _listRep.DeleteListHouse(id);
            return result;
        }

        public async Task<List<List<object>>> GetListHouse()
        {
            var result = await _listRep.GetListHouse();
            return result;
        }

        public async Task<ListHouse> GetListHouseById(object id)
        {
            var result = await _listRep.GetListHouseById(id);
            return result;
        }

        public async Task<bool> InsertUpdateListLand(ListHouse entity)
        {
            var result = await _listRep.SaveListHouse(entity);
            return result;
        }
    }
}
