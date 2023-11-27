using AdoptiiAnimaleApp.Data;
using AdoptiiAnimaleApp.Models.DBObjects;
using AdoptiiAnimaleApp.Models;

namespace AdoptiiAnimaleApp.Repository
{
    public class FavoriteRepository
    {
            private ApplicationDbContext dbContext;

            public FavoriteRepository()
            {
                this.dbContext = new ApplicationDbContext();
            }

            public FavoriteRepository(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public List<FavoriteModel> GetAllFavorites()
            {
                List<FavoriteModel>favoriteList = new List<FavoriteModel>();
                foreach (Favorite dbFavorite in dbContext.Favorites)
                {
                    favoriteList.Add(MapDbObjectToModel(dbFavorite));
                }
                return favoriteList;
            }

            public FavoriteModel GetFavoriteByID(Guid ID)
            {
                return MapDbObjectToModel(dbContext.Favorites.FirstOrDefault(x => x.ID_Favorit == ID));
            }

            public void InsertFavorite(FavoriteModel favoriteModel)
            {
                favoriteModel.IdFavorit = Guid.NewGuid();
                dbContext.Favorites.Add(MapModelToDbObject(favoriteModel));
                dbContext.SaveChanges();
            }

            public void UpdateFavorite(FavoriteModel favoriteModel)
            {
                Favorite existingFavorite = dbContext.Favorites.FirstOrDefault(x => x.ID_Favorit == favoriteModel.IdFavorit);
                if (existingFavorite != null)
                {
                    existingFavorite.ID_Favorit = favoriteModel.IdFavorit;
                    existingFavorite.IdAnimal = favoriteModel.IdAnimal;
                    existingFavorite.DataAdugare = favoriteModel.DataAdugare;
                    existingFavorite.ID_utilizator = favoriteModel.IdUtilizator;
                    dbContext.SaveChanges();
                }
            }

            public void DeleteFavorit(FavoriteModel favoriteModel)
            {
                Favorite existingFavorite = dbContext.Favorites.FirstOrDefault(x => x.IdFavorit == favoriteModel.IdFavorit);
                if (existingFavorite != null)
                {
                    dbContext.Favorites.Remove(existingFavorite);
                    dbContext.SaveChanges();
                }
            }

            private FavoriteModel MapDbObjectToModel(Favorite dbfavorite)
            {
                FavoriteModel favoriteModel = new FavoriteModel();
                if (dbfavorite != null)
                {
                    favoriteModel.IdFavorit = dbfavorite.ID_favorit;
                    favoriteModel.IdAnimal = dbfavorite.IdAnimal;
                    favoriteModel.DataAdugare = dbfavorite.DataAdugare;
                    favoriteModel.IdUtilizator = dbfavorite.ID_utilizator;

                }
                return favoriteModel;
            }

            private Favorite MapModelToDbObject(FavoriteModel favoriteModel)
            {
                Favorite favorite = new Favorite();
                if (favoriteModel != null)
                {
                    favorite.ID_Favorit = favoriteModel.IdFavorit;
                    favorite.IdAnimal = favoriteModel.IdAnimal;
                    favorite.DataAdugare = favoriteModel.DataAdugare;
                    favorite.ID_utilizator = favoriteModel.IdUtilizator;

                }
                return favorite;
            }
    }
}
