using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.IDetailHomestaySer
{
    public interface IDetailHomestaySer
    {
        Task<List<List<object>>> GetListDetailHomestay();

        Task<bool> InsertUpdateDetailHomestay(DetailHomestay entity);

        Task<DetailHomestay> GetDetailHomestayById(object id);
        Task<bool> DeleteDetailHomestay(object id);
    }
}
