using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IDetailHouseRep
{
    public interface IDetailHouseRep
    {
        Task<List<List<object>>> GetListDetailHouse();

        Task<bool> SaveDetailHouse(DetailHouse entity);

        Task<DetailHouse> GetDetailHouseById(object id);

        Task<bool> DeleteDetailHouse(object id);
    }
}
