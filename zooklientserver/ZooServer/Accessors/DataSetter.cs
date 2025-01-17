using ZooServer.Models;

namespace ZooServer.Accessors {
    public class DataSetter {
        public AnimalCareContext db;
        public DataSetter(AnimalCareContext db) { this.db = db; }

        public void CreateObowiązek(int idPracownika, DateTime dataPrzeterminowania, string Typ = "") {
            Obowiązki obowiązek = new Obowiązki {
                DataPoczątku = DateTime.Now,
                IDPracownika = idPracownika,
                DataPrzeterminowania = dataPrzeterminowania,
                TypHistorii = Typ
            };
            this.db.Obowiązki.Add(obowiązek);
            this.db.SaveChanges();
        }
    }
}
