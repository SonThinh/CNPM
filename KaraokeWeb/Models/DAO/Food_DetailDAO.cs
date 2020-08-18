using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class Food_DetailDAO
    {
        KaraokeWebsiteDbContext db = null;
        public Food_DetailDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public List<Food_Detail> ListFoodDetailFromBill(int id)
        {
            return db.Food_Detail.Where(x => x.bill_id == id).ToList();
        }
        public long AddFoodDetail(Food_Detail fd)
        {
            db.Food_Detail.Add(fd);
            db.SaveChanges();
            return fd.bill_id;
        }

        public bool Delete(int food_id)
        {
            try
            {
                var food = db.Food_Detail.SingleOrDefault(x=>x.food_id == food_id);
                db.Food_Detail.Remove(food);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Food_Detail GetByFoodId(int food_id)
        {
            return db.Food_Detail.SingleOrDefault(x=>x.food_id == food_id);
        }
        public Food_Detail GetByBillId(int bill_id)
        {
            return db.Food_Detail.FirstOrDefault(x => x.bill_id == bill_id);
        }
        public List<Food_Detail> ListFood(int id)
        {
            return db.Food_Detail.Where(x => x.food_id == id).ToList();
        }

    }
}