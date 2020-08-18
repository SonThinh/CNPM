using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class Drink_DetailDAO
    {
        KaraokeWebsiteDbContext db = null;
        public Drink_DetailDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public List<Drink_Detail> ListDrinkDetailFromBill(int id)
        {
            return db.Drink_Detail.Where(x => x.bill_id == id).ToList();
        }
        public long AddDrinkDetail(Drink_Detail dd)
        {
            db.Drink_Detail.Add(dd);
            db.SaveChanges();
            return dd.bill_id;
        }

        public bool Delete(int drink_id)
        {
            try
            {
                var drink = db.Drink_Detail.FirstOrDefault(x => x.drink_id == drink_id);
                db.Drink_Detail.Remove(drink);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Drink_Detail GetByDrinkId(int drink_id)
        {  
            return db.Drink_Detail.SingleOrDefault(x => x.drink_id == drink_id);
        }
        public Drink_Detail GetByBillId(int bill_id)
        {
            return db.Drink_Detail.FirstOrDefault(x => x.bill_id == bill_id);
        }
        public List<Drink_Detail> ListDrink(int id)
        {
            return db.Drink_Detail.Where(x => x.drink_id == id).ToList();
        }
    }
}