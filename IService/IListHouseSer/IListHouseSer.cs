using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IListHouseSer
{
    public interface IListHouseSer
    {
        Task<List<List<object>>> GetListHouse();

        Task<bool> InsertUpdateListLand(ListHouse entity);

        Task<ListHouse> GetListHouseById(object id);
        Task<bool> DeleteListHouse(object id);
    }
}
