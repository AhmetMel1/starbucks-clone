using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStoreFavoriteService
    {
        void StoreFavoriteInsert(StoreFavorite storeFavorite);
        void StoreFavoriteDelete(StoreFavorite storeFavorite);
        void StoreFavoriteUpdate(StoreFavorite storeFavorite);
        List<StoreFavorite> StoreFavoriteList();
        StoreFavorite StoreFavoriteGetById(int id);
    }
}
