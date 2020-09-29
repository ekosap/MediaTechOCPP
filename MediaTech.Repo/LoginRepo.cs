using MediaTech.Model;
using MediaTech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediaTech.Repo
{
    public class LoginRepo
    {

        private readonly ApplicationDbContext _db;
        public LoginRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public UserViewModel Login(string Email, string Password)
        {
            UserViewModel hasil = new UserViewModel();
            //hasil = _db.User.Select(x => new UserViewModel()
            //{
            //    UserId = x.UserId,
            //    Name = x.Name,
            //    RoleId = x.RoleId
            //}).Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();

            hasil = (from User in _db.User
                     join Role in _db.Role
                       on User.RoleId equals Role.RoleID
                    where (User.Email == Email && User.Password == Password)
                    select new UserViewModel()
                    {
                        UserId = User.UserId,
                        Name = User.Name,
                        RoleId = User.RoleId,
                        StringRole = Role.RoleName,
                        Email = User.Email
                    }).FirstOrDefault();
            return hasil;
        }
    }
}
