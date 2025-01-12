using ZooServer.Models;
using Microsoft.EntityFrameworkCore;
using ZooServer.Models;


namespace ZooServer.Accessors {

    public class DataGetter {
        public static string[] ALLOWED_TYPES = { "InspekcjeZagród", "InspekcjeZdrowia", "Karmienia" };

        AnimalCareContext db;
        public DataGetter(AnimalCareContext db) { this.db = db; }

        public Konta FindAccount(string login) {
            var accounts = (from Konta konto in db.Konta
                            where konto.Login == login
                            select konto).ToList();
            return accounts[0];
        }

        //todo
        public List<string> FindCompleted(string TypHistorii, int IDPracownika = -1) {


            if (!ALLOWED_TYPES.Contains(TypHistorii))
            {
                throw new ArgumentException("Typ historii jest nieprawidłowy.");
            }

            var query = from obowiązek in db.Obowiązki
                        where Obowiązki.TypHistorii == TypHistorii && Obowiązki.DataZakończenia != null
                        select Obowiązki


               if (IDPracownika != -1)
            {
                query = query.Where(o => o.IDPracownika == IDPracownika);
            }

            return query.ToList();


         
        }

        public List<string> HistoryWithRange( String TypHistori , String TypId, int ID = -1, DateTime Date1, DateTime Date2)
        {
            if (!ALLOWED_TYPES.Contains(TypHistori))
            {
                throw new ArgumentException("Typ historii jest nieprawidłowy.");
            }

            Type entityType = Type.GetType($"ZooServer.Models.{TypHistori}");

            if (entityType == null)
            {
                throw new ArgumentException("Nie znaleziono typu dla tej historii.");
            }

            var query = db.Set(entityType).AsQueryable();

            query = query.Where("TypId == @0 && Data >= @1 && Data <= @2", TypId, Date1, Date2);



            return query.ToList().Select(x => x.ToString()).ToList();



        }

        public List<string> History(string TypID, int ID = -1)
        {

            if (!ALLOWED_TYPES.Contains(TypID))
            {
                throw new ArgumentException("Typ historii jest nieprawidłowy.");
            }

            Type entityType = Type.GetType($"ZooServer.Models.{TypID}");

            var query = db.Set(entityType).AsQueryable();

            if (ID != -1)
            {
                query = query.Where("IdZwierzęcia == @0", ID);
            }



            return query.ToList().Select(x => x.ToString()).ToList();


        }




    }


=======
>>>>>>> 4f41559f4230931dd74de9b4bb20e4de4636c43a
    internal class Testing {
        static void Main(string[] args) {
            AnimalCareContext db = new AnimalCareContext();
            DataGetter test = new DataGetter(db);

        }
    }
}
