using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IListHomestaySer
{
    public interface IListHomestaySer
    {
        Task<List<List<object>>> GetListHomestay();

        Task<bool> InsertUpdateListHomestay(ListHomestay entity);

        Task<ListHomestay> GetListHomestayById(object id);
        Task<bool> DeleteListHomestay(object id);
    }
}
