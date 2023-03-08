using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IListRentedHouseRep
{
    public interface IListRentedHouseRep
    {
        Task<List<List<object>>> GetListRentedHouse();

        Task<bool> SaveListRentedHouse(ListRentedHouse entity);

        Task<ListRentedHouse> GetListRentedHouseById(object id);

        Task<bool> DeleteListRentedHouse(object id);
    }
}
