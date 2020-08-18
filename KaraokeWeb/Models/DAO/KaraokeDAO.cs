using KaraokeWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class KaraokeDAO
    {
        KaraokeWebsiteDbContext db = null;
        public KaraokeDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public long AddKaraoke(Karaoke kara)
        {
            db.Karaokes.Add(kara);
            db.SaveChanges();
            return kara.kara_id;
        }
        public IEnumerable<Karaoke> ListAllPage(string search, int page, int pageSize)
        {
            IOrderedQueryable<Karaoke> model = db.Karaokes;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.kara_name.Contains(search)).OrderBy(x => x.kara_id);
            }
            return model.OrderBy(x => x.kara_id).ToPagedList(page, pageSize);
        }
        public bool Update(Karaoke kara)
        {
            try
            {
                Karaoke infor = db.Karaokes.Find(kara.kara_id);
                infor.kara_name = kara.kara_name;
                infor.address = kara.address;
                infor.phone = kara.phone;
                infor.images = kara.images;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int kara_id)
        {
            try
            {
                var kara = db.Karaokes.Find(kara_id);
                db.Karaokes.Remove(kara);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Karaoke GetByName(string KaraName)
        {
            return db.Karaokes.SingleOrDefault(x => x.kara_name == KaraName);
        }
        public Karaoke GetById(int karaid)
        {
            return db.Karaokes.Find(karaid);
        }
        public List<Karaoke> ListAll()
        {
            return db.Karaokes.ToList();
        }
    }
}