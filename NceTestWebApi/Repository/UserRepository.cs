using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NceTestWebApi.Models;

namespace NceTestWebApi.Repository
{
    public class UserRepository : IUser
    {
        private nse_testContext DBcontext;

        public UserRepository(nse_testContext objUserContext)
        {
            this.DBcontext = objUserContext;
        }

        public void DeleteUser(int UserId)
        {            
            User user = DBcontext.User.Find(UserId);
            DBcontext.User.Remove(user);
            DBcontext.SaveChanges();
        }

        public User GetUserByID(int UserId)
        {
            return DBcontext.User.Find(UserId);
        }

        public IEnumerable<User> GetUsers()
        {
            return DBcontext.User.ToList();
        }

        public void InsertUser(User user)
        {
            DBcontext.User.Add(user);
            DBcontext.SaveChanges();          
        }

        public void Save()
        {
            
        }

        public void UpdateUser(User user)
        {       
            DBcontext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DBcontext.SaveChanges();
        }
    }
}
