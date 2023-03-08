using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IListLandSer
{
    public interface IListLandSer
    {
        Task<List<List<object>>> GetListLand();

        Task<bool> InsertUpdateListLand(ListLand entity);

        Task<ListLand> GetListLandById(object id);
        Task<bool> DeleteListLand(object id);
    }
}
