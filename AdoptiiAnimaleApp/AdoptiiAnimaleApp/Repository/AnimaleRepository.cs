using AdoptiiAnimaleApp.Data;
using AdoptiiAnimaleApp.Models.DBObjects;
using AdoptiiAnimaleApp.Models;
using Humanizer;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Security.Cryptography.Xml;

namespace AdoptiiAnimaleApp.Repository
{
    public class AnimaleRepository
    {
        private ApplicationDbContext dbContext;

        public AnimaleRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public AnimaleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AnimaleModel> GetAllAnimales()
        {// Se creeaza o lista pentru a stoca obiectele AnimaleModel rezultate
            List<AnimaleModel> AnimaleList = new List<AnimaleModel>();
            // Se itereaza prin fiecare obiect Animale din colectia din baza de date
            foreach (Animale dbAnimale in dbContext.Animales)
            {
                // Se adauga in lista un obiect AnimaleModel creat prin maparea obiectului din baza de date
                AnimaleList.Add(MapDbObjectToModel(dbAnimale));
            }
            return AnimaleList;
        }

        public AnimaleModel GetAnimaleByID(Guid ID)
        {
            //MapDbObjectToModel converteste obiectul din baza de date într-un obiect AnimaleModel
            return MapDbObjectToModel(dbContext.Animales.FirstOrDefault(x => x.IdAnimal == ID));
        }

        public void InsertAnimale(AnimaleModel animaleModel)
        {
            // Se genereaza un nou identificator unic de tip Guid pentru obiectul AnimaleModel
            animaleModel.IdAnimal = Guid.NewGuid();
            // Se adauga obiectul convertit la obiectul corespunzator din baza de date
            dbContext.Animales.Add(MapModelToDbObject(animaleModel));
            dbContext.SaveChanges();
        }

        public void UpdateAnimale(AnimaleModel animaleModel)
        {// Se cauta un obiect Animale in baza de date cu acelasi IdAnimal ca si in obiectul AnimaleModel
            Animale existingAnimale = dbContext.Animales.FirstOrDefault(x => x.IdAnimal == animaleModel.IdAnimal);
            if (existingAnimale != null)
            {
                existingAnimale.IdAnimal= animaleModel.IdAnimal;
                existingAnimale.Nume = animaleModel.Nume;
                existingAnimale.Specie = animaleModel.Specie;
                existingAnimale.Rasa = animaleModel.Rasa;
                existingAnimale.Varsta = animaleModel.Varsta;
                existingAnimale.Gen = animaleModel.Gen;
                existingAnimale.Descriere = animaleModel.Descriere;
                existingAnimale.Poza = animaleModel.Poza;
                dbContext.SaveChanges();
            }
        }

        public void DeleteAnimale(AnimaleModel animaleModel)
        {
            // Se cauta un obiect Animale in baza de date cu acelasi IdAnimal ca si in obiectul AnimaleModel
            Animale existingAnimale = dbContext.Animales.FirstOrDefault(x => x.IdAnimal == animaleModel.IdAnimal);
            if (existingAnimale != null)
            {
                dbContext.Animales.Remove(existingAnimale);
                dbContext.SaveChanges();
            }
        }
        public void DeleteAnimale(Guid id)
        { // Se cauta un obiect Animale in baza de date cu acelasi IdAnimal ca si identificatorul dat (id)
            Animale existingAnimale = dbContext.Animales.FirstOrDefault(x => x.IdAnimal == id);
            if (existingAnimale != null)
            {
                dbContext.Animales.Remove(existingAnimale);
                dbContext.SaveChanges();
            }
        }

       
        // Metoda MapDbObjectToModel are rolul de a transforma un obiect Animale din baza de date intr-un obiect AnimaleModel.
        private AnimaleModel MapDbObjectToModel(Animale dbAnimale)
        {
            AnimaleModel animaleModel = new AnimaleModel();
            if (dbAnimale != null)
            {
                animaleModel.IdAnimal = dbAnimale.IdAnimal;
                animaleModel.Nume = dbAnimale.Nume;
                animaleModel.Specie = dbAnimale.Specie;
                animaleModel.Rasa = dbAnimale.Rasa;
                animaleModel.Varsta = dbAnimale.Varsta;
                animaleModel.Gen = dbAnimale.Gen;
                animaleModel.Descriere = dbAnimale.Descriere;
                animaleModel.Poza = dbAnimale.Poza;

            }
            return animaleModel;
        }


        // Metoda MapModelToDbObject are rolul de a transforma un obiect AnimaleModel intr-un obiect Animale din baza de date.
        private Animale MapModelToDbObject(AnimaleModel animaleModel)
        {
            Animale animale = new Animale();
            if (animaleModel != null)
            {
                animale.IdAnimal = animaleModel.IdAnimal;
                animale.Nume = animaleModel.Nume;
                animale.Specie = animaleModel.Specie;
                animale.Rasa = animaleModel.Rasa;
                animale.Varsta = animaleModel.Varsta;
                animale.Gen = animaleModel.Gen;
                animale.Descriere = animaleModel.Descriere;
                animale.Poza = animaleModel.Poza;

            }
            return animale;
        }
    }
}
