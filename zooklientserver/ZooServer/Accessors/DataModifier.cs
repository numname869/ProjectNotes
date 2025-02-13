using ZooServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ZooServer.Accessors {
    public class DataModifier {

        private readonly AnimalCareContext db;

        public DataModifier(AnimalCareContext db)
        {
            this.db = db;
        }

      
        public void UpdateKonto(int accountId, string newLogin, string newPassword, string newAccountType)
        {
            var account = db.Konta.SingleOrDefault(k => k.IDKonta == accountId);
            if (account != null)
            {
                account.Login = newLogin;
                account.Haslo = newPassword; 
                account.TypKonta = newAccountType;

                db.Konta.Update(account);
                db.SaveChanges();
            }
        }

   
        public void UpdateObowiazek(int obligationId, DateTime newExpiryDate)
        {
            var obligation = db.Obowiązki.SingleOrDefault(o => o.IDObowiązku == obligationId);
            if (obligation != null)
            {
                obligation.DataPrzeterminowania = newExpiryDate;
                db.Obowiązki.Update(obligation);
                db.SaveChanges();
            }
        }


        public void UpdatePracownik(int pracownikId, string newImie, string newNazwisko, string newRola, string newEmail, string newNumerTelefonu)
        {
            var pracownik = db.Pracownicy.SingleOrDefault(p => p.IDPracownika == pracownikId);
            if (pracownik != null)
            {
                pracownik.Imię = newImie;
                pracownik.Nazwisko = newNazwisko;
                pracownik.Rola = newRola;
                pracownik.Email = newEmail;
                pracownik.NumerTelefonu = newNumerTelefonu;

                db.Pracownicy.Update(pracownik);
                db.SaveChanges();
            }
        }

   
        public void UpdateZwierze(int zwierzeId, string newNazwa, string newGatunek, int newWiek, string newStatus, string newOpis)
        {
            var zwierze = db.Zwierzęta.SingleOrDefault(z => z.IDZwierzęcia == zwierzeId);
            if (zwierze != null)
            {
                zwierze.Nazwa = newNazwa;
                zwierze.Gatunek = newGatunek;
                zwierze.Wiek = newWiek;
                zwierze.Status = newStatus;
                zwierze.Opis = newOpis;

                db.Zwierzęta.Update(zwierze);
                db.SaveChanges();
            }
        }

       

        public void UpdateZagroda(int zagrodaId, string newTypZagrody, float newWielkosc, string newLokalizacja, int newPojemnosc, string newStatus)
        {
            var zagroda = db.Zagrody.SingleOrDefault(z => z.IDZagrody == zagrodaId);
            if (zagroda != null)
            {
                zagroda.TypZagrody = newTypZagrody;
                zagroda.Wielkość = newWielkosc;
                zagroda.Lokalizacja = newLokalizacja;
                zagroda.Pojemność = newPojemnosc;
                zagroda.Status = newStatus;

                db.Zagrody.Update(zagroda);
                db.SaveChanges();
            }
        }

     

        public void UpdateInspekcjaZdrowia(int inspekcjaId, string newOpis, string newZalecenia)
        {
            var inspekcja = db.InspekcjeZdrowia.SingleOrDefault(i => i.IDInspekcjiZdrowia == inspekcjaId);
            if (inspekcja != null)
            {
                inspekcja.Opis = newOpis;
                inspekcja.Zalecenia = newZalecenia;

                db.InspekcjeZdrowia.Update(inspekcja);
                db.SaveChanges();
            }
        }

     

        public void UpdateInspekcjaZagrody(int inspekcjaId, string newWynik, string newOpis, string newZalecenia)
        {
            var inspekcja = db.InspekcjeZagród.SingleOrDefault(i => i.IDInspekcjiZagrody == inspekcjaId);
            if (inspekcja != null)
            {
                inspekcja.WynikInspekcji = newWynik;
                inspekcja.Opis = newOpis;
                inspekcja.Zalecenia = newZalecenia;

                db.InspekcjeZagród.Update(inspekcja);
                db.SaveChanges();
            }
        }

        

        public void UpdateKarmienie(int karmienieId, DateTime newDataKarmienia, string newRodzajKarmy, float newIloscKarmy)
        {
            var karmienie = db.Karmienia.SingleOrDefault(k => k.IDKarmienia == karmienieId);
            if (karmienie != null)
            {
                karmienie.DataKarmienia = newDataKarmienia;
                karmienie.RodzajKarmy = newRodzajKarmy;
                karmienie.IlośćKarmy = newIloscKarmy;

                db.Karmienia.Update(karmienie);
                db.SaveChanges();
            }
        }

      

        public void UpdatePomiarBiometryczny(int pomiarId, float newTemperatura, float newWaga, float newDlugosc, string newInnePomiary)
        {
            var pomiar = db.PomiaryBiometryczne.SingleOrDefault(p => p.IDPomiaru == pomiarId);
            if (pomiar != null)
            {
                pomiar.Temperatura = newTemperatura;
                pomiar.Waga = newWaga;
                pomiar.Długość = newDlugosc;
                pomiar.InnePomiary = newInnePomiary;

                db.PomiaryBiometryczne.Update(pomiar);
                db.SaveChanges();
            }
        }
    }

}





