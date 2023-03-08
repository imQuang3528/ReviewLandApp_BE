using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IDetailHomestayRep
{
    public interface IDetailHomestayRep
    {
        Task<List<List<object>>> GetListDetailHomestay();

        Task<bool> SaveDetailHomestay(DetailHomestay entity);

        Task<DetailHomestay> GetDetailHomestayById(object id);

        Task<bool> DeleteDetailHomestay(object id);
    }
}
