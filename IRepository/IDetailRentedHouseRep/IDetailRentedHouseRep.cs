using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IDetailRentedHouseRep
{
    public interface IDetailRentedHouseRep
    {
        Task<List<List<object>>> GetListDetailRentedHouse();

        Task<bool> SaveDetailRentedHouse(DetailRentedHouse entity);

        Task<DetailRentedHouse> GetDetailRentedHouseById(object id);

        Task<bool> DeleteDetailRentedHouse(object id);
    }
}
