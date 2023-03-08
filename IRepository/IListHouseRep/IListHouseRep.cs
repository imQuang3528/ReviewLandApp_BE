using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IListHouseRep
{
    public interface IListHouseRep
    {
        Task<List<List<object>>> GetListHouse();

        Task<bool> SaveListHouse(ListHouse entity);

        Task<ListHouse> GetListHouseById(object id);

        Task<bool> DeleteListHouse(object id);
    }
}
