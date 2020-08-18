using KaraokeWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class FoodDAO
    {
        KaraokeWebsiteDbContext db = null;
        public FoodDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public long AddFood(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
            return food.food_id;
        }
        public IEnumerable<Food> ListAllPage(string search, int page, int pageSize)
        {
            var model = db.Foods.Where(x=>x.status == 1);
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.food_name.Contains(search)).OrderBy(x => x.food_id);
            }
            return model.OrderBy(x => x.food_id).ToPagedList(page, pageSize);
        }
        public bool Update(Food food)
        {
            try
            {
                Food infor = db.Foods.Find(food.food_id);
                infor.food_name = food.food_name;
                infor.menu_id = food.menu_id;
                infor.price = food.price;
                infor.status = food.status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int food_id)
        {
            try
            {
                var food = db.Foods.Find(food_id);
                db.Foods.Remove(food);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Food GetByName(string foodName)
        {
            return db.Foods.SingleOrDefault(x => x.food_name == foodName);
        }
        public Food GetById(int food_id)
        {
            return db.Foods.Find(food_id);
        }
        public List<Food> ListAll()
        {
            return db.Foods.Where(x=>x.status == 1).ToList();
        }
    }
}