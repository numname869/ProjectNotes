using ZooServer.Models;
using Microsoft.EntityFrameworkCore;


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
            return null;
        }

        
    }
}
