using KaraokeWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class DrinkDAO
    {
        KaraokeWebsiteDbContext db = null;
        public DrinkDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public long AddDrink(Drink drink)
        {
            db.Drinks.Add(drink);
            db.SaveChanges();
            return drink.drink_id;
        }
        public IEnumerable<Drink> ListAllPage(string search, int page, int pageSize)
        {
            var model = db.Drinks.Where(x => x.status == 1);
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.drink_name.Contains(search)).OrderBy(x => x.drink_id);
            }
            return model.OrderBy(x => x.drink_id).ToPagedList(page, pageSize);
        }
        public bool Update(Drink drink)
        {
            try
            {
                Drink infor = db.Drinks.Find(drink.drink_id);
                infor.drink_name = drink.drink_name;
                infor.menu_id = drink.menu_id;
                infor.price = drink.price;
                infor.status = drink.status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int drink_id)
        {
            try
            {
                var drink = db.Drinks.Find(drink_id);
                db.Drinks.Remove(drink);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Drink GetByName(string drinkName)
        {
            return db.Drinks.SingleOrDefault(x => x.drink_name == drinkName);
        }
        public Drink GetById(int drink_id)
        {
            return db.Drinks.Find(drink_id);
        }
        public List<Drink> ListAll()
        {
            return db.Drinks.Where(x => x.status == 1).ToList();
        }
    }
}