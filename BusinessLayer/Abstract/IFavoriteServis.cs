using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFavoriteServis
    {
        void favoriteInsert(Favorite favorite);
        void favoriteDelete(Favorite favorite);
        void favoriteUpdate(Favorite favorite);
        List<Favorite> favoriteList();
        Favorite FavoriteGetById(int id);
        Favorite FavoriteGetByUploadDate(DateTime uploadDate);

    }
}
