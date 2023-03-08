using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IListRentedHouseSer
{
    public interface IListRentedHouseSer
    {
        Task<List<List<object>>> GetListRentedHouse();

        Task<bool> InsertUpdateListRentedHouse(ListRentedHouse entity);

        Task<ListRentedHouse> GetListRentedHouseById(object id);
        Task<bool> DeleteListRentedHouse(object id);
    }
}
