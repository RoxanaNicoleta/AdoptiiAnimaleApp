using AdoptiiAnimaleApp.Data;
using AdoptiiAnimaleApp.Models.DBObjects;
using AdoptiiAnimaleApp.Models;

namespace AdoptiiAnimaleApp.Repository
{
    public class UtilizatoriRepository
    {
        private ApplicationDbContext dbContext;

        public UtilizatoriRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public UtilizatoriRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<UtilizatoriModel> GetAllUtilizatori()
        {
            List<UtilizatoriModel> UtilizatoriList = new List<UtilizatoriModel>();
            foreach (Utilizatori dbUtilizatori in dbContext.Utilizatoris)
            {
                UtilizatoriList.Add(MapDbObjectToModel(dbUtilizatori));
            }
            return UtilizatoriList;
        }

        public UtilizatoriModel GetUtilizatoriByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Utilizatoris.FirstOrDefault(x => x.IdUtilizator == ID));
        }

        public void InsertUtilizatori(UtilizatoriModel utilizatoriModel)
        {
            utilizatoriModel.IdUtilizator = Guid.NewGuid();
            dbContext.Utilizatoris.Add(MapModelToDbObject(utilizatoriModel));
            dbContext.SaveChanges();
        }

        public void UpdateUtilizatori(UtilizatoriModel utilizatoriModel)
        {
            Utilizatori existingUtilizatori = dbContext.Utilizatoris.FirstOrDefault(x => x.IdUtilizator == utilizatoriModel.IdUtilizator);
            if (existingUtilizatori != null)
            {
                existingUtilizatori.IdUtilizator = utilizatoriModel.IdUtilizator;
                existingUtilizatori.TipUtilizator = utilizatoriModel.TipUtilizator;
                existingUtilizatori.Nume = utilizatoriModel.Nume;
                existingUtilizatori.Prenume = utilizatoriModel.Prenume;
                existingUtilizatori.Adresa = utilizatoriModel.Adresa;
                existingUtilizatori.Email = utilizatoriModel.Email;
                existingUtilizatori.NrTelefon = utilizatoriModel.NrTelefon;
                existingUtilizatori.Username = utilizatoriModel.Username;
                existingUtilizatori.Parola = utilizatoriModel.Parola;
                dbContext.SaveChanges();
            }
        }

        public void DeleteUtilizatori(UtilizatoriModel utilizatoriModel)
        {
            Utilizatori existingUtilizatori = dbContext.Utilizatoris.FirstOrDefault(x => x.IdUtilizator == utilizatoriModel.IdUtilizator);
            if (existingUtilizatori != null)
            {
                dbContext.Utilizatoris.Remove(existingUtilizatori);
                dbContext.SaveChanges();
            }
        }

        private UtilizatoriModel MapDbObjectToModel(Utilizatori dbUtilizatori)
        {
            UtilizatoriModel utilizatoriModel = new UtilizatoriModel();
            if (dbUtilizatori != null)
            {
                utilizatoriModel.IdUtilizator = dbUtilizatori.IdUtilizator;
                utilizatoriModel.TipUtilizator = dbUtilizatori.TipUtilizator;
                utilizatoriModel.Nume = dbUtilizatori.Nume;
                utilizatoriModel.Prenume = dbUtilizatori.Prenume;
                utilizatoriModel.Adresa = dbUtilizatori.Adresa;
                utilizatoriModel.Email = dbUtilizatori.Email;
                utilizatoriModel.NrTelefon = dbUtilizatori.NrTelefon;
                utilizatoriModel.Username = dbUtilizatori.Username;
                utilizatoriModel.Parola = dbUtilizatori.Parola;

            }
            return utilizatoriModel;
        }

        private Utilizatori MapModelToDbObject(UtilizatoriModel utilizatoriModel)
        {
            Utilizatori utilizatori = new Utilizatori();
            if (utilizatoriModel != null)
            {
                utilizatori.IdUtilizator = utilizatoriModel.IdUtilizator;
                utilizatori.TipUtilizator = utilizatoriModel.TipUtilizator;
                utilizatori.Nume = utilizatoriModel.Nume;
                utilizatori.Prenume = utilizatoriModel.Prenume;
                utilizatori.Adresa = utilizatoriModel.Adresa;
                utilizatori.Email = utilizatoriModel.Email;
                utilizatori.NrTelefon = utilizatoriModel.NrTelefon;
                utilizatori.Username = utilizatoriModel.Username;
                utilizatori.Parola = utilizatoriModel.Parola;

            }
            return utilizatori;
        }
    }
}
