using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        IFavoriteDal favoriteDal;
        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            this.favoriteDal = favoriteDal;
        }
        public void favoriteDelete(Favorite favorite)
        {
            favoriteDal.delete(favorite);
        }

        public Favorite FavoriteGetById(int id)
        {
            return favoriteDal.get(x => x.favoriteId == id);
        }
        public void favoriteInsert(Favorite favorite)
        {
            favoriteDal.insert(favorite);
        }

        public List<Favorite> favoriteList()
        {
            return favoriteDal.list();
        }

        public void favoriteUpdate(Favorite favorite)
        {
            favoriteDal.update(favorite);
        }
    }
}
