using KaraokeWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class BillDAO
    {
        KaraokeWebsiteDbContext db = null;
        public BillDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public IEnumerable<Bill> ListAllPage(int page, int pageSize)
        {
            IOrderedQueryable<Bill> model = db.Bills;
            return model.OrderBy(x => x.created_at).ToPagedList(page, pageSize);
        }
        public long AddBill(Bill bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
            return bill.bill_id;
        }
        public bool Delete(int bill_id)
        {
            try
            {
                var bill = db.Bills.Find(bill_id);
                db.Bills.Remove(bill);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Bill bill)
        {
            try
            {
                Bill infor = db.Bills.Find(bill.bill_id);
                infor.used_time = bill.used_time;
                infor.status = bill.status;
                infor.total_room = bill.total_room;
                infor.total = bill.total;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Bill GetById(int bill_id)
        {
            return db.Bills.Find(bill_id);
        }
        public List<Bill> ListAll()
        {
            return db.Bills.OrderBy(x => x.created_at).ToList();
        }
        public List<Bill> ListBill(int id)
        {
            return db.Bills.Where(x => x.bill_id == id && x.status == 1).ToList();
        }
    }
}