using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IListHomestayRep
{
    public interface IListHomestayRep
    {
        Task<List<List<object>>> GetListHomestay();

        Task<bool> SaveListHomestay(ListHomestay entity);

        Task<ListHomestay> GetListHomestayById(object id);

        Task<bool> DeleteListHomestay(object id);
    }
}
