using KaraokeWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class MenuDAO
    {
        KaraokeWebsiteDbContext db = null;
        public MenuDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public long AddMenu(Menu menu)
        {
            db.Menus.Add(menu);
            db.SaveChanges();
            return menu.id;
        }
        public IEnumerable<Menu> ListAllPage(string search, int page, int pageSize)
        {
            IOrderedQueryable<Menu> model = db.Menus;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.kind.Contains(search)).OrderBy(x => x.id);
            }
            return model.OrderBy(x => x.kind).ToPagedList(page, pageSize);
        }
        public bool Update(Menu menu)
        {
            try
            {
                Menu infor = db.Menus.Find(menu.id);
                infor.kind = menu.kind;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var menu = db.Menus.Find(id);
                db.Menus.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Menu GetById(int id)
        {
            return db.Menus.Find(id);
        }
        public List<Menu> ListAll()
        {
            return db.Menus.ToList();
        }
        public List<Menu> ListAllMenu(int top)
        {
            return db.Menus.Take(top).ToList();
        }
    }
}