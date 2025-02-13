using ZooServer.Models;
using Microsoft.EntityFrameworkCore;


namespace ZooServer.Accessors {

    public class DataGetter {
        public static string[] ALLOWED_TYPES = { "InspekcjeZagród", "InspekcjeZdrowia", "Karmienia" };

        AnimalCareContext db;
        public DataGetter(AnimalCareContext db) {this.db = db; }

        public Konta FindAccount(string login) {
            var accounts = (from Konta konto in db.Konta
                            where konto.Login == login
                            select konto).ToList();
            return accounts[0];
        }

        public List<Obowiązki> FindCompleted(List<Obowiązki> obowiązki) {
            var query = from obowiązek in obowiązki
                        where obowiązek.DataZakończenia != null
                        select obowiązek;

            return query.ToList();
        }

        public List<Karmienia> MapToKarmienia(List<Obowiązki> obowiązki) {
            DbSet<Karmienia> karmienia = db.Karmienia;
            var history = from obowiązek in obowiązki
                          join karmienie in karmienia on obowiązek.IDObowiązku equals karmienie.IDObowiązku
                          select karmienie;
            return history.ToList();
        }

        public List<InspekcjeZagród> MapToInspekcjeZagród(List<Obowiązki> obowiązki) {
            DbSet<InspekcjeZagród> inspekcje = db.InspekcjeZagród;
            var history = from obowiązek in obowiązki
                          join inspekcja in inspekcje on obowiązek.IDObowiązku equals inspekcja.IDObowiązku
                          select inspekcja;
            return history.ToList();
        }

        public List<InspekcjeZdrowia> MapToInspekcjeZdrowia(List<Obowiązki> obowiązki) {
            DbSet<InspekcjeZdrowia> inspekcje = db.InspekcjeZdrowia;
            var history = from obowiązek in obowiązki
                          join inspekcja in inspekcje on obowiązek.IDObowiązku equals inspekcja.IDObowiązku
                          select inspekcja;
            return history.ToList();
        }

        public List<Obowiązki> FindByDate(List<Obowiązki> obowiązki, DateTime Date1, DateTime Date2) {
            var obow = from Obowiązki obowiązek in obowiązki
                       where obowiązek.DataZakończenia != null && obowiązek.DataZakończenia >= Date1 && obowiązek.DataZakończenia < Date2
                       select obowiązek;
            return obow.ToList();
        }

        public List<Obowiązki> FindByPracownik(List<Obowiązki> obowiązki, int IDPracownika) {
            var obow = from obowiązek in obowiązki
                       where obowiązek.IDPracownika == IDPracownika
                       select obowiązek;
            return obow.ToList();
        }

    }


    public class Testing
    {
        public static void Main(string[] args)
        {
           
        }
    }

}
    

