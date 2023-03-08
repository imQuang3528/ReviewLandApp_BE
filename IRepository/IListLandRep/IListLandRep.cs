using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IListLandRep
{
    public interface IListLandRep
    {
        Task<List<List<object>>> GetListLand();

        Task<bool> SaveListLand(ListLand entity);

        Task<ListLand> GetListLandById(object id);

        Task<bool> DeleteListLand(object id);
    }
}
