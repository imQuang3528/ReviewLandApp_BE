using Entities.Model;
using IRepository.IListLandRep;
using IService.IListLandSer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.ListLandSer
{
    public class ListLandSer: IListLandSer
    {
        private IListLandRep _listLandRep;
        public ListLandSer(IListLandRep listLandRep)
        {
            _listLandRep = listLandRep;
        }

        public async Task<bool> DeleteListLand(object id)
        {
            var result = await _listLandRep.DeleteListLand(id);
            return result;
        }

        public async Task<List<List<object>>> GetListLand()
        {
            var result = await _listLandRep.GetListLand();
            return result;
        }

        public async Task<ListLand> GetListLandById(object id)
        {
            var result = await _listLandRep.GetListLandById(id);
            return result;
        }

        public async Task<bool> InsertUpdateListLand(ListLand entity)
        {
            if (entity.IdListLand == null)
            {
                entity.IdListLand = Guid.NewGuid().ToString();
                entity.EntityStatus = 0;
                entity.IdCateReview = Guid.NewGuid().ToString();
                entity.CreatedDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
            }
            else
            {
                entity.EntityStatus = 1;
                entity.UpdateDate = DateTime.Now;
            }
            var result = await _listLandRep.SaveListLand(entity);
            return result;
        }
    }
}
