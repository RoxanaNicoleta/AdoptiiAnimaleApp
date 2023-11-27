using AdoptiiAnimaleApp.Data;
using AdoptiiAnimaleApp.Models.DBObjects;
using AdoptiiAnimaleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdoptiiAnimaleApp.Repository
{
    public class AdoptiiRepository
    {
        private ApplicationDbContext dbContext;

        public AdoptiiRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public AdoptiiRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AdoptiiModel> GetAllAdoptii()
        {
            List<AdoptiiModel> adoptiiList = new List<AdoptiiModel>();
            foreach (Adoptii dbAdoptie in dbContext.Adoptiis)
            {
                adoptiiList.Add(MapDbObjectToModel(dbAdoptie));
            }
            return adoptiiList;
        }

        public AdoptiiModel GetAdoptieByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Adoptiis.FirstOrDefault(x => x.Id_adoptie == ID));
        }

        public void InsertAdoptie(AdoptiiModel adoptieModel)
        {
            adoptieModel.IdAdoptie = Guid.NewGuid();
            dbContext.Adoptiis.Add(MapModelToDbObject(adoptieModel));
            dbContext.SaveChanges();
        }

        public void UpdateAdoptie(AdoptiiModel adoptieModel)
        {
            Adoptii existingAdoptie = dbContext.Adoptiis.FirstOrDefault(x => x.Id_adoptie == adoptieModel.IdAdoptie);
            if (existingAdoptie != null)
            {
                existingAdoptie.Id_adoptie = adoptieModel.IdAdoptie;
                existingAdoptie.IdAnimal = adoptieModel.IdAnimal;
                existingAdoptie.DataAdoptiei = adoptieModel.DataAdoptiei;
                existingAdoptie.StatusAdoptie = adoptieModel.StatusAdoptie;
                dbContext.SaveChanges();
            }
        }

        public void DeleteAdoptie(AdoptiiModel adoptieModel)
        {
            Adoptii existingAdoptie = dbContext.Adoptiis.FirstOrDefault(x => x.Id_adoptie == adoptieModel.IdAdoptie);
            if (existingAdoptie != null)
            {
                dbContext.Adoptiis.Remove(existingAdoptie);
                dbContext.SaveChanges();
            }
        }

        private AdoptiiModel MapDbObjectToModel(Adoptii dbAdoptie)
        {
            AdoptiiModel adoptieModel = new AdoptiiModel();
            if (dbAdoptie != null)
            {
                adoptieModel.IdAdoptie = dbAdoptie.Id_adoptie;
                adoptieModel.IdAnimal = dbAdoptie.IdAnimal;
                adoptieModel.DataAdoptiei = dbAdoptie.DataAdoptiei;
                adoptieModel.StatusAdoptie = dbAdoptie.StatusAdoptie;

            }
            return adoptieModel;
        }

        private Adoptii MapModelToDbObject(AdoptiiModel adoptieModel)
        {
            Adoptii adoptie = new Adoptii();
            if (adoptieModel != null)
            {
                adoptie.Id_adoptie = adoptieModel.IdAdoptie;
                adoptie.IdAnimal = adoptieModel.IdAnimal;
                adoptie.DataAdoptiei = adoptieModel.DataAdoptiei;
                adoptie.StatusAdoptie = adoptieModel.StatusAdoptie;

            }
            return adoptie;
        }
    }
}
