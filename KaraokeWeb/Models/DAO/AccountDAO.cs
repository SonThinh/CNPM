using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KaraokeWeb.Models.EF;
using PagedList;

namespace KaraokeWeb.Models.DAO
{
    public class AccountDAO
    {
        KaraokeWebsiteDbContext db = null;
        public AccountDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public long AddAccount(Account acc)
        {
            db.Accounts.Add(acc);
            db.SaveChanges();
            return acc.id;
        }
        public IEnumerable<Account> ListAllPage(string search, int page, int pageSize)
        {
            var model = db.Accounts.Where(x => x.user_type == 2 || x.user_type == 1);
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.username.Contains(search));
            }
            return model.OrderBy(x => x.id).ToPagedList(page, pageSize);
        }

        public bool Update(Account acc)
        {
            try
            {
                var infor = db.Accounts.Find(acc.id);
                if (!string.IsNullOrEmpty(acc.password))
                {
                    infor.password = acc.password;
                }
                infor.user_type = acc.user_type;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var acc = db.Accounts.Find(id);
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Account GetByName(string EmpName)
        {
            return db.Accounts.SingleOrDefault(x => x.username == EmpName);
        }
        public Account GetById(int id)
        {
            return db.Accounts.Find(id);
        }
        
        public int LoginAdmin(string userName,string passWord, bool isLoginAdmin = false)
        {
            var result = db.Accounts.SingleOrDefault(x => x.username == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(isLoginAdmin == true)
                {
                    if(result.user_type == 0)
                    {
                        if (result.password == passWord) return 1;
                        else return -1;
                    }
                    else
                    {
                        return -2;
                    }
                }
                else
                {
                    if (result.password == passWord) return 1;
                    else return -1;
                } 
            }
        }
        public int LoginEmp(string userName, string passWord)
        {
            var result = db.Accounts.SingleOrDefault(x => x.username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            { 
                if (result.password == passWord) return 1;
                else return -1; 
            }
        }
    }
}