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
            if (entity.ID_LIST_LAND == null)
            {
                entity.ID_LIST_LAND = Guid.NewGuid().ToString();
                entity.ENTITY_STATUS = 0;
                entity.ID_CATE_REVIEW = Guid.NewGuid().ToString();
                entity.CREATED_DATE = DateTime.Now;
                entity.UPDATED_DATE = DateTime.Now;
            }
            else
            {
                entity.ENTITY_STATUS = 1;
                entity.UPDATED_DATE = DateTime.Now;
            }
            var result = await _listLandRep.SaveListLand(entity);
            return result;
        }
    }
}
