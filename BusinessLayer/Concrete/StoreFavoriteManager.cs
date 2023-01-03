using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StoreFavoriteManager : IStoreFavoriteService
    {
        IStoreFavoriteDal storeFavoriteDal;
        public StoreFavoriteManager(IStoreFavoriteDal storeFavoriteDal)
        {
            this.storeFavoriteDal = storeFavoriteDal;
        }

        public void StoreFavoriteDelete(StoreFavorite storeFavorite)
        {
            storeFavoriteDal.delete(storeFavorite);
        }

        public StoreFavorite StoreFavoriteGetById(int id)
        {
            return storeFavoriteDal.get(x => x.StoreFavoriteId == id);
        }

        public void StoreFavoriteInsert(StoreFavorite storeFavorite)
        {
            storeFavoriteDal.insert(storeFavorite);
        }

        public List<StoreFavorite> StoreFavoriteList()
        {
            return storeFavoriteDal.list();
        }

        public void StoreFavoriteUpdate(StoreFavorite storeFavorite)
        {
           storeFavoriteDal.update(storeFavorite);  
        }
    }
}
