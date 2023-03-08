using Entities.Model;
using IRepository.IListHomestayRep;
using IService.IListHomestaySer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.ListHomestaySer
{
    public class ListHomestaySer : IListHomestaySer
    {
        private IListHomestayRep _listRep;
        public ListHomestaySer(IListHomestayRep listRep)
        {
            _listRep = listRep;
        }

        public async Task<bool> DeleteListHomestay(object id)
        {
            var result = await _listRep.DeleteListHomestay(id);
            return result;
        }

        public async Task<List<List<object>>> GetListHomestay()
        {
            var result = await _listRep.GetListHomestay();
            return result;
        }

        public async Task<ListHomestay> GetListHomestayById(object id)
        {
            var result = await _listRep.GetListHomestayById(id);
            return result;
        }

        public async Task<bool> InsertUpdateListHomestay(ListHomestay entity)
        {
            var result = await _listRep.SaveListHomestay(entity);
            return result;
        }
    }
}
