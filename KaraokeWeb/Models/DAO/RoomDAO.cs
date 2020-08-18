using KaraokeWeb.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaraokeWeb.Models.DAO
{
    public class RoomDAO
    {
        KaraokeWebsiteDbContext db = null;
        public RoomDAO()
        {
            db = new KaraokeWebsiteDbContext();
        }
        public long AddRoom(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
            return room.room_id;
        }
        public IEnumerable<Room> ListAllPage(string search, int page, int pageSize)
        {
            IOrderedQueryable<Room> model = db.Rooms;
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.room_name.Contains(search)).OrderBy(x => x.room_id);
            }
            return model.OrderBy(x => x.room_id).ToPagedList(page, pageSize);
        }
        public bool Update(Room room)
        {
            try
            {
                Room infor = db.Rooms.Find(room.room_id);
                infor.kara_id = room.kara_id;
                infor.room_name = room.room_name;
                infor.price= room.price;
                infor.capacity = room.capacity;
                infor.image = room.image;
                infor.status = room.status;
                infor.r_status = room.r_status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Cancel(Room room)
        {
            try
            {
                Room infor = db.Rooms.Find(room.room_id);
                infor.r_status = room.r_status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int room_id)
        {
            try
            {
                var room = db.Rooms.Find(room_id);
                db.Rooms.Remove(room);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Room GetByName(string RoomName)
        {
            return db.Rooms.SingleOrDefault(x => x.room_name == RoomName);
        }
        public Room GetById(int room_id)
        {
            return db.Rooms.Find(room_id);
        }
        public List<Room> ListAll()
        {
            return db.Rooms.Where(x => x.status == 1).OrderBy(x => x.room_id).ToList();
        }
        public List<Room> ListAllEmpty(int kara_id)
        {
            return db.Rooms.Where(x => x.r_status == 0 && x.kara_id == kara_id && x.status == 1).OrderBy(x => x.room_id).ToList();
        }
        public List<Room> ListRoomFromKara(int id)
        {
            return db.Rooms.Where(x => x.kara_id == id && x.status == 1).ToList();
        }

        public int ChangeRoomStatus(int room_id, int status)
        {
            var room = db.Rooms.Find(room_id);
            room.r_status = status;
            db.SaveChanges();
            return room.status;
        }
    }
}
