using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IDetailLandRep
{
    public interface IDetailLandRep
    {
        Task<List<List<object>>> GetListDetailLand();

        Task<bool> SaveDetailLand(DetailLand entity);

        Task<DetailLand> GetDetailLandById(object id);

        Task<bool> DeleteDetailLand(object id);
    }
}
