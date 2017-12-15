using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_HoangHiep.Models;
using PagedList;
using PagedList.Mvc;

namespace Web_HoangHiep.DAO
{
    public class UserDao
    {
        MyDBContext db = null;
        public UserDao ()
        {
            db = new MyDBContext();
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderBy(n => n.ID).ToPagedList(page, pageSize);
        }


        public int Insert(User model)
        {
            db.Users.Add(model);
            db.SaveChanges();
            return model.ID;

        }
        public bool Update(User entity)
        {

            var model = db.Users.Find(entity.ID);
            model.UserName = entity.UserName;
            model.Password = entity.Password;
            model.Email = entity.Email;
            db.SaveChanges();
            return true;
        }
        public User getUser(string username,string password)
        {
            return db.Users.SingleOrDefault(n => n.UserName == username && n.Password == password);
        }
        public bool CheckLogin(string username)
        {
            User user = db.Users.SingleOrDefault(n => n.UserName == username);
            if (user == null)
            {
                return true;
            }
            else
                return false;

        }
   
        public User ViewDeatis(int id)
        {
            return db.Users.Find(id);
        }

        public int Login(string UserName,string Password)
        {
            var result = db.Users.SingleOrDefault(n => n.UserName == UserName );
            if (result == null)
            {
                return 0;

            }
            else
            {
                if (result.Password == Password)
                    return 1;
                else
                    return -1;
            }
        }
        public void Delete(int id)
        {
            User model = db.Users.Find(id);
            db.Users.Remove(model);
            db.SaveChanges();

        }
       public bool CheckUser(string name,string email)
        {
            var model = db.Users.SingleOrDefault(n => n.UserName == name && n.Email == email);

            if (model == null)
            {
                return true;
            }
            else
                return false;
        }
    }
}